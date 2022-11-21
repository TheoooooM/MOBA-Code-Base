using Entities.FogOfWar;
using Entities.Inventory;
using Photon.Pun;
using UnityEngine;

namespace Entities.Champion
{
    public class Champion : Entity, IActiveLifeable, IAttackable, ICastable, IDeadable, ITargetable, IDisplaceable, IMoveable,
        IRessourceable, ITeamable, IFOWViewable, IFOWShowable, IInventoryable
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
        public byte attackAbilityIndex;
        public byte[] abilitiesIndexes = new byte[2];
        public byte ultimateAbilityIndex;
        
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
            photonView.RPC("SetMaxHpRPC",RpcTarget.MasterClient,value);
        }

        [PunRPC] public void SyncSetMaxHpRPC(float value)
        {
            maxHp = value;
        }

        [PunRPC] public void SetMaxHpRPC(float value)
        {
            maxHp = value;
            photonView.RPC("SyncSetMaxHpRPC",RpcTarget.All,maxHp);
        }

        public event GlobalDelegates.FloatDelegate OnSetMaxHp;

        public void RequestIncreaseMaxHp(float amount)
        {
            photonView.RPC("IncreaseMaxHpRPC",RpcTarget.MasterClient,amount);
        }

        [PunRPC] public void SyncIncreaseMaxHpRPC(float amount)
        {
            maxHp = amount;
        }

        [PunRPC] public void IncreaseMaxHpRPC(float amount)
        {
            maxHp -= amount;
            photonView.RPC("SyncSetMaxHpRPC",RpcTarget.MasterClient,maxHp);
        }

        public event GlobalDelegates.FloatDelegate OnIncreaseMaxHp;

        public void RequestDecreaseMaxHp(float amount)
        {
            photonView.RPC("DecreaseMaxHpRPC",RpcTarget.MasterClient,amount);
        }

        [PunRPC] public void SyncDecreaseMaxHpRPC(float amount)
        {
            maxHp = amount;
        }

        [PunRPC] public void DecreaseMaxHpRPC(float amount)
        {
            maxHp -= amount;
            photonView.RPC("SyncDecreaseMaxHpRPC",RpcTarget.MasterClient,maxHp);
        }

        public event GlobalDelegates.FloatDelegate OnDecreaseMaxHp;

        public void RequestSetCurrentHp(float value)
        {
            photonView.RPC("SetCurrentHpRPC",RpcTarget.MasterClient,value);
        }

        [PunRPC] public void SyncSetCurrentHpRPC(float value)
        {
            currentHp = value;
        }

        [PunRPC] public void SetCurrentHpRPC(float value)
        {
            currentHp = value;
            photonView.RPC("SyncSetCurrentHpRPC",RpcTarget.All,value);
        }

        public event GlobalDelegates.FloatDelegate OnSetCurrentHp;

        public void RequestSetCurrentHpPercent(float value)
        {
            photonView.RPC("SetCurrentHpPercentRPC",RpcTarget.All,value);
        }

        [PunRPC] public void SyncSetCurrentHpPercentRPC(float value)
        {
            currentHp = value;
        }

        [PunRPC] public void SetCurrentHpPercentRPC(float value)
        {
            currentHp = value * maxHp;
            photonView.RPC("SetCurrentHpPercentRPC",RpcTarget.All,value);
        }

        public event GlobalDelegates.FloatDelegate OnSetCurrentHpPercent;

        public void RequestIncreaseCurrentHp(float amount)
        {
            
        }

        [PunRPC] public void SyncIncreaseCurrentHpRPC(float amount)
        {
            
        }

        [PunRPC] public void IncreaseCurrentHpRPC(float amount)
        {
            
        }

        public event GlobalDelegates.FloatDelegate OnIncreaseCurrentHp;

        public void RequestDecreaseCurrentHp(float amount)
        {
            
        }

        [PunRPC] public void SyncDecreaseCurrentHpRPC(float amount)
        {
            
        }

        [PunRPC] public void DecreaseCurrentHpRPC(float amount)
        {
            
        }

        public event GlobalDelegates.FloatDelegate OnDecreaseCurrentHp;

        public bool CanAttack()
        {
            return canAttack;
        }

        public void RequestSetCanAttack(bool value)
        {
            
        }

        [PunRPC] public void SyncSetCanAttackRPC(bool value)
        {
            
        }

        [PunRPC] public void SetCanAttackRPC(bool value)
        {
            
        }

        public event GlobalDelegates.BoolDelegate OnSetCanAttack;

        public void RequestAttack(byte capacityIndex, uint[] targetedEntities, Vector3[] targetedPositions)
        {
            
        }

        [PunRPC] public void SyncAttackRPC(byte capacityIndex, uint[] targetedEntities, Vector3[] targetedPositions)
        {
            
        }

        [PunRPC] public void AttackRPC(byte capacityIndex, uint[] targetedEntities, Vector3[] targetedPositions)
        {
            
        }

        public event GlobalDelegates.ByteUintArrayVector3ArrayDelegate OnAttack;

        public bool CanCast()
        {
            return canCast;
        }

        public void RequestSetCanCast(bool value)
        {
            
        }

        [PunRPC] public void SyncSetCanCastRPC(bool value)
        {
            
        }

        [PunRPC] public void SetCanCastRPC(bool value)
        {
            
        }

        public event GlobalDelegates.FloatDelegate OnSetCanCast;

        public void RequestCast(byte capacityIndex, uint[] targetedEntities, Vector3[] targetedPositions)
        {
            
        }

        [PunRPC] public void SyncCastRPC(byte capacityIndex, uint[] targetedEntities, Vector3[] targetedPositions)
        {
            
        }

        [PunRPC] public void CastRPC(byte capacityIndex, uint[] targetedEntities, Vector3[] targetedPositions)
        {
            
        }

        public event GlobalDelegates.ByteUintArrayVector3ArrayDelegate OnCast;

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

        [PunRPC] public void SyncSetCanDieRPC(bool value)
        {
            
        }

        [PunRPC] public void SetCanDieRPC(bool value)
        {
            
        }

        public event GlobalDelegates.BoolDelegate OnSetCanDie;

        public void RequestDie()
        {
            
        }

        [PunRPC] public void SyncDieRPC()
        {
            
        }

        [PunRPC] public void DieRPC()
        {
            
        }

        public event GlobalDelegates.NoParameterDelegate OnDie;

        public void RequestRevive()
        {
            
        }

        [PunRPC] public void SyncReviveRPC()
        {
            
        }

        [PunRPC] public void ReviveRPC()
        {
            
        }

        public event GlobalDelegates.NoParameterDelegate OnRevive;

        public bool CanBeDisplaced()
        {
            return canBeDisplaced;
        }

        public void RequestSetCanBeDisplaced(bool value)
        {
            
        }

        [PunRPC] public void SyncSetCanBeDisplacedRPC(bool value)
        {
            
        }

        [PunRPC] public void SetCanBeDisplacedRPC(bool value)
        {
            
        }

        public event GlobalDelegates.BoolDelegate OnSetCanBeDisplaced;

        public void RequestDisplace()
        {
            
        }

        [PunRPC] public void SyncDisplaceRPC()
        {
            
        }

        [PunRPC] public void DisplaceRPC()
        {
            
        }

        public event GlobalDelegates.NoParameterDelegate OnDisplace;

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

        [PunRPC] public void SyncSetCanMoveRPC(bool value)
        {
            
        }

        [PunRPC] public void SetCanMoveRPC(bool value)
        {
            
        }

        public event GlobalDelegates.BoolDelegate OnSetCanMove;

        public void RequestSetReferenceMoveSpeed(float value)
        {
            
        }

        [PunRPC] public void SyncSetReferenceMoveSpeedRPC(float value)
        {
            
        }

        [PunRPC] public void SetReferenceMoveSpeedRPC(float value)
        {
            
        }

        public event GlobalDelegates.FloatDelegate OnSetReferenceMoveSpeed;

        public void RequestIncreaseReferenceMoveSpeed(float amount)
        {
            
        }

        [PunRPC] public void SyncIncreaseReferenceMoveSpeedRPC(float amount)
        {
            
        }

        [PunRPC] public void IncreaseReferenceMoveSpeedRPC(float amount)
        {
            
        }

        public event GlobalDelegates.FloatDelegate OnIncreaseReferenceMoveSpeed;

        public void RequestDecreaseReferenceMoveSpeed(float amount)
        {
            
        }

        [PunRPC] public void SyncDecreaseReferenceMoveSpeedRPC(float amount)
        {
            
        }

        [PunRPC] public void DecreaseReferenceMoveSpeedRPC(float amount)
        {
            
        }

        public event GlobalDelegates.FloatDelegate OnDecreaseReferenceMoveSpeed;

        public void RequestSetCurrentMoveSpeed(float value)
        {
            
        }

        [PunRPC] public void SyncSetCurrentMoveSpeedRPC(float value)
        {
            
        }

        [PunRPC] public void SetCurrentMoveSpeedRPC(float value)
        {
            
        }

        public event GlobalDelegates.FloatDelegate OnSetCurrentMoveSpeed;

        public void RequestIncreaseCurrentMoveSpeed(float amount)
        {
            
        }

        [PunRPC] public void SyncIncreaseCurrentMoveSpeedRPC(float amount)
        {
            
        }

        [PunRPC] public void IncreaseCurrentMoveSpeedRPC(float amount)
        {
            
        }

        public event GlobalDelegates.FloatDelegate OnIncreaseCurrentMoveSpeed;

        public void RequestDecreaseCurrentMoveSpeed(float amount)
        {
            
        }

        [PunRPC] public void SyncDecreaseCurrentMoveSpeedRPC(float amount)
        {
            
        }

        [PunRPC] public void DecreaseCurrentMoveSpeedRPC(float amount)
        {
            
        }

        public event GlobalDelegates.FloatDelegate OnDecreaseCurrentMoveSpeed;

        public void RequestMove(Vector3 position)
        {
            
        }

        [PunRPC] public void SyncMoveRPC(Vector3 position)
        {
            
        }

        [PunRPC] public void MoveRPC(Vector3 position)
        {
            
        }

        public event GlobalDelegates.Vector3Delegate OnMove;

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

        [PunRPC] public void SyncSetMaxRessourceRPC(float value)
        {
            
        }

        [PunRPC] public void SetMaxRessourceRPC(float value)
        {
            
        }

        public event GlobalDelegates.FloatDelegate OnSetMaxResource;

        public void RequestIncreaseMaxRessource(float amount)
        {
            
        }

        [PunRPC] public void SyncIncreaseMaxRessourceRPC(float amount)
        {
            
        }

        [PunRPC] public void IncreaseMaxRessourceRPC(float amount)
        {
            
        }

        public event GlobalDelegates.FloatDelegate OnIncreaseMaxResource;

        public void RequestDecreaseMaxRessource(float amount)
        {
            
        }

        [PunRPC] public void SyncDecreaseMaxRessourceRPC(float amount)
        {
            
        }

        [PunRPC] public void DecreaseMaxRessourceRPC(float amount)
        {
            
        }

        public event GlobalDelegates.FloatDelegate OnDecreaseMaxResource;

        public void RequestSetCurrentRessource(float value)
        {
            
        }

        [PunRPC] public void SyncSetCurrentRessourceRPC(float value)
        {
            
        }

        [PunRPC] public void SetCurrentRessourceRPC(float value)
        {
            
        }

        public event GlobalDelegates.FloatDelegate OnSetCurrentResource;

        public void RequestSetCurrentRessourcePercent(float value)
        {
            
        }

        [PunRPC] public void SyncSetCurrentRessourcePercentRPC(float value)
        {
            
        }

        [PunRPC] public void SetCurrentRessourcePercentRPC(float value)
        {
            
        }

        public event GlobalDelegates.FloatDelegate OnSetCurrentResourcePercent;

        public void RequestIncreaseCurrentRessource(float amount)
        {
            
        }

        [PunRPC] public void SyncIncreaseCurrentRessourceRPC(float amount)
        {
            
        }

        [PunRPC] public void IncreaseCurrentRessourceRPC(float amount)
        {
            
        }

        public event GlobalDelegates.FloatDelegate OnIncreaseCurrentResource;

        public void RequestDecreaseCurrentRessource(float amount)
        {
            
        }

        [PunRPC] public void SyncDecreaseCurrentRessourceRPC(float amount)
        {
            
        }

        [PunRPC] public void DecreaseCurrentRessourceRPC(float amount)
        {
            
        }

        public event GlobalDelegates.FloatDelegate OnDecreaseCurrentResource;

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

        [PunRPC] public void SyncChangeTeamRPC(bool value)
        {
            
        }

        [PunRPC] public void ChangeTeamRPC(bool value)
        {
            
        }

        public event GlobalDelegates.BoolDelegate OnChangeTeam;

        public float GetViewRange()
        {
            return viewRange;
        }

        public bool CanView()
        {
            throw new System.NotImplementedException();
        }

        public float GetFOWViewRange()
        {
            throw new System.NotImplementedException();
        }

        public float GetFOWBaseViewRange()
        {
            throw new System.NotImplementedException();
        }

        public void RequestSetCanView()
        {
            throw new System.NotImplementedException();
        }

        public void SyncSetCanViewRPC()
        {
            throw new System.NotImplementedException();
        }

        public void SetCanViewRPC()
        {
            throw new System.NotImplementedException();
        }

        public event GlobalDelegates.NoParameterDelegate OnSetCanView;

        public void RequestSetViewRange(float value)
        {
            
        }

        [PunRPC] public void SyncSetViewRangeRPC(float value)
        {
            
        }

        [PunRPC] public void SetViewRangeRPC(float value)
        {
            
        }

        public event GlobalDelegates.FloatDelegate OnSetViewRange;

        public void RequestSetBaseViewRange(float value)
        {
            throw new System.NotImplementedException();
        }

        public void SyncSetBaseViewRangeRPC(float value)
        {
            throw new System.NotImplementedException();
        }

        public void SetBaseViewRangeRPC(float value)
        {
            throw new System.NotImplementedException();
        }

        public event GlobalDelegates.FloatDelegate OnSetBaseViewRange;

        public void RequestAddFOWSeeable(uint FOWSeeableIndex)
        {
            throw new System.NotImplementedException();
        }

        public void SyncAddFOWSeeableRPC(uint FOWSeeableIndex)
        {
            throw new System.NotImplementedException();
        }

        public void AddFOWSeeableRPC(uint FOWSeeableIndex)
        {
            throw new System.NotImplementedException();
        }

        public event GlobalDelegates.UintDelegate OnAddFOWSeeable;

        public void RequestRemoveFOWSeeable(uint FOWSeeableIndex)
        {
            throw new System.NotImplementedException();
        }

        public void SyncRemoveFOWSeeableRPC(uint FOWSeeableIndex)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveFOWSeeableRPC(uint FOWSeeableIndex)
        {
            throw new System.NotImplementedException();
        }

        public event GlobalDelegates.UintDelegate OnRemoveFOWSeeable;

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

        [PunRPC] public void SyncAddItemRPC(byte index)
        {
            
        }

        [PunRPC] public void AddItemRPC(byte index)
        {
            
        }

        public event GlobalDelegates.ByteDelegate OnAddItem;

        public void RequestRemoveItem(byte index)
        {
            
        }

        public void RequestRemoveItem(Item item)
        {
            
        }

        [PunRPC] public void SyncRemoveItemRPC(byte index)
        {
            
        }

        [PunRPC] public void RemoveItemRPC(byte index)
        {
            
        }

        public event GlobalDelegates.ByteDelegate OnRemoveItem;

        public bool CanBeTargeted()
        {
            throw new System.NotImplementedException();
        }

        public void RequestSetCanBeTargeted(bool value)
        {
            throw new System.NotImplementedException();
        }

        [PunRPC] public void SyncSetCanBeTargetedRPC(bool value)
        {
            throw new System.NotImplementedException();
        }

        [PunRPC] public void SetCanBeTargetedRPC(bool value)
        {
            throw new System.NotImplementedException();
        }

        public event GlobalDelegates.BoolDelegate OnSetCanBeTargeted;

        public void RequestOnTargeted()
        {
            throw new System.NotImplementedException();
        }

        [PunRPC] public void SyncOnTargetedRPC()
        {
            throw new System.NotImplementedException();
        }

        [PunRPC] public void OnTargetedRPC()
        {
            throw new System.NotImplementedException();
        }

        public event GlobalDelegates.NoParameterDelegate OnOnTargeted;

        public void RequestOnUntargeted()
        {
            
        }

        [PunRPC] public void SyncOnUntargetedRPC()
        {
            
        }

        [PunRPC] public void OnUntargetedRPC()
        {
            
        }

        public event GlobalDelegates.NoParameterDelegate OnOnUntargeted;

        public void TryAddFOWViewable(IFOWViewable FOWWhichSee)
        {
            throw new System.NotImplementedException();
        }

        public void TryRemoveFOWViewable(IFOWViewable FOWWhichSee)
        {
            throw new System.NotImplementedException();
        }

        public void ShowElementsRPC()
        {
            throw new System.NotImplementedException();
        }

        public void HideElementsRPC()
        {
            throw new System.NotImplementedException();
        }
    }
}

