using System;
using System.Collections.Generic;
using Controllers.Inputs;
using Entities.Inventory;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private List<RectTransform> inventoriesPanel;

    private int[] inventoryIndex = { -1, -1, -1, -1 };

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            DestroyImmediate(gameObject);
            return;
        }

        Instance = this;
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