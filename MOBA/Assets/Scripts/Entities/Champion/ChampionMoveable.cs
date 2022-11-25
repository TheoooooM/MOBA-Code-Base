using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using Photon.Pun;
using UnityEngine.AI;


namespace Entities.Champion
{
    [RequireComponent(typeof(NavMeshAgent))]
    public partial class Champion : IMoveable
    {
        [Header("Movement")] public bool isBattlerite = true;
        public float referenceMoveSpeed;
        public float currentMoveSpeed;
        public float currentRotateSpeed;
        public bool canMove;
        private Vector3 moveDirection;

        // === League Of Legends
        private int mouseTargetIndex;
        private bool isFollowing;

        private Vector3 movePosition;
        //NavMesh

        private NavMeshAgent agent;

        public bool CanMove()
        {
            return canMove;
        }

        void SetupNavMesh()
        {
            agent = GetComponent<NavMeshAgent>();
            //NavMeshBuilder.ClearAllNavMeshes();
            //NavMeshBuilder.BuildNavMesh();
        }

        public float GetReferenceMoveSpeed()
        {
            return referenceMoveSpeed;
        }

        public float GetCurrentMoveSpeed()
        {
            return currentMoveSpeed;
        }

        public void RequestSetCanMove(bool value) { }

        [PunRPC]
        public void SyncSetCanMoveRPC(bool value) { }

        [PunRPC]
        public void SetCanMoveRPC(bool value) { }

        public event GlobalDelegates.BoolDelegate OnSetCanMove;
        public event GlobalDelegates.BoolDelegate OnSetCanMoveFeedback;

        public void RequestSetReferenceMoveSpeed(float value) { }

        [PunRPC]
        public void SyncSetReferenceMoveSpeedRPC(float value) { }

        [PunRPC]
        public void SetReferenceMoveSpeedRPC(float value) { }

        public event GlobalDelegates.FloatDelegate OnSetReferenceMoveSpeed;
        public event GlobalDelegates.FloatDelegate OnSetReferenceMoveSpeedFeedback;

        public void RequestIncreaseReferenceMoveSpeed(float amount) { }

        [PunRPC]
        public void SyncIncreaseReferenceMoveSpeedRPC(float amount) { }

        [PunRPC]
        public void IncreaseReferenceMoveSpeedRPC(float amount) { }

        public event GlobalDelegates.FloatDelegate OnIncreaseReferenceMoveSpeed;
        public event GlobalDelegates.FloatDelegate OnIncreaseReferenceMoveSpeedFeedback;

        public void RequestDecreaseReferenceMoveSpeed(float amount) { }

        [PunRPC]
        public void SyncDecreaseReferenceMoveSpeedRPC(float amount) { }

        [PunRPC]
        public void DecreaseReferenceMoveSpeedRPC(float amount) { }

        public event GlobalDelegates.FloatDelegate OnDecreaseReferenceMoveSpeed;
        public event GlobalDelegates.FloatDelegate OnDecreaseReferenceMoveSpeedFeedback;

        public void RequestSetCurrentMoveSpeed(float value) { }

        [PunRPC]
        public void SyncSetCurrentMoveSpeedRPC(float value) { }

        [PunRPC]
        public void SetCurrentMoveSpeedRPC(float value) { }

        public event GlobalDelegates.FloatDelegate OnSetCurrentMoveSpeed;
        public event GlobalDelegates.FloatDelegate OnSetCurrentMoveSpeedFeedback;

        public void RequestIncreaseCurrentMoveSpeed(float amount) { }

        [PunRPC]
        public void SyncIncreaseCurrentMoveSpeedRPC(float amount) { }

        [PunRPC]
        public void IncreaseCurrentMoveSpeedRPC(float amount) { }

        public event GlobalDelegates.FloatDelegate OnIncreaseCurrentMoveSpeed;
        public event GlobalDelegates.FloatDelegate OnIncreaseCurrentMoveSpeedFeedback;

        public void RequestDecreaseCurrentMoveSpeed(float amount) { }

        [PunRPC]
        public void SyncDecreaseCurrentMoveSpeedRPC(float amount) { }

        [PunRPC]
        public void DecreaseCurrentMoveSpeedRPC(float amount) { }

        public event GlobalDelegates.FloatDelegate OnDecreaseCurrentMoveSpeed;
        public event GlobalDelegates.FloatDelegate OnDecreaseCurrentMoveSpeedFeedback;

        #region Battlerite

        private void Move()
        {
            transform.position += moveDirection * (currentMoveSpeed * Time.deltaTime);
        }

        private void Rotate()
        {
            if (!photonView.IsMine) return;
            var ray = camera.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out var hit, float.PositiveInfinity)) return;

            var rotateDirection = -(transform.position - hit.point);
            rotateDirection.y = 0;
            
            transform.rotation = Quaternion.Lerp(transform.rotation,
                Quaternion.LookRotation(rotateDirection),
                Time.deltaTime * currentRotateSpeed);
        }

        public void SetMoveDirection(Vector3 direction)
        {
            moveDirection = direction;
        }

        #endregion

        #region League Of Legends

        public void MoveToPosition(Vector3 position)
        {
            movePosition = position;
            movePosition.y = transform.position.y;
            agent.SetDestination(position);
        }

        public void SendFollowEntity(int entityIndex)
        {
            photonView.RPC("FollowEntity", RpcTarget.All, entityIndex);
        }
        
        [PunRPC] public void StartFollowEntity(int entityIndex)
        {
            if (!photonView.IsMine) return;
            //follow
        }

        void FollowEntity()
        {
            
        }

        public void SendFollowEntity(int entityIndex)
        {
            photonView.RPC("FollowEntity", RpcTarget.All, entityIndex);
        }
        
        [PunRPC] public void StartFollowEntity(int entityIndex)
        {
            if (!photonView.IsMine) return;
            //follow
        }

        void FollowEntity()
        {
            
        }

        void CheckMoveDistance()
        {
            if (Vector3.Distance(transform.position, movePosition) < 0.5f)
            {
                agent.SetDestination(transform.position);
            }
        }

        #endregion

        public event GlobalDelegates.Vector3Delegate OnMove;
        public event GlobalDelegates.Vector3Delegate OnMoveFeedback;
    }
}