using System;
using Entities.Champion;
using GameStates;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUIManager : MonoBehaviourPun
{
    public static LobbyUIManager Instance;

    private bool isReady;

    [SerializeField] private Button readyButton;
    [SerializeField] private TextMeshProUGUI readyButtonText;

    [Header("Connection Part")] [SerializeField]
    private GameObject connectionPart;

    [SerializeField] private GameObject goTextObject;

    [Header("Champion Selection Part")] [SerializeField]
    private Color selectedChampionColor;

    [SerializeField] private Color unselectedChampionColor;

    [SerializeField] private Image firstChampionColorImage;
    [SerializeField] private Image secondChampionColorImage;
    
    [Header("Team Selection Part")] [SerializeField]
    private Color firstTeamColor;

    [SerializeField] private Color secondTeamColor;
    [SerializeField] private Image teamColorImage;
    [SerializeField] private TextMeshProUGUI teamColorText;
    private bool isFirstTeam = true;

    [Header("Data")] private byte currentChampion;
    private byte currentTeam;

    private GameStateMachine sm;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            DestroyImmediate(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        Initialization();
    }

    private void Initialization()
    {
        sm = GameStateMachine.Instance;

        readyButton.interactable = false;

        firstChampionColorImage.color = unselectedChampionColor;
        secondChampionColorImage.color = unselectedChampionColor;

        // Default is no champion selected
        currentChampion = 2;

        // Default is first team
        sm.RequestSetTeam(0);
    }

    public void OnToggleReadyClick()
    {
        // We switch state
        isReady = !isReady;

        // We change GUI
        if (isReady)
        {
            connectionPart.SetActive(true);
            readyButtonText.text = "Cancel";
        }
        else
        {
            connectionPart.SetActive(false);
            readyButtonText.text = "Validate";
        }

        // We send request to Master
        sm.SendSetToggleReady(isReady);
    }

    public void OnChampionClick(int index)
    {
        if (isReady) return;

        if (index != 0 && index != 1)
        {
            Debug.LogError("Index is not valid. Must be 0 or 1.");
            return;
        }

        currentChampion = (byte)index;
        
        // We change GUI
        if (index == 0)
        {
            firstChampionColorImage.color = selectedChampionColor;
            secondChampionColorImage.color = unselectedChampionColor;
        }
        else
        {
            firstChampionColorImage.color = unselectedChampionColor;
            secondChampionColorImage.color = selectedChampionColor;
        }

        readyButton.interactable = true;

        // We send request to Master
        sm.RequestSetChampion(currentChampion);
    }

    public void OnTeamClick()
    {
        if (isReady) return;

        // We switch team
        isFirstTeam = !isFirstTeam;
        var index = isFirstTeam ? 1 : 2;

        currentTeam = (byte)index;
        
        // We change GUI
        teamColorImage.color = isFirstTeam ? firstTeamColor : secondTeamColor;
        teamColorText.color = isFirstTeam ? firstTeamColor : secondTeamColor;
        teamColorText.text = isFirstTeam ? "Team 1" : "Team 2";

        // We send request to Master
        sm.RequestSetTeam(currentTeam);
    }

    public void RequestStartGame()
    {
        photonView.RPC("StartGameRPC", RpcTarget.MasterClient);
    }

    [PunRPC]
    public void StartGameRPC()
    {
        photonView.RPC("SyncStartGameRPC", RpcTarget.All);
    }

    [PunRPC]
    public void SyncStartGameRPC()
    {
        goTextObject.SetActive(true);
    }

    public void RequestShow()
    {
        photonView.RPC("ShowRPC", RpcTarget.MasterClient, PhotonNetwork.LocalPlayer.ActorNumber, currentTeam, currentChampion);
    }

    [PunRPC]
    public void ShowRPC(byte photonID, byte team, byte champion)
    {
        photonView.RPC("SyncShowRPC", RpcTarget.MasterClient, photonID,currentTeam, currentChampion);

    }

    [PunRPC]
    public void SyncShowRPC(byte photonID, byte team, byte champion)
    {
        
    }
}