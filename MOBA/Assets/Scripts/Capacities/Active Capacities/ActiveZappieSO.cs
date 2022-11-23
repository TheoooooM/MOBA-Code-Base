using System;
using Entities.Capacities;
using UnityEngine;

public class ActiveZappieSO : ActiveCapacitySO
{
    public GameObject projectile;
    public float damageAmount;
    public float speed;
    
    public override Type AssociatedType()
    {
        return typeof(ActiveZappie);
    }
}
