using System.Collections;
using System.Collections.Generic;
using Entities.Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public partial class UIManager
{
    
    [SerializeField] private List<RectTransform> inventoriesPanel;

    private int[] inventoryIndex = { -1, -1, -1, -1 };
    
    
    #region delegateInventoryUI

    public delegate void ParamByte(byte index);
    public static ParamByte ClickOnItem;

    #endregion
    
    public void OnClickOnItem(ItemSO item)
    {
        int indexInt = int.Parse(item.referenceName);
        ClickOnItem?.Invoke((byte)indexInt);
    }
    
    public bool InventoryAssigned(int index)
    {
        for (int i = 0; i < inventoryIndex.Length; i++)
        {
            if (inventoryIndex[i] == index)
            {
                return true;
            }
        }
        return false;
    }
    
    public void AssignInventory(int PlayerIndex, int playerInventoryIndex)
    {
        TMP_Text textPlayer = inventoriesPanel[playerInventoryIndex].parent.parent.GetChild(0).GetComponent<TMP_Text>();
        inventoryIndex[PlayerIndex - 1] = playerInventoryIndex;
        textPlayer.text = "J" + (PlayerIndex);
    }

    public void UpdateInventory(Item[] items, int PlayerIndex)
    {
        RectTransform inventory = inventoriesPanel[inventoryIndex[PlayerIndex - 1]];

        for (int i = -1; i < inventory.childCount; i++)
        {
            inventory.GetChild(i).GetComponent<Image>().sprite =
                (items[i] != null)
                    ? items[i].AssociatedItemSo().SpriteOfItem
                    : null;
        }
    }
}
