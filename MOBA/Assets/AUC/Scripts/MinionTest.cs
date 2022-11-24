using System;
using System.Collections;
using System.Collections.Generic;
using Entities;
using Entities.Capacities;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;

public class MinionTest : Entity, IMoveable, IAttackable
{
    #region MinionVariables
    
    private NavMeshAgent myAgent;
    private MinionController myController;
    
    [Header("Pathfinding")] 
    public List<Transform> myWaypoints = new List<Transform>();
    public List<Building> TowersList = new List<Building>();
    public int wayPointIndex;
    public int towerIndex;

    public enum minionAggroState { None, Tower, Minion, Champion };
    public enum minionAggroPreferences { Tower, Minion, Champion }
    [Header ("Attack Logic")]
    public minionAggroState currentAggroState = minionAggroState.None;
    public minionAggroPreferences whoAggro = minionAggroPreferences.Tower;
    public LayerMask enemyMinionMask;
    public GameObject currentAttackTarget;
    public List<GameObject> whoIsAttackingMe = new List<GameObject>();
    public bool attackCycle;

    [Header("Stats")]
    public int currentHealth;
    public int attackDamage;
    public float attackSpeed;
    [Range(5, 15)] public float attackRange;
    private int maxHealth;
    #endregion

    protected override void OnStart()
    {
        myAgent = GetComponent<NavMeshAgent>();
        myController = GetComponent<MinionController>();
        currentHealth = maxHealth;
    }
    
    protected override void OnUpdate()
    {
    }

    //------ State Methods

    public void IdleState()
    {
        myAgent.isStopped = true;
        CheckObjectives();
    }

    public void WalkingState()
    {
        CheckMyWayPoints();
        CheckObjectives();
        //CheckEnemiesMinion();
    }

    public void LookingForPathingState()
    {
        myAgent.SetDestination(myWaypoints[wayPointIndex].position);
        myController.currentState = MinionController.MinionState.Walking;
    }

    public void AttackingState()
    {
        if (TowersList[towerIndex].isAlive)
        {
            var q = Quaternion.LookRotation(currentAttackTarget.transform.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 50f * Time.deltaTime);

            if (attackCycle == false)
            {
                StartCoroutine(AttackLogic());
            }
        }
        else
        {
            myController.currentState = MinionController.MinionState.LookingForPathing;
            currentAggroState = minionAggroState.None;
            currentAttackTarget = null;
            towerIndex++;
        }
    }
    
    //------Others Methods
    
    private void CheckMyWayPoints()
    {
        if (Vector3.Distance(transform.position, myWaypoints[wayPointIndex].transform.position) <= myAgent.stoppingDistance /* Definir range de detection des waypoints en variable si besoin*/) 
        {
            if (wayPointIndex < myWaypoints.Count - 1)
            {
                wayPointIndex++;
                myAgent.SetDestination(myWaypoints[wayPointIndex].position);
            }
            else
            {
                myController.currentState = MinionController.MinionState.Idle;
            }
        }
    }
    
    private void CheckObjectives()
    {
        if (!TowersList[towerIndex].isAlive)
            return;
        
        if (Vector3.Distance(transform.position, TowersList[towerIndex].transform.position) > attackRange)
        {
            myController.currentState = MinionController.MinionState.Walking;
        }
        else
        {
            myAgent.SetDestination(transform.position);
            myController.currentState = MinionController.MinionState.Attacking;
            currentAggroState = minionAggroState.Tower;
            currentAttackTarget = TowersList[towerIndex].gameObject;
        }
    }
    
    private IEnumerator AttackLogic()
    {
        attackCycle = true;
        AttackTarget(currentAttackTarget);
        yield return new WaitForSeconds(attackSpeed);
        attackCycle = false;
    }
    
    private void AttackTarget(GameObject target) // Attaque de l'entité référencée 
    {
        Debug.Log("Attack");
        int[] targetEntity = new[] { target.GetComponent<Entity>().entityIndex };
        
        AttackRPC(2, targetEntity, Array.Empty<Vector3>() );
    }
    
    [PunRPC]
    public void AttackRPC(byte capacityIndex, int[] targetedEntities, Vector3[] targetedPositions)
    {
        var attackCapacity = CapacitySOCollectionManager.CreateActiveCapacity(capacityIndex,this);

        if (!attackCapacity.TryCast(entityIndex, targetedEntities, targetedPositions)) return;
            
        OnAttack?.Invoke(capacityIndex,targetedEntities,targetedPositions);
        photonView.RPC("SyncAttackRPC",RpcTarget.All,capacityIndex,targetedEntities,targetedPositions);
    }

    public event GlobalDelegates.ByteIntArrayVector3ArrayDelegate OnAttack;
    public event GlobalDelegates.ByteIntArrayVector3ArrayDelegate OnAttackFeedback;

    public bool CanAttack()
    {
        throw new System.NotImplementedException();
    }

    public void RequestSetCanAttack(bool value)
    {
        throw new System.NotImplementedException();
    }

    public void SetCanAttackRPC(bool value)
    {
        throw new System.NotImplementedException();
    }

    public void SyncSetCanAttackRPC(bool value)
    {
        throw new System.NotImplementedException();
    }

    public event GlobalDelegates.BoolDelegate OnSetCanAttack;
    public event GlobalDelegates.BoolDelegate OnSetCanAttackFeedback;
    public float GetAttackDamage()
    {
        throw new System.NotImplementedException();
    }

    public void RequestSetAttackDamage(float value)
    {
        throw new System.NotImplementedException();
    }

    public void SyncSetAttackDamageRPC(float value)
    {
        throw new System.NotImplementedException();
    }

    public void SetAttackDamageRPC(float value)
    {
        throw new System.NotImplementedException();
    }

