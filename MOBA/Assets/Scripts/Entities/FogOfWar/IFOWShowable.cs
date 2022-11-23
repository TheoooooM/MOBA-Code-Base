using System.Collections.Generic;
using UnityEngine;

namespace Entities.FogOfWar
{
    public interface IFOWShowable : ITeamable
    {
        public bool CanShow();
        public bool CanHide();

        public void RequestSetCanShow(bool value);
        public void SyncSetCanShowRPC(bool value);
        public void SetCanShowRPC(bool value);
        public event GlobalDelegates.BoolDelegate OnSetCanShow;
        public event GlobalDelegates.BoolDelegate OnSetCanShowFeedback;
        public void RequestSetCanHide(bool value);
        public void SyncSetCanHideRPC(bool value);
        public void SetCanHideRPC(bool value);
        public event GlobalDelegates.BoolDelegate OnSetCanHide;
        public event GlobalDelegates.BoolDelegate OnSetCanHideFeedback;
        public void TryAddFOWViewable(uint viewableIndex);
        public void TryAddFOWViewable(IFOWViewable viewable);
        public void SyncTryAddViewableRPC(uint viewableIndex,bool show);
        public void ShowElements();
        public event GlobalDelegates.NoParameterDelegate OnShowElement;
        public event GlobalDelegates.NoParameterDelegate OnShowElementFeedback;

        public void TryRemoveFOWViewable(uint viewableIndex);
        public void TryRemoveFOWViewable(IFOWViewable viewable);
        public void SyncTryRemoveViewableRPC(uint viewableIndex,bool hide);
        public void HideElements();
        public event GlobalDelegates.NoParameterDelegate OnHideElement;
        public event GlobalDelegates.NoParameterDelegate OnHideElementFeedback;

    }
}