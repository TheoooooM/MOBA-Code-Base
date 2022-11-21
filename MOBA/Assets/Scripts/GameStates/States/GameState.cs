namespace GameStates.States
{
    public abstract class GameState
    {
        public abstract void StartState();

        public abstract void UpdateState();

        public abstract void ExitState();
    }
}