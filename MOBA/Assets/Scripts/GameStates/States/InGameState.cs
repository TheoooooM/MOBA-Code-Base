using System;
using UnityEngine;

namespace GameStates.States
{
    public class InGameState : GameState
    {
        public InGameState(GameStateMachine sm) : base(sm) { }

        private float timer;

        public override void StartState() { }

        public override void UpdateState()
        {
            if (!sm.IsMaster) return;

            if (IsWinConditionChecked())
            {
                sm.SwitchState(3);
                return;
            }

            if (timer >= sm.tickRate)
            {
                timer = 0f;
                sm.Tick();
            }
            else timer += Time.deltaTime;
        }

        public override void ExitState() { }

        private bool IsWinConditionChecked()
        {
            // Check win condition for any team
            sm.winner = Enums.Team.Neutral;
            return false;
        }
    }
}