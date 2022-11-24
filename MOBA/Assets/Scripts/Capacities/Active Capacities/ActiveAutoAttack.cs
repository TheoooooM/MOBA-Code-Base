using Entities;
using Entities.Capacities;
using GameStates;
using UnityEngine;

public class ActiveAutoAttack : ActiveCapacity
{
    
    private ActiveAutoAttackSO activeAutoAttackSO; 
    private float attackTimer;
    private int target;

    public override bool TryCast(int casterIndex, int[] targets, Vector3[] direction)
    {
        //if the time since the last attack is lower than the attack speed or the target is not in range, return false
        if (!IsTargetInRange(casterIndex, targets[0]))
        {
            return false;
        }
        
        GameStateMachine.Instance.OnTick += DelayAutoAttack;

        target = targets[0];

        return true;
    }

    public override void PlayFeedback(int entityIndex, int[] targets, Vector3[] position)
    {
        throw new System.NotImplementedException();
    }

    private bool IsTargetInRange(int entityIndex, int target)
    {
        //get the distance between the entity and the target
        float distance = Vector3.Distance(EntityCollectionManager.GetEntityByIndex(entityIndex).transform.position, EntityCollectionManager.GetEntityByIndex(target).transform.position);
        //if the distance is lower than the range, return true
        if (distance < activeAutoAttackSO.range)
        {
            return true;
        }
        return false;
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
