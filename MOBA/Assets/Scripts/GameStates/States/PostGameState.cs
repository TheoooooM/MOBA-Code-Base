namespace GameStates.States
{
    public class PostGameState : GameState
    {
        public PostGameState(GameStateMachine sm) : base(sm) { }

        public override void StartState()
        {
        }

        public override void UpdateState()
        {
            if (!sm.IsMaster) return;
            
            if(IsEveryPlayerReadyForRematch()) sm.SwitchState(1);
        }

        public override void ExitState()
        {
        }

        private bool IsEveryPlayerReadyForRematch()
        {
            return false;
        }

    }
}