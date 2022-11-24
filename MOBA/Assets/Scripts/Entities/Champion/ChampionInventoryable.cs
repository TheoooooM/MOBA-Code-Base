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

        public void RequestAddItem(byte index) { }

        [PunRPC]
        public void SyncAddItemRPC(byte index) { }

        [PunRPC]
        public void AddItemRPC(byte index) { }

        public event GlobalDelegates.ByteDelegate OnAddItem;
        public event GlobalDelegates.ByteDelegate OnAddItemFeedback;

        public void RequestRemoveItem(byte index) { }

        public void RequestRemoveItem(Item item) { }

        [PunRPC]
        public void SyncRemoveItemRPC(byte index) { }

        [PunRPC]
        public void RemoveItemRPC(byte index) { }

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
            foreach (var capacityIndex in item.AssociatedItemSO().activeCapacitiesIndexes)
            {
                var activeCapacity = CapacitySOCollectionManager.CreateActiveCapacity(capacityIndex,this);
                if (!activeCapacity.TryCast(entityIndex, selectedEntities, positions)) return;
                // TODO - activeCapacityFeedback
            }
            items[itemIndex].OnItemActivated(selectedEntities,positions);
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