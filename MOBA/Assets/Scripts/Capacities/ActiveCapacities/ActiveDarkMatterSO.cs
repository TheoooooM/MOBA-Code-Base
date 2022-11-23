using Entities;
using Entities.Capacities;
using GameStates;
using UnityEngine;


[CreateAssetMenu(menuName = "Capacity/ActiveCapacitySO/Dark Matter", fileName = "new Dark Matter")]
public class ActiveDarkMatterSO : ActiveCapacitySO
{
    public float zoneRadius;
    public float damageAmount;
    public float delay;
    private float timer;
    private Entity caster;
    private Vector3[] dir;
    
    public override void TryCast(uint entityIndex, uint[] targets, Vector3[] direction)
    {
        GameStateMachine.Instance.OnTick += DelayWaitingTick;
        
        caster = EntityCollectionManager.GetEntityByIndex(entityIndex);
        dir = direction;
    }

    private void ApplyEffect()
    {
        ITeamable casterTeam = caster.GetComponent<ITeamable>();
        
        Collider[] detected = Physics.OverlapSphere(dir[0], zoneRadius);

        foreach (var hit in detected)
        {
            Entity entityTouch = hit.GetComponent<Entity>();

            if (entityTouch)
            {
                ITeamable entityTeam = entityTouch.GetComponent<ITeamable>();

                if (entityTeam.GetTeam() != casterTeam.GetTeam())
                {
                    IActiveLifeable entityActiveLifeable = entityTouch.GetComponent<IActiveLifeable>();

                    entityActiveLifeable.DecreaseCurrentHpRPC(damageAmount);
                }
            }
        }
    }

    private void DelayWaitingTick()
    {
        timer += GameStateMachine.Instance.tickRate;

        if (timer >= delay)
        {
            ApplyEffect();
        }
    }

    public override void PlayFeedback()
    {
        throw new System.NotImplementedException();
    }
}
