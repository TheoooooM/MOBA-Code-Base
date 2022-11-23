using Photon.Pun;

namespace Entities.Champion
{
    public partial class Champion : IDeadable
    {
        public bool isAlive;
        public bool canDie;

        public bool IsAlive()
        {
            return isAlive;
        }

        public bool CanDie()
        {
            return canDie;
        }

        public void RequestSetCanDie(bool value) { }

        [PunRPC]
        public void SyncSetCanDieRPC(bool value) { }

        [PunRPC]
        public void SetCanDieRPC(bool value) { }

        public event GlobalDelegates.BoolDelegate OnSetCanDie;
        public event GlobalDelegates.BoolDelegate OnSetCanDieFeedback;

        public void RequestDie() { }

        [PunRPC]
        public void SyncDieRPC() { }

        [PunRPC]
        public void DieRPC() { }

        public event GlobalDelegates.NoParameterDelegate OnDie;
        public event GlobalDelegates.NoParameterDelegate OnDieFeedback;

        public void RequestRevive() { }

        [PunRPC]
        public void SyncReviveRPC() { }

        [PunRPC]
        public void ReviveRPC() { }

        public event GlobalDelegates.NoParameterDelegate OnRevive;
        public event GlobalDelegates.NoParameterDelegate OnReviveFeedback;
    }
}