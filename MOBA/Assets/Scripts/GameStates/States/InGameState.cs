using UnityEngine;

namespace GameStates.States
{
    public class InGameState : GameState
    {
        public InGameState(GameStateMachine sm) : base(sm) { }

        private float timer;

        public override void StartState()
        {
            InputManager.EnablePlayerMap(true);
            Debug.Log("GAME STARTS");
        }

        public override void UpdateState()
        {
            if (!sm.IsMaster) return;

            if (IsWinConditionChecked())
            {
                sm.SwitchState(3);
                return;
            }

            if (timer >= 1f / sm.tickRate)
            {
                timer = 0f;
                sm.Tick();
            }
            else timer += Time.deltaTime;
        }

        public override void ExitState() { }
        public override void OnAllPlayerReady() { }

        private bool IsWinConditionChecked()
        {
            // Check win condition for any team
            //sm.winner = Enums.Team.Neutral;
            return sm.winner != Enums.Team.Neutral;
        }
    }
}