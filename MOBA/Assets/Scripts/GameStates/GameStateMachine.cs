using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using GameStates.States;
using UnityEngine;

namespace GameStates
{
    [RequireComponent(typeof(PhotonView))]
    public class GameStateMachine : MonoBehaviourPun
    {
        public static GameStateMachine Instance;
        public bool IsMaster => PhotonNetwork.IsMasterClient;

        private GameState currentState;
        private GameState[] gamesStates;

        [Tooltip("Ticks per second")] public float tickRate = 1;

        public event GlobalDelegates.NoParameterDelegate OnTick;
        public event GlobalDelegates.NoParameterDelegate OnTickFeedback;

        public Enums.Team winner;
        [SerializeField] private List<int> allPlayersIDs = new List<int>();
        private readonly Dictionary<int, bool> playersReadyDict = new Dictionary<int, bool>();
        public uint expectedPlayerCount = 4;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                DestroyImmediate(this);
                return;
            }
            
            Instance = this;
            PhotonNetwork.AutomaticallySyncScene = true;

            if (tickRate <= 0)
            {
                Debug.LogWarning("TickRate can't be negative. Set to 1");
                tickRate = 1;
            }

            gamesStates = new GameState[4];
            gamesStates[0] = new LobbyState(this);
            gamesStates[1] = new LoadingState(this);
            gamesStates[2] = new InGameState(this);
            gamesStates[3] = new PostGameState(this);

            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            InitState();
        }

        private void Update()
        {
            currentState?.UpdateState();
        }

        private void InitState()
        {
            photonView.RPC("SyncInitStateRPC", RpcTarget.All);
        }

        public void SwitchState(byte stateIndex)
        {
            photonView.RPC("SyncSwitchStateRPC", RpcTarget.All, stateIndex);
        }

        [PunRPC]
        private void SyncSwitchStateRPC(byte stateIndex)
        {
            currentState.ExitState();
            currentState = gamesStates[stateIndex];
            currentState.StartState();
        }

        [PunRPC]
        private void SyncInitStateRPC()
        {
            currentState = gamesStates[0];
            currentState.StartState();
        }

        public void Tick()
        {
            OnTick?.Invoke();
            photonView.RPC("TickRPC", RpcTarget.All);
        }

        [PunRPC]
        public void TickRPC()
        {
            OnTickFeedback?.Invoke();
        }

        public void RequestAddPlayer()
        {
            photonView.RPC("AddPlayerRPC", RpcTarget.MasterClient, PhotonNetwork.LocalPlayer.ActorNumber);
        }

        [PunRPC]
        private void AddPlayerRPC(int photonID)
        {
            photonView.RPC("SyncAddPlayerRPC", RpcTarget.All, photonID);
        }

        [PunRPC]
        private void SyncAddPlayerRPC(int photonID)
        {
            Debug.Log(photonID);
            if (playersReadyDict.ContainsKey(photonID))
            {
                //playersReadyDict[photonID] = false;
            }
            else
            {
                playersReadyDict.Add(photonID, false);
                allPlayersIDs.Add(photonID);
            }
        }

        public void RequestRemovePlayer()
        {
            photonView.RPC("RemovePlayerRPC", RpcTarget.MasterClient, PhotonNetwork.LocalPlayer.ActorNumber);
        }

        [PunRPC]
        private void RemovePlayerRPC(int photonID)
        {
            photonView.RPC("SyncRemovePlayerRPC", RpcTarget.All, photonID);
        }

        [PunRPC]
        private void SyncRemovePlayerRPC(int photonID)
        {
            Debug.Log(photonID);
            if (playersReadyDict.ContainsKey(photonID))
            {
                playersReadyDict.Remove(photonID);
                allPlayersIDs.Remove(photonID);
            }
        }

        public void SendSetToggleReady(bool ready)
        {
            photonView.RPC("SetReadyRPC", RpcTarget.MasterClient, PhotonNetwork.LocalPlayer.ActorNumber, ready);
        }

        [PunRPC]
        private void SetReadyRPC(int photonID, bool ready)
        {
            if (!playersReadyDict.ContainsKey(photonID))
            {
                Debug.LogError("This key is not valid.");
                return;
            }

            playersReadyDict[photonID] = ready;

            if (!playersReadyDict[photonID])
            {
                Debug.Log("The value was set to false");
                return;
            }
            if (!IsEveryPlayerReady())
            {
                Debug.Log("Every player is not ready");
                return;
            }

            foreach (var key in allPlayersIDs) playersReadyDict[key] = false;

            currentState.OnAllPlayerReady();
        }

        private bool IsEveryPlayerReady()
        {
            foreach (var kv in playersReadyDict)
            {
                Debug.Log($"{kv.Key} / {kv.Value}");
            }
            
            return playersReadyDict.Values.All(ready => ready) && playersReadyDict.Count == expectedPlayerCount;
        }

        public void LoadMap()
        {
            // Load scene
            // Init pools
            // Init more stuff
            SendSetToggleReady(true);
            Debug.Log("Loading is over");
        }

        public void MoveToGameScene()
        {
            PhotonNetwork.IsMessageQueueRunning = false;
            PhotonNetwork.LoadLevel("InGameScene");
        }
    }
}