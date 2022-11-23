using Entities.Champion;
using GameStates;
using TMPro;
using UnityEngine;

public class LobbyUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI toggleReadyButtonText;
    private bool isReady;
    private GameStateMachine sm;

    private ChampionSO currentChampionSO;


    private void Start()
    {
        Initialization();
    }

    private void Initialization()
    {
        sm = GameStateMachine.Instance;

        toggleReadyButtonText.text = isReady ? "Waiting..." : "Ready!";
    }

    public void OnToggleReadyClick()
    {
        isReady = !isReady;
        toggleReadyButtonText.text = isReady ? "Waiting..." : "Ready!";
        sm.SendSetToggleReady(isReady);
    }

    public void OnChampionClick(int index)
    {
        if (isReady) return;

        if (index >= sm.allChampions.Length)
        {
            Debug.LogWarning("Index is not valid. Not serious for the moment.");
            //return;
        }

        sm.RequestSetChampion((byte)index);
    }

    public void OnTeamClick(int index)
    {
        if (isReady) return;

        sm.RequestSetTeam((byte)index);
    }
}