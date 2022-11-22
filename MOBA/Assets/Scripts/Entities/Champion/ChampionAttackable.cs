using UnityEngine;
using Photon.Pun;

namespace Entities.Champion
{
    public partial class Champion : IAttackable
    {
        public bool canAttack;

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

        public void RequestAttack(byte capacityIndex, uint[] targetedEntities, Vector3[] targetedPositions) { }

        [PunRPC]
        public void SyncAttackRPC(byte capacityIndex, uint[] targetedEntities, Vector3[] targetedPositions) { }

        [PunRPC]
        public void AttackRPC(byte capacityIndex, uint[] targetedEntities, Vector3[] targetedPositions) { }

        public event GlobalDelegates.ByteUintArrayVector3ArrayDelegate OnAttack;
        public event GlobalDelegates.ByteUintArrayVector3ArrayDelegate OnAttackFeedback;
    }
}