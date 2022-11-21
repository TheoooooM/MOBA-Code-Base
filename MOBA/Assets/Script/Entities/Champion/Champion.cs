using System.Collections;
using System.Collections.Generic;
using Entities.FogOfWar;
using Entities.Inventory;
using UnityEditor.Searcher;
using UnityEngine;

namespace Entities.Champion
{
    public class Champion : Entity, IActiveLifeable, IAttackable, ICastable, IDeadable, IDisplaceable, IMoveable,
        IRessourceable, ITeamable, IFogOfWarViewable, IInventoryable
    {
        public ChampionSO championSo;

        public float maxHp;
        public float currentHp;
        public float maxRessource;
        public float currentRessource;
        public float viewRange;
        public bool isAlive;
        public float referenceMoveSpeed;
        public float currentMoveSpeed;
        
        public bool canAttack;
        public bool canCast;
        public bool canDie;
        public bool canMove;
        public bool canBeDisplaced;
        public bool canChangeTeam;
        
        public Enums.Team team;

        public Item[] items = new Item[3];
        
        protected override void OnStart()
        {
            
        }

        protected override void OnUpdate()
        {
            
        }

        public float GetMaxHp()
        {
            return maxHp;
        }

        public float GetCurrentHp()
        {
            return currentHp;
        }

        public float GetCurrentHpPercent()
        {
            return currentHp / maxHp * 100f;
        }

        public void RequestSetMaxHp(float value)
        {
            
        }

        public void SyncSetMaxHpRPC(float value)
        {
            
        }

        public void SetMaxHpRPC(float value)
        {
            
        }

        public void RequestIncreaseMaxHp(float amount)
        {
            
        }

        public void SyncIncreaseMaxHpRPC(float amount)
        {
            
        }

        public void IncreaseMaxHpRPC(float amount)
        {
            
        }

        public void RequestDecreaseMaxHp(float amount)
        {
            
        }

        public void SyncDecreaseMaxHpRPC(float amount)
        {
            
        }

        public void DecreaseMaxHpRPC(float amount)
        {
            
        }

        public void RequestSetCurrentHp(float value)
        {
            
        }

        public void SyncSetCurrentHpRPC(float value)
        {
            
        }

        public void SetCurrentHpRPC(float value)
        {
            
        }

        public void RequestSetCurrentHpPercent(float value)
        {
            
        }

        public void SyncSetCurrentHpPercentRPC(float value)
        {
            
        }

        public void SetCurrentHpRPCPercent(float value)
        {
            
        }

        public void RequestIncreaseCurrentHp(float amount)
        {
            
        }

        public void SyncIncreaseCurrentHpRPC(float amount)
        {
            
        }

        public void IncreaseCurrentHpRPC(float amount)
        {
            
        }

        public void RequestDecreaseCurrentHp(float amount)
        {
            
        }

        public void SyncDecreaseCurrentHpRPC(float amount)
        {
            
        }

        public void DecreaseCurrentHpRPC(float amount)
        {
            
        }

        public bool CanAttack()
        {
            return canAttack;
        }

        public void RequestSetCanAttack(bool value)
        {
            
        }

        public void SyncSetCanAttackRPC(bool value)
        {
            
        }

        public void SetCanAttackRPC(bool value)
        {
            
        }

        public void RequestAttack(byte capacityIndex, uint[] targetedEntities, Vector3[] targetedPositions)
        {
            
        }

        public void SyncAttackRPC(byte capacityIndex, uint[] targetedEntities, Vector3[] targetedPositions)
        {
            
        }

        public void AttackRPC(byte capacityIndex, uint[] targetedEntities, Vector3[] targetedPositions)
        {
            
        }

        public bool CanCast()
        {
            return canCast;
        }

        public void RequestSetCanCast(bool value)
        {
            
        }

        public void SyncSetCanCastRPC(bool value)
        {
            
        }

        public void SetCanCastRPC(bool value)
        {
            
        }

        public void RequestCast(byte capacityIndex, uint[] targetedEntities, Vector3[] targetedPositions)
        {
            
        }

        public void SyncCastRPC(byte capacityIndex, uint[] targetedEntities, Vector3[] targetedPositions)
        {
            
        }

        public void CastRPC(byte capacityIndex, uint[] targetedEntities, Vector3[] targetedPositions)
        {
            
        }

        public bool IsAlive()
        {
            return isAlive;
        }

        public bool CanDie()
        {
            return canDie;
        }

        public void RequestSetCanDie(bool value)
        {
            
        }

        public void SyncSetCanDieRPC(bool value)
        {
            
        }

        public void SetCanDieRPC(bool value)
        {
            
        }

        public void RequestDie()
        {
            
        }

        public void SyncDieRPC()
        {
            
        }

        public void DieRPC()
        {
            
        }

        public void RequestRevive()
        {
            
        }

        public void SyncReviveRPC()
        {
            
        }

        public void ReviveRPC()
        {
            
        }

        public bool CanBeDisplaced()
        {
            return canBeDisplaced;
        }

        public void RequestSetCanBeDisplaced(bool value)
        {
            
        }

        public void SyncSetCanBeDisplacedRPC(bool value)
        {
            
        }

        public void SetCanBeDisplacedRPC(bool value)
        {
            
        }

        public void RequestDisplace()
        {
            
        }

        public void SyncDisplaceRPC()
        {
            
        }

        public void DisplaceRPC()
        {
            
        }

        public bool CanMove()
        {
            return canMove;
        }

        public float GetReferenceMoveSpeed()
        {
            return referenceMoveSpeed;
        }

        public float GetCurrentMoveSpeed()
        {
            return currentMoveSpeed;
        }

        public void RequestSetCanMove(bool value)
        {
            
        }

        public void SyncSetCanMoveRPC(bool value)
        {
            
        }

        public void SetCanMoveRPC(bool value)
        {
            
        }

        public void RequestSetReferenceMoveSpeed(float value)
        {
            
        }

        public void SyncSetReferenceMoveSpeedRPC(float value)
        {
            
        }

        public void SetReferenceMoveSpeedRPC(float value)
        {
            
        }

        public void RequestIncreaseReferenceMoveSpeed(float amount)
        {
            
        }

        public void SyncIncreaseReferenceMoveSpeedRPC(float amount)
        {
            
        }

        public void IncreaseReferenceMoveSpeedRPC(float amount)
        {
            
        }

        public void RequestDecreaseReferenceMoveSpeed(float amount)
        {
            
        }

        public void SyncDecreaseReferenceMoveSpeedRPC(float amount)
        {
            
        }

        public void DecreaseReferenceMoveSpeedRPC(float amount)
        {
            
        }

        public void RequestSetCurrentMoveSpeed(float value)
        {
            
        }

        public void SyncSetCurrentMoveSpeedRPC(float value)
        {
            
        }

        public void SetCurrentMoveSpeedRPC(float value)
        {
            
        }

        public void RequestIncreaseCurrentMoveSpeed(float amount)
        {
            
        }

        public void SyncIncreaseCurrentMoveSpeedRPC(float amount)
        {
            
        }

        public void IncreaseCurrentMoveSpeedRPC(float amount)
        {
            
        }

        public void RequestDecreaseCurrentMoveSpeed(float amount)
        {
            
        }

        public void SyncDecreaseCurrentMoveSpeedRPC(float amount)
        {
            
        }

        public void DecreaseCurrentMoveSpeedRPC(float amount)
        {
            
        }

        public void RequestMove(Vector3 position)
        {
            
        }

        public void SyncMoveRPC(Vector3 position)
        {
            
        }

        public void MoveRPC(Vector3 position)
        {
            
        }

        public float GetMaxRessource()
        {
            return maxRessource;
        }

        public float GetCurrentRessource()
        {
            return currentRessource;
        }

        public float GetCurrentRessourcePercent()
        {
            return currentRessource / maxRessource * 100;
        }

        public void RequestSetMaxRessource(float value)
        {
            
        }

        public void SyncSetMaxRessourceRPC(float value)
        {
            
        }

        public void SetMaxRessourceRPC(float value)
        {
            
        }

        public void RequestIncreaseMaxRessource(float amount)
        {
            
        }

        public void SyncIncreaseMaxRessourceRPC(float amount)
        {
            
        }

        public void IncreaseMaxRessourceRPC(float amount)
        {
            
        }

        public void RequestDecreaseMaxRessource(float amount)
        {
            
        }

        public void SyncDecreaseMaxRessourceRPC(float amount)
        {
            
        }

        public void DecreaseMaxRessourceRPC(float amount)
        {
            
        }

        public void RequestSetCurrentRessource(float value)
        {
            
        }

        public void SyncSetCurrentRessourceRPC(float value)
        {
            
        }

        public void SetCurrentRessourceRPC(float value)
        {
            
        }

        public void RequestSetCurrentRessourcePercent(float value)
        {
            
        }

        public void SyncSetCurrentRessourcePercentRPC(float value)
        {
            
        }

        public void SetCurrentRessourceRPCPercent(float value)
        {
            
        }

        public void RequestIncreaseCurrentRessource(float amount)
        {
            
        }

        public void SyncIncreaseCurrentRessourceRPC(float amount)
        {
            
        }

        public void IncreaseCurrentRessourceRPC(float amount)
        {
            
        }

        public void RequestDecreaseCurrentRessource(float amount)
        {
            
        }

        public void SyncDecreaseCurrentRessourceRPC(float amount)
        {
            
        }

        public void DecreaseCurrentRessourceRPC(float amount)
        {
            
        }

        public Enums.Team GetTeam()
        {
            return team;
        }

        public bool CanChangeTeam()
        {
            return canChangeTeam;
        }

        public void RequestChangeTeam(bool value)
        {
            
        }

        public void SyncChangeTeamRPC(bool value)
        {
            
        }

        public void ChangeTeamRPC(bool value)
        {
            
        }

        public float GetViewRange()
        {
            return viewRange;
        }

        public void RequestSetViewRange(float value)
        {
            
        }

        public void SyncSetViewRangeRPC(float value)
        {
            
        }

        public void SetViewRangeRPC(float value)
        {
            
        }

        public Item[] GetItems()
        {
            return items;
        }

        public Item GetItem(int index)
        {
            if (index < 0 || index >= items.Length) return null;
            return items[index];
        }

        public void RequestAddItem(byte index)
        {
            
        }

        public void SyncAddItemRPC(byte index)
        {
            
        }

        public void AddItemRPC(byte index)
        {
            
        }

        public void RequestRemoveItem(byte index)
        {
            
        }

        public void RequestRemoveItem(Item item)
        {
            
        }

        public void SyncRemoveItemRPC(byte index)
        {
            
        }

        public void RemoveItemRPC(byte index)
        {
            
        }
    }
}

