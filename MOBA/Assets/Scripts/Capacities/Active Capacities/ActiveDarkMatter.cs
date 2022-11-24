using Entities;
using Entities.Capacities;
using GameStates;
using UnityEngine;

public class ActiveDarkMatter : ActiveCapacity,IPrevisualisable
{
    private float timer;
    private ActiveDarkMatterSO activeCapacitySo;
    private Vector3[] dir;

    public override bool TryCast(int casterIndex, int[] targets, Vector3[] position)
    {
        activeCapacitySo = (ActiveDarkMatterSO)AssociatedActiveCapacitySO();
        
        if (Vector3.Distance(position[0], caster.transform.position) > activeCapacitySo.maxRange){return false;}
        
        GameStateMachine.Instance.OnTick += DelayWaitingTick;
        
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
    
    public override void PlayFeedback(int entityIndex, int[] targets, Vector3[] position)
    {
        Debug.Log("Test");
    }

    public void EnableDrawing()
    {
        throw new System.NotImplementedException();
    }

    public void DisableDrawing()
    {
        throw new System.NotImplementedException();
    }
}
