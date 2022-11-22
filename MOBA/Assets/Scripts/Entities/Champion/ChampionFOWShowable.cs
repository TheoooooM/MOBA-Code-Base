using Entities.FogOfWar;
using Photon.Pun;

namespace Entities.Champion
{
    public partial class Champion : IFOWShowable
    {
        public bool CanShow()
        {
            throw new System.NotImplementedException();
        }

        public bool CanHide()
        {
            throw new System.NotImplementedException();
        }

        public void RequestSetCanShow(bool value) { }

        [PunRPC]
        public void SyncSetCanShowRPC(bool value) { }

        [PunRPC]
        public void SetCanShowRPC(bool value) { }

        public event GlobalDelegates.BoolDelegate OnSetCanShow;

        public void RequestSetCanHide(bool value) { }

        [PunRPC]
        public void SyncSetCanHideRPC(bool value) { }

        [PunRPC]
        public void SetCanHideRPC(bool value) { }

        public event GlobalDelegates.BoolDelegate OnSetCanHide;

        public void TryAddFOWViewable(uint viewableIndex) { }

        [PunRPC]
        public void ShowElementsRPC() { }

        public event GlobalDelegates.NoParameterDelegate ShowElement;

        public void TryRemoveFOWViewable(uint viewableIndex) { }

        [PunRPC]
        public void HideElementsRPC() { }

        public event GlobalDelegates.NoParameterDelegate HideElement;
        public event GlobalDelegates.NoParameterDelegate OnSetCanViewFeedback;
        public event GlobalDelegates.FloatDelegate OnSetViewRangeFeedback;
        public event GlobalDelegates.FloatDelegate OnSetBaseViewRangeFeedback;
        public event GlobalDelegates.UintDelegate OnAddFOWSeeableFeedback;
        public event GlobalDelegates.UintDelegate OnRemoveFOWSeeableFeedback;
    }
}