using Entities;
using Entities.Capacities;
using GameStates;
using UnityEngine;

public class ActiveAutoAttack : ActiveCapacity
{
    
    private ActiveAutoAttackSO activeAutoAttackSO; 
    private float attackTimer;
    private uint target;
    
    public override ActiveCapacitySO AssociatedActiveCapacitySO()
    {
        return CapacitySOCollectionManager.Instance.GetActiveCapacitySOByName(activeAutoAttackSO.name);
    }

    public override bool TryCast(uint entityIndex, uint[] targets, Vector3[] direction)
    {
        //if the time since the last attack is lower than the attack speed or the target is not in range, return false
        if (!IsTargetInRange(entityIndex, targets[0]))
        {
            return false;
        }
        
        GameStateMachine.Instance.OnTick += DelayAutoAttack;

        target = targets[0];

        return true;
    }

    private bool IsTargetInRange(uint entityIndex, uint target)
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

    public override void PlayFeedback()
    {
        throw new System.NotImplementedException();
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
