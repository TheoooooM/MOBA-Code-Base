using Photon.Pun;
using GameStates.States;

namespace GameStates
{
    public class GameStateMachine : MonoBehaviourPun
    {
        private GameState currentState;
        private GameState[] gamesStates;

        private void Start()
        {
            gamesStates = new GameState[4];
            gamesStates[0] = new LobbyState();
            gamesStates[1] = new LoadingState();
            gamesStates[2] = new InGameState();
            gamesStates[3] = new PostGameState();
        }

        private void InitState()
        {
        }

        public void SwitchState(byte stateIndex)
        {
            photonView.RPC("SyncStatesRPC", RpcTarget.All, stateIndex);
        }

        [PunRPC]
        public void SyncStatesRPC(byte stateIndex)
        {
            currentState.ExitState();
            currentState = gamesStates[stateIndex];
            currentState.StartState();
        }
    }
}