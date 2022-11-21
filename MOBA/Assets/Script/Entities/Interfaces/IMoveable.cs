using UnityEngine;

namespace Entities
{
    public interface IMoveable
    {
        /// <returns>true if the entity can move, false if not</returns>
        public bool CanMove();
        /// <returns>the entity's reference move speed</returns>
        public float GetReferenceMoveSpeed();
        /// <returns>the entity's current move speed</returns>
        public float GetCurrentMoveSpeed();
        
        /// <summary>
        /// Sends an RPC to the master to set if the entity can move.
        /// </summary>
        public void RequestSetCanMove(bool value);
        /// <summary>
        /// Sends an RPC to all clients to set if the entity can move.
        /// </summary>
        public void SyncSetCanMoveRPC(bool value);
        /// <summary>
        /// Sets if the entity can move.
        /// </summary>
        public void SetCanMoveRPC(bool value);
        
        /// <summary>
        /// Sends an RPC to the master to set the entity's reference move speed.
        /// </summary>
        /// <param name="value">the value to set it to</param>
        public void RequestSetReferenceMoveSpeed(float value);
        /// <summary>
        /// Sends an RPC to all clients to set the entity's reference move speed.
        /// </summary>
        /// <param name="value">the value to set it to</param>
        public void SyncSetReferenceMoveSpeedRPC(float value);
        /// <summary>
        /// Sets the entity's reference move speed.
        /// </summary>
        /// <param name="value">the value to set it to</param>
        public void SetReferenceMoveSpeedRPC(float value);
        
        /// <summary>
        /// Sends an RPC to the master to increase the entity's reference move speed.
        /// </summary>
        /// <param name="amount">the increase amount</param>
        public void RequestIncreaseReferenceMoveSpeed(float amount);
        /// <summary>
        /// Sends an RPC to all clients to increase the entity's reference move speed.
        /// </summary>
        /// <param name="amount">the increase amount</param>
        public void SyncIncreaseReferenceMoveSpeedRPC(float amount);
        /// <summary>
        /// Increases the entity's reference move speed.
        /// </summary>
        /// <param name="amount">the increase amount</param>
        public void IncreaseReferenceMoveSpeedRPC(float amount);
        
        /// <summary>
        /// Sends an RPC to the master to decrease the entity's reference move speed.
        /// </summary>
        /// <param name="amount">the decrease amount</param>
        public void RequestDecreaseReferenceMoveSpeed(float amount);
        /// <summary>
        /// Sends an RPC to all clients to decrease the entity's reference move speed.
        /// </summary>
        /// <param name="amount">the increase amount</param>
        public void SyncDecreaseReferenceMoveSpeedRPC(float amount);
        /// <summary>
        /// Decreases the entity's reference move speed.
        /// </summary>
        /// <param name="amount">the increase amount</param>
        public void DecreaseReferenceMoveSpeedRPC(float amount);
        
        /// <summary>
        /// Sends an RPC to the master to set the entity's current move speed.
        /// </summary>
        /// <param name="value">the value to set it to</param>
        public void RequestSetCurrentMoveSpeed(float value);
        /// <summary>
        /// Sends an RPC to all clients to set the entity's current move speed.
        /// </summary>
        /// <param name="value">the value to set it to</param>
        public void SyncSetCurrentMoveSpeedRPC(float value);
        /// <summary>
        /// Sets the entity's current move speed.
        /// </summary>
        /// <param name="value">the value to set it to</param>
        public void SetCurrentMoveSpeedRPC(float value);
        
        /// <summary>
        /// Sends an RPC to the master to increase the entity's current move speed.
        /// </summary>
        /// <param name="amount">the increase amount</param>
        public void RequestIncreaseCurrentMoveSpeed(float amount);
        /// <summary>
        /// Sends an RPC to all clients to increase the entity's current move speed.
        /// </summary>
        /// <param name="amount">the increase amount</param>
        public void SyncIncreaseCurrentMoveSpeedRPC(float amount);
        /// <summary>
        /// Increases the entity's current move speed.
        /// </summary>
        /// <param name="amount">the increase amount</param>
        public void IncreaseCurrentMoveSpeedRPC(float amount);
        
        /// <summary>
        /// Sends an RPC to the master to decrease the entity's current move speed.
        /// </summary>
        /// <param name="amount">the decrease amount</param>
        public void RequestDecreaseCurrentMoveSpeed(float amount);
        /// <summary>
        /// Sends an RPC to all clients to decrease the entity's current move speed.
        /// </summary>
        /// <param name="amount">the increase amount</param>
        public void SyncDecreaseCurrentMoveSpeedRPC(float amount);
        /// <summary>
        /// Decreases the entity's current move speed.
        /// </summary>
        /// <param name="amount">the increase amount</param>
        public void DecreaseCurrentMoveSpeedRPC(float amount);

        /// <summary>
        /// Sends an RPC to the master to move the entity.
        /// </summary>
        /// <param name="position">the position to move to</param>
        public void RequestMove(Vector3 position);
        /// <summary>
        /// Sends an RPC to all clients to move the entity.
        /// </summary>
        ///<param name="position">the position to move to</param>
        public void SyncMoveRPC(Vector3 position);
        /// <summary>
        /// Moves the entity.
        /// </summary>
        ///<param name="position">the position to move to</param>
        public void MoveRPC(Vector3 position);
    }
}