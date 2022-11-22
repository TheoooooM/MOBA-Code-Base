using System.Collections.Generic;
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

        [Tooltip("Ticks per second")] public uint tickRate = 1;

        public event GlobalDelegates.NoParameterDelegate OnTick;
        public event GlobalDelegates.NoParameterDelegate OnTickFeedback;

        public Enums.Team winner;
        public Dictionary<int, bool> playersReadyDict = new Dictionary<int, bool>();

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                DestroyImmediate(this);
                return;
            }

            Instance = this;

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
            photonView.RPC("SyncStatesRPC", RpcTarget.All, stateIndex);
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
            photonView.RPC("AddPlayerRPC", RpcTarget.MasterClient, photonView.Owner.ActorNumber);
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
                playersReadyDict[photonID] = false;
            }
            else playersReadyDict.Add(photonID, false);
        }

        public void RequestRemovePlayer()
        {
            photonView.RPC("RemovePlayerRPC", RpcTarget.MasterClient, photonView.Owner.ActorNumber);
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
            if (playersReadyDict.ContainsKey(photonID)) playersReadyDict.Remove(photonID);
        }

        public void SendToggleReady()
        {
            photonView.RPC("ToggleReadyRPC", RpcTarget.MasterClient);
        }

        [PunRPC]
        private void ToggleReadyRPC() { }
    }
}