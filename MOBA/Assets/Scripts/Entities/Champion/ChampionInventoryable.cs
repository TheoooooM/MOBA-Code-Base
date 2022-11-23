using Entities.Inventory;
using Photon.Pun;

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

        public void RequestAddItem(byte index)
        {
            photonView.RPC("AddItemRPC", RpcTarget.MasterClient, index);
        }

        [PunRPC]
        public void SyncAddItemRPC(byte index)
        {
            UIManager.Instance.UpdateInventory(ItemCollectionManager.currentItems, entityIndex);
        }

        [PunRPC]
        public void AddItemRPC(byte index)
        {
            if (ItemCollectionManager.currentItems.Count >= 3)
                return;

            //Item newItem = ItemCollectionManager.GetItem(index);

            ItemCollectionManager.TryAddToCurrentItems(index);

            photonView.RPC("SyncAddItemRPC", RpcTarget.All, index);
        }

        public event GlobalDelegates.ByteDelegate OnAddItem;
        public event GlobalDelegates.ByteDelegate OnAddItemFeedback;

        public void RequestRemoveItem(byte index)
        {
            throw new System.NotImplementedException();
        }

        public void RequestRemoveItem(Item item)
        {
            throw new System.NotImplementedException();
        }

        [PunRPC]
        public void SyncRemoveItemRPC(byte index)
        {
            throw new System.NotImplementedException();
        }

        [PunRPC]
        public void RemoveItemRPC(byte index)
        {
            throw new System.NotImplementedException();
        }

        public event GlobalDelegates.ByteDelegate OnRemoveItem;
        public event GlobalDelegates.ByteDelegate OnRemoveItemFeedback;
    }
}