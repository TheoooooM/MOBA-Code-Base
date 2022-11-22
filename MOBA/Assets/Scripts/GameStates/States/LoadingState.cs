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
            
            // Envoie Scene is ready
        }

        public override void UpdateState()
        {
            if (!sm.IsMaster) return;
            
            if(IsEverySceneLoaded()) sm.SwitchState(2);
        }

        public override void ExitState() { }

        private bool IsEverySceneLoaded()
        {
            return true;
        }
        
    }
}