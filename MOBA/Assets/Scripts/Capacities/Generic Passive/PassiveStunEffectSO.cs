using System;

namespace Entities.Capacities
{
    public class PassiveStunEffectSO : PassiveCapacitySO
    {
        public float stunDuration;
    
        public override Type AssociatedType()
        {
            return typeof(PassiveStunEffect);
        }
    }
}
