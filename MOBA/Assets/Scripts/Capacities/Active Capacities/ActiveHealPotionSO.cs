using System;

namespace Entities.Capacities
{
    public class ActiveHealPotionSO : ActiveCapacitySO
    {
        public float healAmount;

        public override Type AssociatedType()
        {
            return typeof(ActiveHealPotion);
        }
    }
}

