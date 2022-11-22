using Entities.FogOfWar;
using Photon.Pun;

namespace Entities.Champion
{
    public partial class Champion : IFOWViewable
    {
        public float viewRange;

        public float GetViewRange()
        {
            return viewRange;
        }

        public bool CanView()
        {
            throw new System.NotImplementedException();
        }

        public float GetFOWViewRange()
        {
            throw new System.NotImplementedException();
        }

        public float GetFOWBaseViewRange()
        {
            throw new System.NotImplementedException();
        }

        public void RequestSetCanView() { }

        [PunRPC]
        public void SyncSetCanViewRPC() { }

        [PunRPC]
        public void SetCanViewRPC() { }

        public event GlobalDelegates.NoParameterDelegate OnSetCanView;

        public void RequestSetViewRange(float value) { }

        [PunRPC]
        public void SyncSetViewRangeRPC(float value) { }

        [PunRPC]
        public void SetViewRangeRPC(float value) { }

        public event GlobalDelegates.FloatDelegate OnSetViewRange;

        public void RequestSetBaseViewRange(float value) { }

        [PunRPC]
        public void SyncSetBaseViewRangeRPC(float value) { }

        [PunRPC]
        public void SetBaseViewRangeRPC(float value) { }

        public event GlobalDelegates.FloatDelegate OnSetBaseViewRange;

        public void RequestAddFOWSeeable(uint FOWSeeableIndex) { }

        [PunRPC]
        public void SyncAddFOWSeeableRPC(uint FOWSeeableIndex) { }

        [PunRPC]
        public void AddFOWSeeableRPC(uint FOWSeeableIndex) { }

        public event GlobalDelegates.UintDelegate OnAddFOWSeeable;

        public void RequestRemoveFOWSeeable(uint FOWSeeableIndex) { }

        [PunRPC]
        public void SyncRemoveFOWSeeableRPC(uint FOWSeeableIndex) { }

        [PunRPC]
        public void RemoveFOWSeeableRPC(uint FOWSeeableIndex) { }

        public event GlobalDelegates.UintDelegate OnRemoveFOWSeeable;

        public void TryAddFOWViewable(IFOWViewable FOWWhichSee) { }

        public void TryRemoveFOWViewable(IFOWViewable FOWWhichSee) { }
        public event GlobalDelegates.BoolDelegate OnSetCanShowFeedback;
        public event GlobalDelegates.BoolDelegate OnSetCanHideFeedback;
        public event GlobalDelegates.NoParameterDelegate ShowElementFeedback;
        public event GlobalDelegates.NoParameterDelegate HideElementFeedback;
    }
}