using Entities;
using Entities.Capacities;
using GameStates;
using UnityEngine;

public class ActiveDarkMatter : ActiveCapacity
{
    private float timer;
    private ActiveDarkMatterSO activeCapacitySo;
    private Vector3[] dir;

    public override ActiveCapacitySO AssociatedActiveCapacitySO()
    {
        return CapacitySOCollectionManager.Instance.GetActiveCapacitySOByName(activeCapacitySo.name);
    }

    public override bool TryCast(uint entityIndex, uint[] targets, Vector3[] position)
    {
        if (Vector3.Distance(position[0], caster.transform.position) > activeCapacitySo.maxRange){return false;}
        
        activeCapacitySo = (ActiveDarkMatterSO)AssociatedActiveCapacitySO();
        
        GameStateMachine.Instance.OnTick += DelayWaitingTick;
        
        caster = EntityCollectionManager.GetEntityByIndex(entityIndex);
        dir = position;

        return true;
    }

    private void ApplyEffect()
    {
        ITeamable casterTeam = caster.GetComponent<ITeamable>();
        
        Collider[] detected = Physics.OverlapSphere(dir[0], activeCapacitySo.zoneRadius);

        foreach (var hit in detected)
        {
            Entity entityTouch = hit.GetComponent<Entity>();

            if (entityTouch)
            {
                ITeamable entityTeam = entityTouch.GetComponent<ITeamable>();

                if (entityTeam.GetTeam() != casterTeam.GetTeam())
                {
                    IActiveLifeable entityActiveLifeable = entityTouch.GetComponent<IActiveLifeable>();

                    entityActiveLifeable.DecreaseCurrentHpRPC( activeCapacitySo.damageAmount);
                }
            }
        }
    }

    private void DelayWaitingTick()
    {
        timer += GameStateMachine.Instance.tickRate;

        if (timer >=  activeCapacitySo.delay)
        {
            ApplyEffect();
            GameStateMachine.Instance.OnTick -= DelayWaitingTick;
        }
    }

    public override void PlayFeedback()
    {
    }
}
