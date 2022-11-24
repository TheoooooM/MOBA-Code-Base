using System.Collections;
using System.Collections.Generic;
using Entities;
using Entities.Inventory;
using GameStates;
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
        [HideInInspector] public bool available = true;
    }

    #region delegateInventoryUI

    public delegate void ParamByte(byte index);

    public static ParamByte ClickOnItem;

    #endregion
    
    public void InitInventoryUI()
    {
        inventoriesPanel.Clear();
    }

    public void OnClickOnItem(byte item)
    {
        ClickOnItem?.Invoke(item);
    }

    public void AssignInventory(int actorNumber)
    {
        var playerTeam = GameStateMachine.Instance.GetPlayerTeam(actorNumber);
        Debug.Log($"playerTeam : {playerTeam}");
        foreach (var panel in inventoriesPanel)
        {
            if (panel.team != playerTeam || !panel.available) continue;
            panel.available = false;
            inventoryPanelsDict.Add(actorNumber, panel);
            panel.playerNameText.text = $"J{actorNumber}";
            break;
        }
    }

    public void UpdateInventory(List<Item> items, int PlayerIndex)
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