namespace GameStates.States
{
    public class LobbyState : GameState
    {
        public LobbyState(GameStateMachine sm) : base(sm) { }

        public override void StartState()
        {
            sm.RequestAddPlayer();
        }

        public override void UpdateState() { }

        public override void ExitState() { }

        public override void OnAllPlayerReady()
        {
            sm.SwitchState(1);
        }
    }
}