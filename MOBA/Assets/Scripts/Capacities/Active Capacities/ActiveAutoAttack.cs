using Entities;
using Entities.Capacities;
using GameStates;
using UnityEngine;

public class ActiveAutoAttack : ActiveCapacity
{
    
    private ActiveAutoAttackSO activeAutoAttackSO; 
    private double attackTimer;
    private int target;

    public override bool TryCast(int casterIndex, int[] targets, Vector3[] direction)
    {
        //if the time since the last attack is lower than the attack speed or the target is not in range, return false
        

        return true;
    }

    public override void PlayFeedback(int entityIndex, int[] targets, Vector3[] position)
    {
        throw new System.NotImplementedException();
    }

    


    private void ApplyEffect()
    {
        IActiveLifeable activeLifeable = EntityCollectionManager.GetEntityByIndex(target).GetComponent<IActiveLifeable>();
        activeLifeable.DecreaseCurrentHpRPC(activeAutoAttackSO.damage);
    }

    public void DelayAutoAttack()
    {
        attackTimer += GameStateMachine.Instance.tickRate;
        if (attackTimer >= activeAutoAttackSO.attackSpeed)
        {
            attackTimer = 0;
            ApplyEffect();
        }
    }
    
}
