using GameStates;
using UnityEngine;

namespace Entities.Capacities
{
    public class ActiveTormentedShadow : ActiveCapacity
    {
        private Vector3 position;
        private ActiveTormentedShadowSO so;
        public float tickDamageTimer;
        public float durationTimer;
        
        public override ActiveCapacitySO AssociatedActiveCapacitySO()
        {
            return CapacitySOCollectionManager.Instance.GetActiveCapacitySOByName(so.name);
        }

        public override bool TryCast(uint entityIndex, uint[] targets, Vector3[] pos)
        {
            if (Vector3.Distance(pos[0], caster.transform.position) > so.maxRange) return false;
            
            so = (ActiveTormentedShadowSO)AssociatedActiveCapacitySO();
            
            ApplyDamage();

            GameStateMachine.Instance.OnTick += PoolOfShadow;
            
            position = pos[0];
            
            return true;
        }

        private void PoolOfShadow()
        {
            tickDamageTimer += GameStateMachine.Instance.tickRate;

            if (tickDamageTimer >= so.tickDamage)
            {
                ApplyDamage();
                tickDamageTimer = 0;
            }

            if (durationTimer >= so.activeDuration)
            {
                GameStateMachine.Instance.OnTick -= PoolOfShadow;
            }
        }

        private void ApplyDamage()
        {
            Collider[] detected = Physics.OverlapSphere(position, so.zoneRadius);

            foreach (var hit in detected)
            {
                Entity entityTouch = hit.GetComponent<Entity>();

                if (entityTouch)
                {
                    ITeamable entityTeam = entityTouch.GetComponent<ITeamable>();
                    ITeamable casterTeam = caster.GetComponent<ITeamable>();

                    if (entityTeam.GetTeam() != casterTeam.GetTeam())
                    {
                        IActiveLifeable entityActiveLifeable = entityTouch.GetComponent<IActiveLifeable>();

                        entityActiveLifeable.DecreaseCurrentHpRPC(so.damageAmount);
                    }
                }
            }
        }

        public override void PlayFeedback()
        {
            throw new System.NotImplementedException();
        }
    }
}

