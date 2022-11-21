using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace Entities
{
    public class EntityCollectionManager : MonoBehaviourPun
    {
        private static readonly Dictionary<uint, Entity> allEntitiesDict = new Dictionary<uint, Entity>();

        private static PhotonView view;

        private void Start()
        {
            view = GetComponent<PhotonView>();
            allEntitiesDict.Clear();
        }

        
        /// <summary>
        /// Returns the entity corresponding to the index.
        /// </summary>
        /// <param name="index">Key of the Entity in the allEntitiesDict</param>
        /// <returns>The entity which corresponds to the index, or null if the index is invalid</returns>
        public static Entity GetEntityByIndex(uint index)
        {
            return !allEntitiesDict.ContainsKey(index) ? null : allEntitiesDict[index];
        }

        /// <summary>
        /// Adds an entity to the allEntitiesDict, with its entityIndex as its key.
        /// </summary>
        /// <param name="entity">The entity to add</param>
        public static void AddEntity(Entity entity)
        {
            var index = (uint) entity.entityIndex;
            if (allEntitiesDict.ContainsKey(index))
            {
                allEntitiesDict[index] = entity;
                return;
            }

            allEntitiesDict.Add(index, entity);
        }

        /// <summary>
        /// Removes an entity from the allEntitiesDict.
        /// </summary>
        /// <param name="index">The entityIndex of the entity to remove</param>
        [PunRPC]
        public static void RemoveEntityByIndexRPC(uint index)
        {
            if (allEntitiesDict.ContainsKey(index)) allEntitiesDict.Remove(index);
        }

        #region MasterMethods

        /// <summary>
        /// Sends an RPC to all clients to remove an entity from the allEntitiesDict.
        /// </summary>
        /// <param name="entity">The entity to remove</param>
        public static void RemoveEntity(Entity entity)
        {
            view.RPC("RemoveEntityByIndexRPC", RpcTarget.All, (uint) entity.entityIndex);
        }

        /// <summary>
        /// Sends an RPC to all clients to remove an entity from the allEntitiesDict.
        /// </summary>
        /// <param name="index">The entityIndex of the entity to remove</param>
        public static void RemoveEntity(uint index)
        {
            view.RPC("RemoveEntityByIndexRPC", RpcTarget.All, index);
        }

        #endregion
    }
}