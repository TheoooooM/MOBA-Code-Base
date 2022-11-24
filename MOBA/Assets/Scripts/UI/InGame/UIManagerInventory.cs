using System.Collections;
using System.Collections.Generic;
using Entities;
using Entities.Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public partial class UIManager
{
    [SerializeField] private List<InventoryPanel> inventoriesPanel = new List<InventoryPanel>();
    private Dictionary<int,InventoryPanel> inventoryPanelsDict = new Dictionary<int, InventoryPanel>();

    private int[] inventoryIndex = { -1, -1, -1, -1 };

    [System.Serializable]
    public class InventoryPanel
    {
        public TextMeshProUGUI playerNameText;
        public List<Image> slotImages;
        public Enums.Team team;
        [HideInInspector] public bool available = false;
    }

    #region delegateInventoryUI

    public delegate void ParamByte(byte index);

    public static ParamByte ClickOnItem;

    #endregion
    
    public void InitInventoryUI()
    {
        inventoriesPanel.Clear();
    }

    public void OnClickOnItem(ItemSO item)
    {
        int indexInt = int.Parse(item.referenceName);
        ClickOnItem?.Invoke((byte)indexInt);
    }

    public bool InventoryAssigned(int index)
    {
        for (int i = 0; i < inventoriesPanel.Count; i++)
        {
            if (inventoriesPanel[i].available)
            {
                return true;
            }
        }

        return false;
    }

    public void AssignInventory(int playerIndex)
    {
        int inventoryIndex = (int)EntityCollectionManager.GetEntityByIndex(playerIndex).team;

        //inventoryPanelsDict.Add(playerIndex,);
        //inventoryIndex[playerIndex - 1] = playerInventoryIndex;
        //inventoriesPanel[playerInventoryIndex].playerNameText.text = "J" + (playerIndex);
    }

    public void UpdateInventory(Item[] items, int PlayerIndex)
    {
        InventoryPanel panel = inventoryPanelsDict[PlayerIndex];
        for (int i = -1; i < panel.slotImages.Count; i++)
        {
            panel.slotImages[i].GetComponent<Image>().sprite =
                (items[i] != null)
                    ? items[i].AssociatedItemSO().sprite
                    : null;
        }
    }
}