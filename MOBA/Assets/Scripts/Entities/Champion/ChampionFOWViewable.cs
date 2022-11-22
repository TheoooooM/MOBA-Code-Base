using System.Collections.Generic;
using Entities.FogOfWar;
using Photon.Pun;

namespace Entities.Champion
{
    public partial class Champion : IFOWViewable
    {
        public float baseViewRange;
        public float viewRange;
        public bool canView;
        public List<IFOWShowable> seenShowables = new List<IFOWShowable>();

        public bool CanView() => canView;
        public float GetFOWViewRange() => viewRange;
        public float GetFOWBaseViewRange() => baseViewRange;
        public List<IFOWShowable> SeenShowables => seenShowables;
        public void RequestSetCanView(bool value)
        {
            photonView.RPC("SetCanViewRPC",RpcTarget.MasterClient,value);
        }

        [PunRPC]
        public void SyncSetCanViewRPC(bool value)
        {
            canView = value;
            OnSetCanViewFeedback?.Invoke(value);
        }

        [PunRPC]
        public void SetCanViewRPC(bool value)
        {
            canView = value;
            OnSetCanView?.Invoke(value);
            photonView.RPC("SetCanViewRPC",RpcTarget.All,value);
        }

        public event GlobalDelegates.BoolDelegate OnSetCanView;
        public event GlobalDelegates.BoolDelegate OnSetCanViewFeedback;

        public void RequestSetViewRange(float value)
        {
            photonView.RPC("SyncSetViewRangeRPC",RpcTarget.MasterClient,value);
        }

        [PunRPC]
        public void SyncSetViewRangeRPC(float value)
        {
            viewRange = value;
            OnSetViewRangeFeedback?.Invoke(value);
        }

        [PunRPC]
        public void SetViewRangeRPC(float value)
        {
            viewRange = value;
            OnSetViewRange?.Invoke(value);
            photonView.RPC("SyncSetViewRangeRPC",RpcTarget.All,value);
        }

        public event GlobalDelegates.FloatDelegate OnSetViewRange;
        public event GlobalDelegates.FloatDelegate OnSetViewRangeFeedback;

        public void RequestSetBaseViewRange(float value)
        {
            photonView.RPC("SetBaseViewRangeRPC",RpcTarget.MasterClient,value);
        }

        [PunRPC]
        public void SyncSetBaseViewRangeRPC(float value)
        {
            baseViewRange = value;
            OnSetBaseViewRangeFeedback?.Invoke(value);
        }

        [PunRPC]
        public void SetBaseViewRangeRPC(float value)
        {
            baseViewRange = value;
            OnSetBaseViewRange?.Invoke(value);
            photonView.RPC("SyncSetBaseViewRangeRPC",RpcTarget.All,value);
        }

        public event GlobalDelegates.FloatDelegate OnSetBaseViewRange;
        public event GlobalDelegates.FloatDelegate OnSetBaseViewRangeFeedback;

        public void RequestAddFOWSeeable(uint FOWSeeableIndex)
        {
            
        }

        [PunRPC]
        public void SyncAddFOWSeeableRPC(uint FOWSeeableIndex)
        {
            
        }

        [PunRPC]
        public void AddFOWSeeableRPC(uint FOWSeeableIndex)
        {
            
        }

        public event GlobalDelegates.UintDelegate OnAddFOWSeeable;
        public event GlobalDelegates.UintDelegate OnAddFOWSeeableFeedback;

        public void RequestRemoveFOWSeeable(uint FOWSeeableIndex) { }

        [PunRPC]
        public void SyncRemoveFOWSeeableRPC(uint FOWSeeableIndex) { }

        [PunRPC]
        public void RemoveFOWSeeableRPC(uint FOWSeeableIndex) { }

        public event GlobalDelegates.UintDelegate OnRemoveFOWSeeable;
        public event GlobalDelegates.UintDelegate OnRemoveFOWSeeableFeedback;

        public void TryAddFOWViewable(IFOWViewable FOWWhichSee)
        {
            
        }

        public void TryRemoveFOWViewable(IFOWViewable FOWWhichSee)
        {
            
        }

    }
}