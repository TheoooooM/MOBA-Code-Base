using UnityEngine;
using Photon.Pun;

namespace Entities.Champion
{
    public partial class Champion : ICastable
    {
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

        public void RequestCast(byte capacityIndex, uint[] targetedEntities, Vector3[] targetedPositions) { }

        [PunRPC]
        public void SyncCastRPC(byte capacityIndex, uint[] targetedEntities, Vector3[] targetedPositions) { }

        [PunRPC]
        public void CastRPC(byte capacityIndex, uint[] targetedEntities, Vector3[] targetedPositions) { }

        public event GlobalDelegates.ByteUintArrayVector3ArrayDelegate OnCast;
    }
}