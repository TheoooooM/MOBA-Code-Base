using UnityEngine;

namespace Entities.Capacities
{
    public class ActiveHealPotion : ActiveCapacity
    {
        private ActiveHealPotionSO so;
        private IActiveLifeable lifeable;

        public override bool TryCast(int entityIndex, int[] targets, Vector3[] position)
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

