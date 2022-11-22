using Photon.Pun;

namespace GameStates.States
{
    public class LoadingState : GameState
    {
        public LoadingState(GameStateMachine sm) : base(sm) { }

        public override void StartState()
        {
            if (!sm.IsMaster) return;
            sm.MoveToGameScene();
        }

        public override void UpdateState() { }

        public override void ExitState() { }

        public override void OnAllPlayerReady()
        {
            sm.SwitchState(2);
        }
    }
}