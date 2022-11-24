using GameStates;
using UnityEngine;

public class WinButtonTest : MonoBehaviour
{
    public void OnStartInGameState()
    {
        GameStateMachine.Instance.SwitchState(2);
    }
    
    public void OnTeamWins(int index)
    {
        GameStateMachine.Instance.winner = index == 0 ? Enums.Team.Team1 : Enums.Team.Team2;
    }
}
