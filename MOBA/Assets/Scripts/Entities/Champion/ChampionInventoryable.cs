using System.Linq;
using Entities.Capacities;
using Entities.Inventory;
using Photon.Pun;
using UnityEngine;

namespace Entities.Champion
{
    public partial class Champion : IInventoryable
    {
        public Item[] items = new Item[3];

        public Item[] GetItems()
        {
            return items;
        }

        public Item GetItem(int index)
        {
            if (index < 0 || index >= items.Length) return null;
            return items[index];
        }

        public Item GetItemOfSo(int soIndex)
        {
            return items.FirstOrDefault(item => item.indexOfSOInCollection == soIndex);
        }

        public void RequestAddItem(byte index)
        {
            photonView.RPC("AddItemRPC",RpcTarget.MasterClient,index);
        }

        [PunRPC]
        public void AddItemRPC(byte index)
        {
            if(ItemCollectionManager.CreateItem(index, this) == null) return;
            OnAddItem?.Invoke(index);
            OnAddItemFeedback?.Invoke(index);
            photonView.RPC("SyncAddItemRPC",RpcTarget.Others, index);
        }

        [PunRPC]
        public void SyncAddItemRPC(byte index)
        {
            var item = ItemCollectionManager.CreateItem(index, this);
            if(item == null) return;
            item.OnItemAddedToInventoryFeedback(this);
            OnAddItemFeedback?.Invoke(index);
            
            
            
            
            
            
            
            
            uiManager.UpdateInventory(ItemCollectionManager.allItems, entityIndex);
        }
        
        public event GlobalDelegates.ByteDelegate OnAddItem;
        public event GlobalDelegates.ByteDelegate OnAddItemFeedback;

        public void RequestRemoveItem(byte index) { }

        public void RequestRemoveItem(Item item) { }
        [PunRPC]
        public void RemoveItemRPC(byte index) { }
        [PunRPC]
        public void SyncRemoveItemRPC(byte index) { }

        public event GlobalDelegates.ByteDelegate OnRemoveItem;
        public event GlobalDelegates.ByteDelegate OnRemoveItemFeedback;
        public void RequestActivateItem(byte itemIndex,int[] selectedEntities,Vector3[] positions)
        {
            photonView.RPC("ActivateItemRPC",RpcTarget.MasterClient,itemIndex,selectedEntities,positions);
        }

        [PunRPC]
        public void ActivateItemRPC(byte itemIndex,int[] selectedEntities,Vector3[] positions)
        {
            if(itemIndex >= items.Length) return;
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
            if(itemIndex >= items.Length) return;
            if(items[itemIndex] == null) return;
            items[itemIndex].OnItemActivatedFeedback(selectedEntities,positions);
            OnActivateItemFeedback?.Invoke(itemIndex,selectedEntities,positions);
        }

        public event GlobalDelegates.ByteIntArrayVector3ArrayDelegate OnActivateItem;
        public event GlobalDelegates.ByteIntArrayVector3ArrayDelegate OnActivateItemFeedback;
    }
}