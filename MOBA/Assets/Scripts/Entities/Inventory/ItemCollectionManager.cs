using System;
using System.Collections.Generic;
using Photon.Pun;

namespace Entities.Inventory
{
    public class ItemCollectionManager : MonoBehaviourPun
    {
        public List<ItemSO> allItemSOs = new List<ItemSO>();
        public static readonly List<ItemSO> allItems = new List<ItemSO>();
        public static readonly List<ItemSO> currentItems = new List<ItemSO>();
        public static PhotonView view;

        private void Start()
        {
            view = photonView;
            SetAllItems();
        }

        private void SetAllItems()
        {
            allItems.Clear();
            foreach (var itemSO in allItemSOs)
            {
                allItems.Add(itemSO);
            }
        }

        public static Item GetItem(byte index)
        {
            if (index >= allItems.Count) return null;
            return (Item)Activator.CreateInstance(allItems[index].GetAssociatedItemType());
        }

        public static bool IsInCurrentItems(ItemSO itemSO)
        {
            return currentItems.Contains(itemSO);
        }

        public static bool IsInCurrentItems(Item item)
        {
            return IsInCurrentItems(item.AssociatedItemSo());
        }

        public static bool IsInCurrentItems(byte itemSoIndex)
        {
            if (itemSoIndex >= allItems.Count) return false;
            return IsInCurrentItems(allItems[itemSoIndex]);
        }

        public static void TryAddToCurrentItems(byte itemSoIndex)
        {
            if (itemSoIndex >= allItems.Count) return;
            view.RPC("AddToCurrentItemsRPC",RpcTarget.All,itemSoIndex);
        }

        [PunRPC] public void AddToCurrentItemsRPC(byte itemSoIndex)
        {
            if (itemSoIndex >= allItems.Count) return;
            currentItems.Add(allItems[itemSoIndex]);
        }

        public static void TryRemoveFromCurrentItems(byte itemSoIndex)
        {
            if (itemSoIndex >= allItems.Count) return;
            view.RPC("RemoveToCurrentItemsRPC",RpcTarget.All,itemSoIndex);
        }
        
        [PunRPC] public static void RemoveToCurrentItemsRPC(byte itemSoIndex)
        {
            if (itemSoIndex >= allItems.Count) return;
            var itemSo = allItems[itemSoIndex];
            if(currentItems.Contains(itemSo)) currentItems.Remove(itemSo);
        }
    }
}

