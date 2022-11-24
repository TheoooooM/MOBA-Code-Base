using UnityEngine;

namespace Entities.Capacities
{
    public class ActiveHealPotion : ActiveCapacity
    {
        private ActiveHealPotionSO so;
        private IActiveLifeable lifeable;

        public override bool TryCast(int casterIndex, int[] targets, Vector3[] position)
        {
            so = (ActiveHealPotionSO)AssociatedActiveCapacitySO();
            Debug.Log("try cast heal potion");
            lifeable = caster.GetComponent<IActiveLifeable>();
            
            lifeable.IncreaseCurrentHpRPC(so.healAmount);
            
            return true;
        }

        public override void PlayFeedback(int entityIndex, int[] targets, Vector3[] position)
        {
            Debug.Log("Play the potion feedback");
        }
    }
}

