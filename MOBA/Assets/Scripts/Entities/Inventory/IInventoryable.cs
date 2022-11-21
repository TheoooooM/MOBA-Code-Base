namespace Entities.Inventory
{
    public interface IInventoryable
    {
        /// <returns>The items in the inventory of the entity</returns>
        public Item[] GetItems();
        /// <returns>The item in the inventory of the entity at the given index, can be null</returns>
        public Item GetItem(int index);
        
        /// <summary>
        /// Sends an RPC to the master to add an item to the entity's inventory.
        /// </summary>
        /// <param name="index">the index of the item on the ItemCollectionManager</param>
        public void RequestAddItem(byte index);

        /// <summary>
        /// Sends an RPC to all clients to add an item to the entity's inventory.
        /// </summary>
        /// <param name="index">the index of the item on the ItemCollectionManager</param>
        public void SyncAddItemRPC(byte index);

        /// <summary>
        /// Adds an item to the entity's inventory.
        /// </summary>
        /// <param name="index">the index of the item on the ItemCollectionManager</param>
        public void AddItemRPC(byte index);

        public event GlobalDelegates.ByteDelegate OnAddItem;
        
        /// <summary>
        /// Sends an RPC to the master to remove an item from the entity's inventory.
        /// </summary>
        /// <param name="index">the index of the item on the entity's item list</param>
        public void RequestRemoveItem(byte index);
        
        /// <summary>
        /// Sends an RPC to the master to remove an item from the entity's inventory.
        /// </summary>
        /// <param name="item">the item on the entity's item list</param>
        public void RequestRemoveItem(Item item);

        /// <summary>
        /// Sends an RPC to all clients to remove an item from the entity's inventory.
        /// </summary>
        /// <param name="index">the index of the item on the entity's item list</param>
        public void SyncRemoveItemRPC(byte index);

        /// <summary>
        /// Removes an item from the entity's inventory.
        /// </summary>
        /// <param name="index">the index of the item on the entity's item list</param>
        public void RemoveItemRPC(byte index);

        public event GlobalDelegates.ByteDelegate OnRemoveItem;

    }
}


