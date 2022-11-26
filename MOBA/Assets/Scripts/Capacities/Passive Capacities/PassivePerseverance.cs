using GameStates;
using Photon.Pun;
using UnityEngine;

namespace Entities.Capacities
{
    public class PassivePerseverance : PassiveCapacity
    {
        private double timeSinceLastAttack;
        private double timeSinceLastHeal;
        private PassivePerseveranceSO passiveCapacitySo;
        private IActiveLifeable activeLifeable;
        private GameObject particle = null;
        
        public override PassiveCapacitySO AssociatedPassiveCapacitySO()
        {
            return CapacitySOCollectionManager.Instance.GetPassiveCapacitySOByIndex(indexOfSo);
        }

        protected override void OnAddedEffects(Entity target)
        {
            
        }

        protected override void OnAddedFeedbackEffects(Entity target)
        {
            passiveCapacitySo = (PassivePerseveranceSO)AssociatedPassiveCapacitySO();

            activeLifeable = entity.GetComponent<IActiveLifeable>();

            activeLifeable.OnDecreaseCurrentHpFeedback += ResetTimeSinceLastAttack;
            GameStateMachine.Instance.OnTickFeedback += IncreasePerTick;
        }

        protected override void OnRemovedEffects(Entity target)
        {
            
        }

        protected override void OnRemovedFeedbackEffects(Entity target)
        {
            activeLifeable.OnDecreaseCurrentHpFeedback -= ResetTimeSinceLastAttack;
            GameStateMachine.Instance.OnTickFeedback -= IncreasePerTick;
            if(particle == null) return;
            particle.gameObject.SetActive(false);
        }

        private void ActiveHealEffect()
        {
            var maxHP = activeLifeable.GetMaxHp();
            var modAmount = maxHP * passiveCapacitySo.percentage;
            if(PhotonNetwork.IsMasterClient) activeLifeable.IncreaseCurrentHpRPC(modAmount);
            if(particle != null) return;
            particle = PoolLocalManager.Instance.PoolInstantiate(((PassivePerseveranceSO)AssociatedPassiveCapacitySO()).healEffectPrefab, entity.transform.position, Quaternion.identity,
                entity.transform);
        }

        private void IncreasePerTick()
        {
            timeSinceLastAttack += GameStateMachine.Instance.tickRate;
            timeSinceLastHeal += GameStateMachine.Instance.tickRate;
            if (!(timeSinceLastAttack > passiveCapacitySo.timeBeforeHeal)) return;
            if (!(timeSinceLastHeal >= 5)) return;
            ActiveHealEffect();
            timeSinceLastHeal = 0;
        }

        private void ResetTimeSinceLastAttack(float f)
        {
            timeSinceLastAttack = 0;
            if(particle == null) return;
            particle.gameObject.SetActive(false);
        }
    }

}
