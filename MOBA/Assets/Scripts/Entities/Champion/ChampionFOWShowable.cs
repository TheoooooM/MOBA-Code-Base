using System.Collections.Generic;
using Entities.FogOfWar;
using Photon.Pun;

namespace Entities.Champion
{
    public partial class Champion : IFOWShowable
    {
        public List<IFOWViewable> enemiesThatCanSeeMe = new List<IFOWViewable>();
        public Enums.Team[] enemyTeams;
        public bool canShow;
        public bool canHide;
        
        public bool CanShow()
        {
            return canShow;
        }

        public bool CanHide()
        {
            return canHide;
        }

        public void RequestSetCanShow(bool value)
        {
            photonView.RPC("SetCanShowRPC",RpcTarget.MasterClient,value);
        }

        [PunRPC]
        public void SyncSetCanShowRPC(bool value)
        {
            canShow = value;
            OnSetCanShowFeedback?.Invoke(value);
        }

        [PunRPC]
        public void SetCanShowRPC(bool value)
        {
            canShow = value;
            OnSetCanShow?.Invoke(value);
            photonView.RPC("SyncSetCanShowRPC",RpcTarget.All,value);
        }

        public event GlobalDelegates.BoolDelegate OnSetCanShow;
        public event GlobalDelegates.BoolDelegate OnSetCanShowFeedback;

        public void RequestSetCanHide(bool value)
        {
            photonView.RPC("SetCanHideRPC",RpcTarget.MasterClient,value);
            
        }

        [PunRPC]
        public void SyncSetCanHideRPC(bool value)
        {
            canHide = value;
            OnSetCanHideFeedback?.Invoke(value);
        }

        [PunRPC]
        public void SetCanHideRPC(bool value)
        {
            canHide = value;
            OnSetCanHide?.Invoke(value);
            photonView.RPC("SyncSetCanHideRPC",RpcTarget.All,value);
        }

        public event GlobalDelegates.BoolDelegate OnSetCanHide;
        public event GlobalDelegates.BoolDelegate OnSetCanHideFeedback;

        public void TryAddFOWViewable(uint viewableIndex)
        {
            
        }

        [PunRPC]
        public void ShowElementsRPC()
        {
            
        }

        public event GlobalDelegates.NoParameterDelegate ShowElement;
        public event GlobalDelegates.NoParameterDelegate ShowElementFeedback;

        public void TryRemoveFOWViewable(uint viewableIndex)
        {
            
        }

        [PunRPC]
        public void HideElementsRPC()
        {
            
        }

        public event GlobalDelegates.NoParameterDelegate HideElement;
        public event GlobalDelegates.NoParameterDelegate HideElementFeedback;
    }
}
