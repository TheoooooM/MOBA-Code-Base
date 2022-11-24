using Entities.Capacities;
using UnityEngine;
using Photon.Pun;

namespace Entities.Champion
{
    public partial class Champion : IAttackable
    {
        public byte attackAbilityIndex;
        public bool canAttack;
        public float attackDamage;

        public bool CanAttack()
        {
            return canAttack;
        }

        public void RequestSetCanAttack(bool value) { }

        [PunRPC]
        public void SyncSetCanAttackRPC(bool value) { }

        [PunRPC]
        public void SetCanAttackRPC(bool value) { }

        public event GlobalDelegates.BoolDelegate OnSetCanAttack;
        public event GlobalDelegates.BoolDelegate OnSetCanAttackFeedback;
        public float GetAttackDamage() => attackDamage;

        public void RequestSetAttackDamage(float value)
        {
            photonView.RPC("SetAttackDamageRPC",RpcTarget.MasterClient,value);
        }

        public void SetAttackDamageRPC(float value)
        {
            attackDamage = value;
            OnSetAttackDamage?.Invoke(value);
            photonView.RPC("SyncSetAttackDamageRPC",RpcTarget.All,attackDamage);
        }
        
        public void SyncSetAttackDamageRPC(float value)
        {
            attackDamage = value;
            OnSetAttackDamageFeedback?.Invoke(value);
        }
        
        public event GlobalDelegates.FloatDelegate OnSetAttackDamage;
        public event GlobalDelegates.FloatDelegate OnSetAttackDamageFeedback;

        public void RequestAttack(byte capacityIndex, int[] targetedEntities, Vector3[] targetedPositions)
        {
            photonView.RPC("AttackRPC",RpcTarget.MasterClient,capacityIndex,targetedEntities,targetedPositions);
        }

        [PunRPC]
        public void AttackRPC(byte capacityIndex, int[] targetedEntities, Vector3[] targetedPositions)
        {
            var attackCapacity = CapacitySOCollectionManager.CreateActiveCapacity(capacityIndex,this);

            if (!attackCapacity.TryCast(entityIndex, targetedEntities, targetedPositions)) return;
            
            OnAttack?.Invoke(capacityIndex,targetedEntities,targetedPositions);
            photonView.RPC("SyncAttackRPC",RpcTarget.All,capacityIndex,targetedEntities,targetedPositions);
        }
        
        [PunRPC]
        public void SyncAttackRPC(byte capacityIndex, int[] targetedEntities, Vector3[] targetedPositions)
        {
            var attackCapacity = CapacitySOCollectionManager.CreateActiveCapacity(capacityIndex,this);
            attackCapacity.PlayFeedback();
            OnAttackFeedback?.Invoke(capacityIndex,targetedEntities,targetedPositions);
        }

        public event GlobalDelegates.ByteIntArrayVector3ArrayDelegate OnAttack;
        public event GlobalDelegates.ByteIntArrayVector3ArrayDelegate OnAttackFeedback;
    }
}