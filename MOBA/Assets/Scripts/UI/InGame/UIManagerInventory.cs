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
    [SerializeField] private List<LocalInventorySlots> ListLocalInventorySlots = new List<LocalInventorySlots>();
    [SerializeField] private RectTransform InventoryCanvas;
    
    private Dictionary<int,InventoryPanel> inventoryPanelsDict = new Dictionary<int, InventoryPanel>();
    
    [System.Serializable]
    public class InventoryPanel
    {
        public TextMeshProUGUI playerNameText;
        public List<Image> slotImages;
        public Enums.Team team;
        [HideInInspector] public bool available = true;
    }
    
    [System.Serializable]
    public class LocalInventorySlots
    {
        public Image slotImages;
        public Button slotButton;
    }

    #region delegateInventoryUI

    public delegate void ParamByte(byte index);

    public static ParamByte ClickOnItem;
    public static ParamByte RemoveOnItem;

    #endregion
    
    
    public void ShowHideInventory(bool show)
    {
        InventoryCanvas.gameObject.SetActive(show);
    }
    public void InitInventoryUI()
    {
        inventoriesPanel.Clear();
    }

    public void OnClickOnItem(byte item)
    {
        ClickOnItem?.Invoke(item);
    }
    
    public void OnRemoveOnItem(byte item)
    {
        RemoveOnItem?.Invoke(item);
    }

    public void AssignInventory(int actorNumber)
    {
        var playerTeam = GameStateMachine.Instance.GetPlayerTeam();
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

    public void UpdateInventory(List<Item> items, int PlayerIndex, bool isMyInventory)
    {
        InventoryPanel panel = inventoryPanelsDict[PlayerIndex];
        for (int i = 0; i < panel.slotImages.Count; i++)
        {
            panel.slotImages[i].sprite =
                (items.Count > i && items[i] != null)
                    ? items[i].AssociatedItemSO().sprite
                    : null;
        }
        
        if (isMyInventory)
        {
            for (int i = 0; i < ListLocalInventorySlots.Count; i++)
            {
                ListLocalInventorySlots[i].slotImages.sprite =
                    (items.Count > i && items[i] != null)
                        ? items[i].AssociatedItemSO().sprite
                        : null;
                ListLocalInventorySlots[i].slotButton.onClick.RemoveAllListeners();
                if (items.Count > i)
                {
                    ItemSO tmpItem = ItemCollectionManager.GetItemSObyIndex(items[i].indexOfSOInCollection);
                
                    foreach (var item in ItemCollectionManager.allItems)
                    {
                        if (item.indexInCollection == tmpItem.indexInCollection)
                        {
                            var i1 = i;
                            ListLocalInventorySlots[i].slotButton.onClick.AddListener(() => OnRemoveOnItem((byte)i1));
                            break;
                        }
                    
                    }
                }

                
            }
        }
    }
}