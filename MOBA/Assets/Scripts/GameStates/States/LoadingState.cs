namespace GameStates.States
{
    public class LoadingState : GameState
    {
        public LoadingState(GameStateMachine sm) : base(sm) { }

        public override void StartState()
        {
            // Load scene
            // Init pools
            // Init more stuff

            sm.SendToggleReady();
        }

        public override void UpdateState() { }

        public override void ExitState() { }

        public override void OnAllPlayerReady()
        {
            sm.SwitchState(2);
        }
    }
}