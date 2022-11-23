using System;
using Entities.Capacities;

public class PassiveSlowEffectSO : PassiveCapacitySO
{
    public float slowAmount;
    
    public override Type AssociatedType()
    {
        return typeof(PassiveSlowEffect);
    }
}
