using System;
using Entities.Capacities;
using UnityEngine;
using Photon.Pun;

namespace Entities.Champion
{
    public partial class Champion : ICastable
    {
        public byte[] abilitiesIndexes = new byte[2];
        public byte ultimateAbilityIndex;
        
        public bool canCast;

        public bool CanCast()
        {
            return canCast;
        }

        public void RequestSetCanCast(bool value) { }

        [PunRPC]
        public void SyncSetCanCastRPC(bool value) { }

        [PunRPC]
        public void SetCanCastRPC(bool value) { }

        public event GlobalDelegates.FloatDelegate OnSetCanCast;
        public event GlobalDelegates.FloatDelegate OnSetCanCastFeedback;

        public void RequestCast(byte capacityIndex, int[] targetedEntities, Vector3[] targetedPositions)
        {
            photonView.RPC("CastRPC",RpcTarget.MasterClient,capacityIndex,targetedEntities,targetedPositions);
        }
        
        [PunRPC]
        public void CastRPC(byte capacityIndex, int[] targetedEntities, Vector3[] targetedPositions)
        {
            var activeCapacity = CapacitySOCollectionManager.CreateActiveCapacity(capacityIndex,this);
            Debug.Log($"Trying to cast {activeCapacity.AssociatedActiveCapacitySO().name}");
            if (activeCapacity.TryCast(entityIndex, targetedEntities, targetedPositions))
            {
                photonView.RPC("SyncCastRPC",RpcTarget.All,capacityIndex,targetedEntities,targetedPositions);
            }
            
        }

        [PunRPC]
        public void SyncCastRPC(byte capacityIndex, int[] targetedEntities, Vector3[] targetedPositions)
        {
            var activeCapacity = CapacitySOCollectionManager.CreateActiveCapacity(capacityIndex,this);
            activeCapacity.PlayFeedback();
        }
        
        public event GlobalDelegates.ByteIntArrayVector3ArrayDelegate OnCast;
        public event GlobalDelegates.ByteIntArrayVector3ArrayDelegate OnCastFeedback;
    }
}