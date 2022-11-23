using UnityEngine;

namespace Entities.Capacities
{
    public class ActiveHealPotion : ActiveCapacity
    {
        private ActiveHealPotionSO so;
        private IActiveLifeable lifeable;
        
        public override ActiveCapacitySO AssociatedActiveCapacitySO()
        {
            return CapacitySOCollectionManager.Instance.GetActiveCapacitySOByName(so.name);
        }

        public override bool TryCast(uint entityIndex, uint[] targets, Vector3[] position)
        {
            lifeable = caster.GetComponent<IActiveLifeable>();
            
            lifeable.IncreaseCurrentHpRPC(so.healAmount);
            
            return true;
        }

        public override void PlayFeedback()
        {
        }
    }
}

