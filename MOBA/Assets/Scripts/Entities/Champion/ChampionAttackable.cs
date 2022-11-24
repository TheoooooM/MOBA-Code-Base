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
        public void RequestSetAttackDamage(float value) { }

        public void SyncSetAttackDamageRPC(float value) { }

        public void SetAttackDamageRPC(float value) { }

        public event GlobalDelegates.FloatDelegate OnSetAttackDamage;
        public event GlobalDelegates.FloatDelegate OnSetAttackDamageFeedback;

        public void RequestAttack(byte capacityIndex, uint[] targetedEntities, Vector3[] targetedPositions) { }

        [PunRPC]
        public void SyncAttackRPC(byte capacityIndex, uint[] targetedEntities, Vector3[] targetedPositions) { }

        [PunRPC]
        public void AttackRPC(byte capacityIndex, uint[] targetedEntities, Vector3[] targetedPositions) { }

        public event GlobalDelegates.ByteUintArrayVector3ArrayDelegate OnAttack;
        public event GlobalDelegates.ByteUintArrayVector3ArrayDelegate OnAttackFeedback;
    }
}