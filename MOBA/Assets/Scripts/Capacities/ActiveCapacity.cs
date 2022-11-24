using GameStates;
using UnityEngine;

namespace Entities.Capacities
{
    public abstract class ActiveCapacity
    {
        public byte indexOfSOInCollection;
        public Entity caster;
        private float cooldownTimer;
        public bool onCooldown;

        protected int target;
        
        
        public ActiveCapacitySO AssociatedActiveCapacitySO()
        {
            return CapacitySOCollectionManager.GetActiveCapacitySOByIndex(indexOfSOInCollection);
        }

        public void InitiateCooldown()
        {
            cooldownTimer = AssociatedActiveCapacitySO().cooldown;
            GameStateMachine.Instance.OnTick += CooldownTimer;
        }

        private void CooldownTimer()
        {
            cooldownTimer -= GameStateMachine.Instance.tickRate;
            
            if (cooldownTimer <= 0)
            {
                onCooldown = false;
                GameStateMachine.Instance.OnTick -= CooldownTimer;
            }
        }

        public virtual bool TryCast(int casterIndex, int[] targetsEntityIndexes, Vector3[] targetPositions)
        {
            if (!onCooldown)
            {
                InitiateCooldown();

                if (targetsEntityIndexes.Length > 0)
                {
                    target = targetsEntityIndexes[0];
                    
                    if (!IsTargetInRange())
                    {
                        return false;
                    }
                }
                return true;
            }

            return false;
        }
        
        private bool IsTargetInRange()
        {
            //get the distance between the entity and the target
            float distance = Vector3.Distance(caster.transform.position, EntityCollectionManager.GetEntityByIndex(target).transform.position);
            //if the distance is lower than the range, return true
            if (distance < AssociatedActiveCapacitySO().maxRange)
            {
                return true;
            }
            return false;
        }

        public abstract void PlayFeedback(int casterIndex, int[] targetsEntityIndexes, Vector3[] targetPositions);
    }
}

