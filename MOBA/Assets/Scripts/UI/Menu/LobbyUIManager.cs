using GameStates;
using TMPro;
using UnityEngine;

public class LobbyUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI toggleReadyButtonText;
    private bool isReady;
    private GameStateMachine sm;

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
}
