using System.Collections.Generic;
using Entities.Capacities;
using Photon.Pun;
using UnityEngine;

namespace Entities
{
    [RequireComponent(typeof(PhotonView))]
    public abstract class Entity : MonoBehaviourPun
    {
        /// <summary>
        /// The viewID of the photonView of the entity.
        /// </summary>
        public uint entityIndex;

        /// <summary>
        /// True if passiveCapacities can be added to the entity's passiveCapacitiesList. False if not.
        /// </summary>
        [SerializeField] private bool canAddPassiveCapacity;

        /// <summary>
        /// True if passiveCapacities can be removed from the entity's passiveCapacitiesList. False if not.
        /// </summary>
        [SerializeField] private bool canRemovePassiveCapacity;

        /// <summary>
        /// The list of PassiveCapacity on the entity.
        /// </summary>
        public readonly List<PassiveCapacity> passiveCapacitiesList = new List<PassiveCapacity>();

        private void Start()
        {
            entityIndex = (uint) photonView.ViewID;
            EntityCollectionManager.AddEntity(this);

            OnStart();
        }

        /// <summary>
        /// Replaces the Start() method.
        /// </summary>
        protected abstract void OnStart();

        private void Update()
        {
            OnUpdate();
        }

        /// <summary>
        /// Replaces the Update() method.
        /// </summary>
        protected abstract void OnUpdate();

        #region MasterMethods

        public void SendSyncInstantiate(Vector3 position, Quaternion rotation)
        {
            photonView.RPC("SyncInstantiate", RpcTarget.All, position, rotation);    
        }
        
        [PunRPC]
        public void SyncInstantiate(Vector3 position, Quaternion rotation)
        {
            transform.position = position;
            transform.rotation = rotation;
        }

        /// <summary>
        /// Sends an RPC to the master to set the value canAddPassiveCapacity.
        /// </summary>
        /// <param name="value">The value to set canAddPassiveCapacity to</param>
        [PunRPC]
        private void SyncSetCanAddPassiveCapacityRPC(bool value)
        {
            photonView.RPC("SetCanAddPassiveCapacityRPC", RpcTarget.All, value);
        }

        /// <summary>
        /// Sets if passiveCapacities can be added to the entity's passiveCapacitiesList.
        /// </summary>
        /// <param name="value">true if they can, false if not</param>
        [PunRPC]
        private void SetCanAddPassiveCapacityRPC(bool value)
        {
            canAddPassiveCapacity = value;
        }

        /// <summary>
        /// Sends an RPC to the master to set the value canRemovePassiveCapacity.
        /// </summary>
        /// <param name="value">The value to set canRemovePassiveCapacity to</param>
        [PunRPC]
        private void SyncSetCanRemovePassiveCapacityRPC(bool value)
        {
            photonView.RPC("SetCanRemovePassiveCapacityRPC", RpcTarget.All, value);
        }

        /// <summary>
        /// Sets if passiveCapacities can be removed the entity's passiveCapacitiesList.
        /// </summary>
        /// <param name="value">true if they can, false if not</param>
        [PunRPC]
        private void SetCanRemovePassiveCapacityRPC(bool value)
        {
            canRemovePassiveCapacity = value;
        }

        /// <summary>
        /// Adds a PassiveCapacity to the passiveCapacityList.
        /// </summary>
        /// <param name="index">The index of the PassiveCapacitySO of the PassiveCapacity to add</param>
        [PunRPC]
        private void AddPassiveCapacityByCapacitySOIndexRPC(uint index)
        {
            if (!canAddPassiveCapacity) return;
            // TODO - link to CapacitySOCollectionManager
        }

        /// <summary>
        /// Removes a PassiveCapacity from the passiveCapacityList.
        /// </summary>
        /// <param name="index">The index in the passiveCapacityList of the PassiveCapacity to remove</param>
        [PunRPC]
        private void RemovePassiveCapacityByIndexRPC(uint index)
        {
            if (!canRemovePassiveCapacity) return;
            // TODO - link to CapacitySOCollectionManager
        }

        /// <summary>
        /// Sends an RPC to all clients to add a PassiveCapacity to the passiveCapacityList.
        /// </summary>
        /// <param name="capacity">The PassiveCapacity to add</param>
        public void SyncAddPassiveCapacity(PassiveCapacity capacity)
        {
            photonView.RPC("AddPassiveCapacityRPC", RpcTarget.All);
        }

        /// <summary>
        /// Sends an RPC to all clients to add a PassiveCapacity to the passiveCapacityList.
        /// </summary>
        /// <param name="capacitySO">The PassiveCapacitySO of the PassiveCapacity to add</param>
        public void SyncAddPassiveCapacity(PassiveCapacitySO capacitySO)
        {
            photonView.RPC("AddPassiveCapacityRPC", RpcTarget.All);
        }

        /// <summary>
        /// Sends an RPC to all clients to add a PassiveCapacity to the passiveCapacityList.
        /// </summary>
        /// <param name="index">The index in the CapacitySOCollectionManager of PassiveCapacity to add</param>
        public void SyncAddPassiveCapacity(uint index)
        {
            photonView.RPC("AddPassiveCapacityRPC", RpcTarget.All);
        }

        /// <summary>
        /// Sends an RPC to all clients to remove a PassiveCapacity from passiveCapacityList.
        /// </summary>
        /// <param name="capacity">The PassiveCapacity to remove</param>
        public void SyncRemovePassiveCapacity(PassiveCapacity capacity)
        {
            photonView.RPC("RemovePassiveCapacityRPC", RpcTarget.All);
        }

        /// <summary>
        /// Sends an RPC to all clients to remove a PassiveCapacity from passiveCapacityList.
        /// </summary>
        /// <param name="capacityIndex">The index in the CapacitySOCollectionManager of PassiveCapacity to remove</param>
        public void SyncRemovePassiveCapacity(uint capacityIndex)
        {
            photonView.RPC("RemovePassiveCapacityRPC", RpcTarget.All);
        }

        /// <summary>
        /// Sends an RPC to all clients to remove a PassiveCapacity from passiveCapacityList.
        /// </summary>
        /// <param name="index">The index in the passiveCapacitiesList of the PassiveCapacity to remove</param>
        public void SyncRemovePassiveCapacityByIndex(uint index)
        {
            photonView.RPC("RemovePassiveCapacityRPC", RpcTarget.All);
        }

        #endregion

        #region ClientMethods

        /// <summary>
        /// Sends an RPC to the master to set the value canAddPassiveCapacity.
        /// </summary>
        /// <param name="value">The value tu set canAddPassiveCapacity to</param>
        public void RequestSetCanAddPassiveCapacity(bool value)
        {
            photonView.RPC("SetCanAddPassiveCapacityRPC", RpcTarget.MasterClient, value);
        }

        /// <summary>
        /// Sends an RPC to the master to set the value canRemovePassiveCapacity.
        /// </summary>
        /// <param name="value">The value to set canRemovePassiveCapacity to</param>
        public void RequestSetCanRemovePassiveCapacity(bool value)
        {
            photonView.RPC("SyncSetCanRemovePassiveCapacityRPC", RpcTarget.MasterClient, value);
        }

        #endregion
    }
}