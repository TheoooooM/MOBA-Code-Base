using Entities;
using Entities.Capacities;
using GameStates;
using UnityEngine;

public class ActiveTowerAuto : ActiveCapacity
{
    private Entity _target;
    private Tower _tower;
    private double timer;
    

    public override bool TryCast(int casterIndex, int[] targetsEntityIndexes, Vector3[] targetPositions)
    {
        _tower = caster.GetComponent<Tower>();
        if (Vector3.Distance(_tower.transform.position, _target.transform.position) > _tower.detectionRange){return false;}
        
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

        if (timer >= _tower.delayBeforeAttack) 
        {
            ApplyEffect();
            GameStateMachine.Instance.OnTick -= DelayWaitingTick;
        }
    }
    
    private void ApplyEffect()
    {
        IActiveLifeable entityActiveLifeable = _target.GetComponent<IActiveLifeable>();
        entityActiveLifeable.DecreaseCurrentHpRPC(_tower.damage); 
    }
}
