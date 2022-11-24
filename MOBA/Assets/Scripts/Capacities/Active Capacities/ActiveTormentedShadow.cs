using GameStates;
using UnityEngine;

namespace Entities.Capacities
{
    public class ActiveTormentedShadow : ActiveCapacity
    {
        private Vector3 position;
        public ActiveTormentedShadowSO so;
        public float tickDamageTimer;
        public float durationTimer;
        
        public override bool TryCast(int entityIndex, int[] targets, Vector3[] pos)
        {
            so = (ActiveTormentedShadowSO)AssociatedActiveCapacitySO();
            Debug.Log($"Caster is {caster.name}, so is {so.name}");
            Debug.Log($"Transform is {caster.transform}, at position {caster.transform.position}");
            Debug.Log($"MaxRange is {so.maxRange}");
            Debug.Log($"Pos is {pos[0]} ");
            if (Vector3.Distance(pos[0], caster.transform.position) > so.maxRange) return false;

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
            Debug.Log("Morgana Gaming");
        }
    }
}

