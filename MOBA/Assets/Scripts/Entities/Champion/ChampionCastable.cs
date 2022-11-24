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

        public void RequestCast(byte capacityIndex, uint[] targetedEntities, Vector3[] targetedPositions)
        {
            photonView.RPC("CastRPC",RpcTarget.MasterClient,capacityIndex,targetedEntities,targetedPositions);
        }
        
        [PunRPC]
        public void CastRPC(byte capacityIndex, uint[] targetedEntities, Vector3[] targetedPositions)
        {
            Debug.Log($"Trying to cast ability at index {capacityIndex}");
        }

        [PunRPC]
        public void SyncCastRPC(byte capacityIndex, uint[] targetedEntities, Vector3[] targetedPositions)
        {
            
        }
        
        public event GlobalDelegates.ByteUintArrayVector3ArrayDelegate OnCast;
        public event GlobalDelegates.ByteUintArrayVector3ArrayDelegate OnCastFeedback;
    }
}