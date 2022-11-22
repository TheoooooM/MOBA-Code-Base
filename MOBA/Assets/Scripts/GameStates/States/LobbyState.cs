using System.Collections.Generic;
using Photon.Pun;

namespace GameStates.States
{
    public class LobbyState : GameState
    {
        public LobbyState(GameStateMachine sm) : base(sm) { }
        

        public override void StartState()
        {
            sm.RequestAddPlayer();
        }

        public override void UpdateState()
        {
            if (!sm.IsMaster) return;
            if(IsEveryPlayerReady()) sm.SwitchState(1);
        }

        public override void ExitState()
        {
        }

        private bool IsEveryPlayerReady()
        {
            // Check si team choisie
            // Check si champion choisi
            // Tout le monde a validé ses choix
            return true;
        }

    }
}