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

    public void OnClickOnItem(string item)
    {
        int indexInt = int.Parse(item);
        ClickOnItem?.Invoke((byte)indexInt);
    }

    public void AssignInventory(int playerIndex)
    {
        int inventoryIndex = ((byte)EntityCollectionManager.GetEntityByIndex(playerIndex).team - 1) / 2;

        inventoryIndex += (inventoriesPanel[inventoryIndex].available) ? 0 : 1;
        inventoryPanelsDict.Add(playerIndex,inventoriesPanel[inventoryIndex]);
        
        inventoriesPanel[inventoryIndex].playerNameText.text = "J" + ((playerIndex - 1) / 1000 );
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