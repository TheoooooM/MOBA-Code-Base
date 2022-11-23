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

        public List<IFOWShowable> SeenShowables() => seenShowables;

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

        public void AddShowable(uint seenEntityIndex)
        {
            var entity = EntityCollectionManager.GetEntityByIndex(seenEntityIndex);
            if(entity == null) return;
            
            var showable = entity.GetComponent<IFOWShowable>();
            if(showable == null) return;
            
            AddShowable(showable);
        }

        public void AddShowable(IFOWShowable showable)
        {
            if (seenShowables.Contains(showable)) return;
            
            seenShowables.Add(showable);
            showable.TryAddFOWViewable(this);
            
            var seenEntityIndex = ((Entity)showable).entityIndex;
            OnAddShowableFeedback?.Invoke(seenEntityIndex);
            
            if(!PhotonNetwork.IsMasterClient) return;
            OnAddShowable?.Invoke(seenEntityIndex);
            photonView.RPC("SyncAddShowableRPC",RpcTarget.All,seenEntityIndex);
        }

        [PunRPC]
        public void SyncAddShowableRPC(uint seenEntityIndex)
        {
            var entity = EntityCollectionManager.GetEntityByIndex(seenEntityIndex);
            if(entity == null) return;
            
            var showable = entity.GetComponent<IFOWShowable>();
            if(showable == null) return;
            if (seenShowables.Contains(showable)) return;
            
            seenShowables.Add(showable);
            OnAddShowableFeedback?.Invoke(seenEntityIndex);
            if(!PhotonNetwork.IsMasterClient) showable.TryAddFOWViewable(this);
        }
        
        public event GlobalDelegates.UintDelegate OnAddShowable;
        public event GlobalDelegates.UintDelegate OnAddShowableFeedback;

        public void RemoveShowable(uint seenEntityIndex)
        {
            var entity = EntityCollectionManager.GetEntityByIndex(seenEntityIndex);
            if(entity == null) return;
            
            var showable = entity.GetComponent<IFOWShowable>();
            if(showable == null) return;
            
            RemoveShowable(showable);
        }

        public void RemoveShowable(IFOWShowable showable)
        {
            if (!seenShowables.Contains(showable)) return;
            
            seenShowables.Add(showable);
            showable.TryRemoveFOWViewable(this);
            
            var seenEntityIndex = ((Entity)showable).entityIndex;
            OnRemoveShowableFeedback?.Invoke(seenEntityIndex);
            
            if(!PhotonNetwork.IsMasterClient) return;
            OnRemoveShowable?.Invoke(seenEntityIndex);
            photonView.RPC("SyncRemoveShowableRPC",RpcTarget.All,seenEntityIndex);
        }

        [PunRPC]
        public void SyncRemoveShowableRPC(uint seenEntityIndex)
        {
            var entity = EntityCollectionManager.GetEntityByIndex(seenEntityIndex);
            if(entity == null) return;
            
            var showable = entity.GetComponent<IFOWShowable>();
            if(showable == null) return;
            if (!seenShowables.Contains(showable)) return;
            
            seenShowables.Remove(showable);
            OnAddShowableFeedback?.Invoke(seenEntityIndex);
            if(!PhotonNetwork.IsMasterClient) showable.TryRemoveFOWViewable(this);
        }

        public event GlobalDelegates.UintDelegate OnRemoveShowable;
        public event GlobalDelegates.UintDelegate OnRemoveShowableFeedback;

    }
}