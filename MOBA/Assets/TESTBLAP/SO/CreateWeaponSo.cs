using System;
using System.Collections;
using System.Collections.Generic;
using Entities.Inventory;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemSO", fileName = "new ItemSO")]
public class CreateWeaponSo : ItemSO
{
    public override Type GetAssociatedItemType()
    {
        return typeof(CreateWeaponSo);
    }
}
