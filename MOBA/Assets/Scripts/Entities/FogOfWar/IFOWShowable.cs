namespace Entities.FogOfWar
{
    public interface IFOWShowable
    {
        public bool CanShow();
        public bool CanHide();

        public void RequestSetCanShow(bool value);
        public void SyncSetCanShowRPC(bool value);
        public void SetCanShowRPC(bool value);
        public event GlobalDelegates.BoolDelegate OnSetCanShow;
        public void RequestSetCanHide(bool value);
        public void SyncSetCanHideRPC(bool value);
        public void SetCanHideRPC(bool value);
        public event GlobalDelegates.BoolDelegate OnSetCanHide;
        public void TryAddFOWViewable(uint viewableIndex);
        public void ShowElementsRPC();
        public event GlobalDelegates.NoParameterDelegate ShowElement;

        public void TryRemoveFOWViewable(uint viewableIndex);
        public void HideElementsRPC();
        public event GlobalDelegates.NoParameterDelegate HideElement;

    }
}