    public event GlobalDelegates.FloatDelegate OnSetAttackDamage;
    public event GlobalDelegates.FloatDelegate OnSetAttackDamageFeedback;

    public void RequestAttack(byte capacityIndex, int[] targetedEntities, Vector3[] targetedPositions)
    {
        throw new System.NotImplementedException();
    }

    [PunRPC]
    public void SyncAttackRPC(byte capacityIndex, int[] targetedEntities, Vector3[] targetedPositions)
    {
        var attackCapacity = CapacitySOCollectionManager.CreateActiveCapacity(capacityIndex,this);
        attackCapacity.PlayFeedback(capacityIndex,targetedEntities,targetedPositions);
        OnAttackFeedback?.Invoke(capacityIndex,targetedEntities,targetedPositions);
    }
    
    //------
    
    public override void OnInstantiated()
    {
        throw new System.NotImplementedException();
    }

    public override void OnInstantiatedFeedback()
    {
        throw new System.NotImplementedException();
    }

    public bool CanMove()
    {
        throw new System.NotImplementedException();
    }

    public float GetReferenceMoveSpeed()
    {
        throw new System.NotImplementedException();
    }

    public float GetCurrentMoveSpeed()
    {
        throw new System.NotImplementedException();
    }

    public void RequestSetCanMove(bool value)
    {
        throw new System.NotImplementedException();
    }

    public void SyncSetCanMoveRPC(bool value)
    {
        throw new System.NotImplementedException();
    }

    public void SetCanMoveRPC(bool value)
    {
        throw new System.NotImplementedException();
    }

    public event GlobalDelegates.BoolDelegate OnSetCanMove;
    public event GlobalDelegates.BoolDelegate OnSetCanMoveFeedback;
    public void RequestSetReferenceMoveSpeed(float value)
    {
        throw new System.NotImplementedException();
    }

    public void SyncSetReferenceMoveSpeedRPC(float value)
    {
        throw new System.NotImplementedException();
    }

    public void SetReferenceMoveSpeedRPC(float value)
    {
        throw new System.NotImplementedException();
    }

    public event GlobalDelegates.FloatDelegate OnSetReferenceMoveSpeed;
    public event GlobalDelegates.FloatDelegate OnSetReferenceMoveSpeedFeedback;
    public void RequestIncreaseReferenceMoveSpeed(float amount)
    {
        throw new System.NotImplementedException();
    }

    public void SyncIncreaseReferenceMoveSpeedRPC(float amount)
    {
        throw new System.NotImplementedException();
    }

    public void IncreaseReferenceMoveSpeedRPC(float amount)
    {
        throw new System.NotImplementedException();
    }

    public event GlobalDelegates.FloatDelegate OnIncreaseReferenceMoveSpeed;
    public event GlobalDelegates.FloatDelegate OnIncreaseReferenceMoveSpeedFeedback;
    public void RequestDecreaseReferenceMoveSpeed(float amount)
    {
        throw new System.NotImplementedException();
    }

    public void SyncDecreaseReferenceMoveSpeedRPC(float amount)
    {
        throw new System.NotImplementedException();
    }

    public void DecreaseReferenceMoveSpeedRPC(float amount)
    {
        throw new System.NotImplementedException();
    }

    public event GlobalDelegates.FloatDelegate OnDecreaseReferenceMoveSpeed;
    public event GlobalDelegates.FloatDelegate OnDecreaseReferenceMoveSpeedFeedback;
    public void RequestSetCurrentMoveSpeed(float value)
    {
        throw new System.NotImplementedException();
    }

    public void SyncSetCurrentMoveSpeedRPC(float value)
    {
        throw new System.NotImplementedException();
    }

    public void SetCurrentMoveSpeedRPC(float value)
    {
        throw new System.NotImplementedException();
    }

    public event GlobalDelegates.FloatDelegate OnSetCurrentMoveSpeed;
    public event GlobalDelegates.FloatDelegate OnSetCurrentMoveSpeedFeedback;
    public void RequestIncreaseCurrentMoveSpeed(float amount)
    {
        throw new System.NotImplementedException();
    }

    public void SyncIncreaseCurrentMoveSpeedRPC(float amount)
    {
        throw new System.NotImplementedException();
    }

    public void IncreaseCurrentMoveSpeedRPC(float amount)
    {
        throw new System.NotImplementedException();
    }

    public event GlobalDelegates.FloatDelegate OnIncreaseCurrentMoveSpeed;
    public event GlobalDelegates.FloatDelegate OnIncreaseCurrentMoveSpeedFeedback;
    public void RequestDecreaseCurrentMoveSpeed(float amount)
    {
        throw new System.NotImplementedException();
    }

    public void SyncDecreaseCurrentMoveSpeedRPC(float amount)
    {
        throw new System.NotImplementedException();
    }

    public void DecreaseCurrentMoveSpeedRPC(float amount)
    {
        throw new System.NotImplementedException();
    }

    public event GlobalDelegates.FloatDelegate OnDecreaseCurrentMoveSpeed;
    public event GlobalDelegates.FloatDelegate OnDecreaseCurrentMoveSpeedFeedback;
    public void RequestMove(Vector3 position)
    {
        throw new System.NotImplementedException();
    }

    public void RequestMoveDir(Vector3 direction)
    {
        throw new System.NotImplementedException();
    }

    public void SyncMoveRPC(Vector3 position)
    {
        throw new System.NotImplementedException();
    }

    public void MoveRPC(Vector3 position)
    {
        throw new System.NotImplementedException();
    }

    public event GlobalDelegates.Vector3Delegate OnMove;
    public event GlobalDelegates.Vector3Delegate OnMoveFeedback;
}
