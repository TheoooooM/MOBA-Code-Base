using System.Collections;
using System.Collections.Generic;
using Entities.Inventory;
using UnityEditor;
using UnityEngine;

public class WeaponItem : Item
{
    public override void OnItemAddedToInventory()
    {
        throw new System.NotImplementedException();
    }

    public override void OnItemRemovedInventory()
    {
    }

    public override ItemSO AssociatedItemSo()
    {
        return null;
    }
}
