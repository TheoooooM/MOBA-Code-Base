using Entities;
using Entities.Capacities;
using GameStates;
using UnityEngine;

public class ActiveMinionAuto : ActiveCapacity
{
    private Entity _target;
    private MinionTest _minion;
    private float timer;
    
    public override bool TryCast(int casterIndex, int[] targetsEntityIndexes, Vector3[] targetPositions)
    {
        _minion = caster.GetComponent<MinionTest>();
        _target = _minion.currentAttackTarget.GetComponent<Entity>();
        
        
        if (Vector3.Distance(_minion.transform.position, _target.transform.position) > _minion.attackRange){return false;}
        
        GameStateMachine.Instance.OnTick += DelayWaitingTick;
        
        return true;
    }

    public override void PlayFeedback(int casterIndex, int[] targetsEntityIndexes, Vector3[] targetPositions)
    {
        throw new System.NotImplementedException();
    }
    
    private void DelayWaitingTick()
    {
        timer += GameStateMachine.Instance.tickRate;

        if (timer >= .4f) 
        {
            ApplyEffect();
            GameStateMachine.Instance.OnTick -= DelayWaitingTick;
        }
    }
    
    private void ApplyEffect()
    {
        IActiveLifeable entityActiveLifeable = _target.GetComponent<IActiveLifeable>();
        entityActiveLifeable.DecreaseCurrentHpRPC(_minion.attackDamage); 
    }
}