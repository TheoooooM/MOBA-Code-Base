using System;
using System.Collections;
using System.Collections.Generic;
using Entities.Inventory;
using UnityEngine;

public class Bow : ItemSO
{
    public override Type GetAssociatedItemType()
    {
        return typeof(Bow);
    }
}
