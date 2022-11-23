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

    //private int[] inventoryIndex = { -1, -1, -1, -1 };
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

    public void UpdateInventory(List<ItemSO> items, uint entityIndex, int MyplayerId)
    {
        Debug.Log(MyplayerId);
        // RectTransform inventory = inventoriesPanel[inventoryIndex[entityIndex]];
        //
        // for (int i = 0; i < inventory.childCount; i++)
        // {
        //     inventory.GetChild(i).GetComponent<Image>().sprite =
        //         (items.Count > i && items[i] != null)
        //             ? items[i].SpriteOfItem
        //             : null;
        // }
    }
}