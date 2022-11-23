using System;
using System.Collections;
using System.Collections.Generic;
using Entities.Capacities;
using UnityEngine;

[CreateAssetMenu(menuName = "Capacity/ActiveCapacitySO/Auto Attack", fileName = "new Auto Attack")]
public class ActiveAutoAttackSO : ActiveCapacitySO
{
    public float range;
    public float damage;
    public float attackSpeed;
    
    public override Type AssociatedType()
    {
        return typeof(ActiveCapacitySO);
    }
}