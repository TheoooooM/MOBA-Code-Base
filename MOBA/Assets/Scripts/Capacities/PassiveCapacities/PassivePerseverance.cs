using GameStates;
using UnityEngine;

namespace Entities.Capacities
{
    public class PassivePerseverance : PassiveCapacity
    {
        private float timeSinceLastAttack;
        private float timeSinceLastHeal;
        private PassivePerseveranceSO passiveCapacitySo;
        private IActiveLifeable activeLifeable;
        
        public override PassiveCapacitySO AssociatedPassiveCapacitySO()
        {
            return ScriptableObject.CreateInstance<PassivePerseveranceSO>();
        }

        public override void OnAdded(Entity target)
        {
            base.OnAdded(target);

            passiveCapacitySo = (PassivePerseveranceSO)AssociatedPassiveCapacitySO();

            activeLifeable = entity.GetComponent<IActiveLifeable>();

            activeLifeable.OnDecreaseCurrentHp += ResetTimeSinceLastAttack;
            GameStateMachine.Instance.OnTick += IncreasePerTick;
        }

        private void ActiveHealEffect()
        {
            float maxHP = activeLifeable.GetMaxHp();
            float modAmount = maxHP * passiveCapacitySo.percentage;
            activeLifeable.IncreaseCurrentHpRPC(modAmount);
        }

        private void IncreasePerTick()
        {
            timeSinceLastAttack += GameStateMachine.Instance.tickRate;
            timeSinceLastHeal += GameStateMachine.Instance.tickRate;

            if (timeSinceLastAttack > passiveCapacitySo.timeBeforeHeal)
            {
                if (timeSinceLastHeal >= 5)
                {
                    ActiveHealEffect();
                    timeSinceLastHeal = 0;
                }
            }
        }

        private void ResetTimeSinceLastAttack(float f)
        {
            timeSinceLastAttack = 0;
        }

        public override void OnAddedFeedback()
        {
            base.OnAddedFeedback();
        }

        public override void OnRemoved()
        {
            base.OnRemoved();
            
            activeLifeable.OnDecreaseCurrentHp -= ResetTimeSinceLastAttack;
            GameStateMachine.Instance.OnTick -= IncreasePerTick;
        }

        public override void OnRemoveFeedback()
        {
            base.OnRemoveFeedback();
        }
    }

}
