using System.Collections.Generic;
using System.Linq;
using Entities.Capacities;
using Entities.Inventory;
using GameStates;
using Photon.Pun;
using TMPro.EditorUtilities;
using UnityEngine;

namespace Entities.Champion
{
    public partial class Champion : IInventoryable
    {
        [SerializeReference] public List<Item> items = new List<Item>();

        public Item[] GetItems()
        {
            return items.ToArray();
        }

        public Item GetItem(int index)
        {
            if (index < 0 || index >= 3) return null;
            return items[index];
        }

        public Item GetItemOfSo(int soIndex)
        {
            return items.FirstOrDefault(item => item.indexOfSOInCollection == soIndex);
        }

        public void RequestAddItem(byte index)
        {
            photonView.RPC("AddItemIDRPC",RpcTarget.MasterClient,index, (byte)PhotonNetwork.LocalPlayer.ActorNumber);
        }

        [PunRPC]
        public void AddItemIDRPC(byte index, byte SenderID)
        {
            var itemSo = ItemCollectionManager.GetItemSObyIndex(index);
            if (itemSo.consumable)
            {
                var contains = false;
                foreach (var item in items.Where(item => item.indexOfSOInCollection == index))
                {
                    contains = true;
                }
                if(!contains && items.Count>=3) return;
                photonView.RPC("SyncAddItemIDRPC",RpcTarget.All, index, SenderID);
                return;
            }
            if(items.Count>=3) return;
            photonView.RPC("SyncAddItemIDRPC",RpcTarget.All, index, SenderID);
        }

        [PunRPC]
        public void SyncAddItemIDRPC(byte index, byte SenderID)
        {
            var item = ItemCollectionManager.CreateItem(index, this);
            if(item == null) return;
            if(!items.Contains(item)) items.Add(item);
            if (PhotonNetwork.IsMasterClient)
            {
                item.OnItemAddedToInventory(this);
                OnAddItem?.Invoke(index);
            }

            Debug.Log($"{items.Count} {SenderID}");

            uiManager.UpdateInventory(items, SenderID);
            item.OnItemAddedToInventoryFeedback(this);
            OnAddItemFeedback?.Invoke(index);
        }
        
        public event GlobalDelegates.ByteDelegate OnAddItem;
        public event GlobalDelegates.ByteDelegate OnAddItemFeedback;
        
        /// <param name="index">index of Item in this entity's inventory</param>
        public void RequestRemoveItem(byte index)
        {
            photonView.RPC("RemoveItemRPC",RpcTarget.MasterClient,index);
        }

        /// <param name="item">Item to remove from this entity's inventory</param>
        public void RequestRemoveItem(Item item)
        {
            if(!items.Contains(item)) return;
            RequestRemoveItem((byte)items.IndexOf(item));
        }

        [PunRPC]
        public void RemoveItemRPC(byte index)
        {
            photonView.RPC("SyncRemoveItemRPC",RpcTarget.All,index);
        }

        [PunRPC]
        public void SyncRemoveItemRPC(byte index)
        {
            if(index >= items.Count) return;
            var item = items[index];
            items.Remove(item);
            if (PhotonNetwork.IsMasterClient)
            {
                item.OnItemRemovedFromInventory(this);
                OnRemoveItem?.Invoke(index);
            }
            item.OnItemRemovedFromInventoryFeedback(this);
            OnRemoveItemFeedback?.Invoke(index);
        }
        public event GlobalDelegates.ByteDelegate OnRemoveItem;
        public event GlobalDelegates.ByteDelegate OnRemoveItemFeedback;
        
        public void RequestActivateItem(byte itemIndex,int[] selectedEntities,Vector3[] positions)
        {
            photonView.RPC("ActivateItemRPC",RpcTarget.MasterClient,itemIndex,selectedEntities,positions);
        }

        [PunRPC]
        public void ActivateItemRPC(byte itemIndex,int[] selectedEntities,Vector3[] positions)
        {
            if(itemIndex >= items.Count) return;
            var item = items[itemIndex];
            if(item == null) return;
            items[itemIndex].OnItemActivated(selectedEntities,positions);
            foreach (var capacityIndex in item.AssociatedItemSO().activeCapacitiesIndexes)
            {
                var activeCapacity = CapacitySOCollectionManager.CreateActiveCapacity(capacityIndex,this);
                if (!activeCapacity.TryCast(entityIndex, selectedEntities, positions)) return;
                // TODO - activeCapacityFeedback
            }
            OnActivateItem?.Invoke(itemIndex,selectedEntities,positions);
            photonView.RPC("SyncActivateItemRPC",RpcTarget.All,itemIndex,selectedEntities,positions);
        }

        [PunRPC]
        public void SyncActivateItemRPC(byte itemIndex,int[] selectedEntities,Vector3[] positions)
        {
            if(itemIndex >= items.Count) return;
            if(items[itemIndex] == null) return;
            items[itemIndex].OnItemActivatedFeedback(selectedEntities,positions);
            OnActivateItemFeedback?.Invoke(itemIndex,selectedEntities,positions);
        }

        public event GlobalDelegates.ByteIntArrayVector3ArrayDelegate OnActivateItem;
        public event GlobalDelegates.ByteIntArrayVector3ArrayDelegate OnActivateItemFeedback;
    }
}