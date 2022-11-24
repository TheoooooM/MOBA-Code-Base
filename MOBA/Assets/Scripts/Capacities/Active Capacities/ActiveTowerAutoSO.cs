using System;
using Entities.Capacities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTowerAutoSO : ActiveCapacitySO
{
    public float damage;
    
    public override Type AssociatedType()
    {
        return typeof(ActiveTowerAuto);
    }
}
