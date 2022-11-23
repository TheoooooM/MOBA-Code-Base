using System;
using System.Collections;
using System.Collections.Generic;
using Entities;
using Entities.Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public partial class UIManager
{
    [SerializeField] private List<RectTransform> inventoriesPanel;

    private Dictionary<int, int> inventoryIndex = new Dictionary<int, int>();

    #region delegateInventoryUI

    public delegate void ParamByte(byte index);

    public static ParamByte ClickOnItem;

    #endregion

    public void OnClickOnItem(int item)
    {
        ClickOnItem?.Invoke((byte)item);
    }

    public bool InventoryAssigned(int index)
    {
        int value = -1;
        return (inventoryIndex.TryGetValue(index, out value)) ;
    }

    public void AssignInventory(int PlayerIndex, int teamTMP)
    {
        int indexInventory = ((int)teamTMP - 1) * 2;

        indexInventory += Convert.ToInt32(InventoryAssigned(((int)teamTMP - 1) * 2));

        TMP_Text textPlayer = inventoriesPanel[indexInventory].parent.parent.GetChild(0).GetComponent<TMP_Text>();
        inventoryIndex.Add(indexInventory, PlayerIndex);
        textPlayer.text = "J" + ((PlayerIndex - 1) / 1000);
    }

    public void UpdateInventory(List<ItemSO> items, uint entityIndex)
    {
        for (int i = 0; i < inventoryIndex.Count; i++)
        {
            if (inventoryIndex[i] == entityIndex)
            {
                RectTransform inventory = inventoriesPanel[i];
                
                 for (int j = 0; j < inventory.childCount; j++)
                 {
                     inventory.GetChild(j).GetComponent<Image>().sprite =
                         (items.Count > j && items[j] != null)
                             ? items[j].SpriteOfItem
                             : null;
                }
                return;
            }
        }

    }
}