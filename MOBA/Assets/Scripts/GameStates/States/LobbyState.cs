using Photon.Pun;

namespace GameStates.States
{
    public class LobbyState : GameState
    {
        public LobbyState(GameStateMachine sm) : base(sm) { }

        public override void StartState()
        {
            sm.RequestAddPlayer();
            InputManager.EnablePlayerUIMap(true);
        }

        public override void UpdateState() { }

        public override void ExitState()
        {
            InputManager.EnablePlayerMap(false);
            InputManager.EnablePlayerUIMap(false);
        }

        public override void OnAllPlayerReady()
        {
            sm.SwitchState(1);
        }
    }
}