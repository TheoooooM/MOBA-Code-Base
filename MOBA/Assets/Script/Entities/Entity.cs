using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace Entities
{
    public abstract class Entity : MonoBehaviourPun
    {
        public uint entityIndex; // view ID of the entity

        public bool canAddPassiveCapacity;
        public bool canRemovePassiveCapacity;
        
        public readonly List<PassiveCapacity> passiveCapacitiesList = new List<PassiveCapacity>();
        
        private void Start()
        {
            entityIndex = (uint)photonView.ViewID;
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

        /// <summary>
        /// Adds a PassiveCapacity to the passiveCapacityList.
        /// </summary>
        /// <param name="index">The index of the PassiveCapacitySO of the PassiveCapacity to add</param>
        [PunRPC]
        private void AddPassiveCapacityByCapacitySOIndexRPC(uint index)
        {
            // TODO - link to CapacitySOCollectionManager
        }
        
        /// <summary>
        /// Removes a PassiveCapacity from the passiveCapacityList.
        /// </summary>
        /// <param name="index">The index in the passiveCapacityList of the PassiveCapacity to remove</param>
        [PunRPC]
        private void RemovePassiveCapacityByIndexRPC(uint index)
        {
            // TODO - link to CapacitySOCollectionManager
        }

        #endregion

        #region ClientMethods
        
        /// <summary>
        /// Sends an RPC to all clients to add a PassiveCapacity to the passiveCapacityList.
        /// </summary>
        /// <param name="capacity">The PassiveCapacity to add</param>
        public void RequestAddPassiveCapacity(PassiveCapacity capacity)
        {
            photonView.RPC("AddPassiveCapacityRPC",RpcTarget.MasterClient);
        }

        /// <summary>
        /// Sends an RPC to all clients to add a PassiveCapacity to the passiveCapacityList.
        /// </summary>
        /// <param name="capacitySO">The PassiveCapacitySO of the PassiveCapacity to add</param>
        public void RequestAddPassiveCapacity(PassiveCapacitySO capacitySO)
        {
            photonView.RPC("AddPassiveCapacityRPC",RpcTarget.MasterClient);
        }

        /// <summary>
        /// Sends an RPC to all clients to add a PassiveCapacity to the passiveCapacityList.
        /// </summary>
        /// <param name="index">The index in the CapacitySOCollectionManager of PassiveCapacity to add</param>
        public void RequestAddPassiveCapacity(uint index)
        {
            photonView.RPC("AddPassiveCapacityRPC",RpcTarget.MasterClient);
        }

        /// <summary>
        /// Sends an RPC to all clients to remove a PassiveCapacity from passiveCapacityList.
        /// </summary>
        /// <param name="capacity">The PassiveCapacity to remove</param>
        public void RequestRemovePassiveCapacity(PassiveCapacity capacity)
        {
            photonView.RPC("RemovePassiveCapacityRPC",RpcTarget.MasterClient);
        }
        
        /// <summary>
        /// Sends an RPC to all clients to remove a PassiveCapacity from passiveCapacityList.
        /// </summary>
        /// <param name="capacityIndex">The index in the CapacitySOCollectionManager of PassiveCapacity to remove</param>
        public void RequestRemovePassiveCapacity(uint capacityIndex)
        {
            photonView.RPC("RemovePassiveCapacityRPC",RpcTarget.MasterClient);
        }
        
        /// <summary>
        /// Sends an RPC to all clients to remove a PassiveCapacity from passiveCapacityList.
        /// </summary>
        /// <param name="index">The index in the passiveCapacitiesList of the PassiveCapacity to remove</param>
        public void RequestRemovePassiveCapacityByIndex(uint index)
        {
            photonView.RPC("RemovePassiveCapacityRPC",RpcTarget.MasterClient);
        }

        #endregion
    }
}
