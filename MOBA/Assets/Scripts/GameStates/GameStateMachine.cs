using System.Collections;
using System.Collections.Generic;
using Entities.Champion;
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

        [SerializeField] private string gameSceneName;

        private GameState currentState;
        private GameState[] gamesStates;

        [Tooltip("Ticks per second")] public float tickRate = 1;

        public event GlobalDelegates.NoParameterDelegate OnTick;
        public event GlobalDelegates.NoParameterDelegate OnTickFeedback;

        public Enums.Team winner = Enums.Team.Neutral;
        public List<int> allPlayersIDs = new List<int>();

        private readonly Dictionary<int, (Enums.Team, byte, bool)> playersReadyDict =
            new Dictionary<int, (Enums.Team, byte, bool)>();

        public uint expectedPlayerCount = 4;

        public ChampionSO[] allChampions;
        public Enums.Team[] allTeams;

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
            if (PhotonNetwork.IsMasterClient)
            {
                Debug.Log("Master initializes");
                InitState();
            }
            else
            {
                RequestStartCurrentState();
            }
        }

        private void Update()
        {
            currentState?.UpdateState();
        }

        private void InitState()
        {
            currentState = gamesStates[0];
            currentState.StartState();
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

        private void RequestStartCurrentState()
        {
            photonView.RPC("StartCurrentStateRPC", RpcTarget.MasterClient);
        }

        [PunRPC]
        public void StartCurrentStateRPC()
        {
            byte index = 255;
            for (int i = 0; i < gamesStates.Length - 1; i++)
            {
                if (gamesStates[i] == currentState) index = (byte)i;
            }

            if (index == 255)
            {
                Debug.LogError("Index is not valid.");
                return;
            }

            photonView.RPC("SyncStartCurrentStateRPC", RpcTarget.All, index);
        }

        [PunRPC]
        public void SyncStartCurrentStateRPC(byte index)
        {
            if (currentState != null) return; // We don't want to sync a client already synced
            
            currentState = gamesStates[index];
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

        public Enums.Team GetPlayerTeam(int actorNumber)
        {
            return playersReadyDict.ContainsKey(actorNumber) ? playersReadyDict[actorNumber].Item1 : Enums.Team.Neutral;
        }

        public Enums.Team GetPlayerTeam()
        {
            return GetPlayerTeam(PhotonNetwork.LocalPlayer.ActorNumber);
        }

        public byte GetPlayerChampionSOIndex(int actorNumber)
        {
            return playersReadyDict.ContainsKey(actorNumber) ? playersReadyDict[actorNumber].Item2 : (byte)0;
        }

        public byte GetPlayerChampionSOIndex()
        {
            return GetPlayerChampionSOIndex(PhotonNetwork.LocalPlayer.ActorNumber);
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
            if (playersReadyDict.ContainsKey(photonID))
            {
                Debug.LogWarning($"This player already exists (on {PhotonNetwork.LocalPlayer.ActorNumber})!");
            }
            else
            {
                Debug.Log($"A player has been added (on {PhotonNetwork.LocalPlayer.ActorNumber}).");
                playersReadyDict.Add(photonID, (Enums.Team.Neutral, 255, false));
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
            if (playersReadyDict.ContainsKey(photonID))
            {
                playersReadyDict.Remove(photonID);
                allPlayersIDs.Remove(photonID);
            }
        }

        public void RequestSetTeam(byte team)
        {
            photonView.RPC("SetTeamRPC", RpcTarget.MasterClient, PhotonNetwork.LocalPlayer.ActorNumber, team);
        }

        [PunRPC]
        private void SetTeamRPC(int photonID, byte team)
        {
            photonView.RPC("SyncSetTeamRPC", RpcTarget.All, photonID, team);
        }

        [PunRPC]
        public void SyncSetTeamRPC(int photonID, byte team)
        {
            if (!playersReadyDict.ContainsKey(photonID))
            {
                Debug.LogWarning($"This player is not added (on {PhotonNetwork.LocalPlayer.ActorNumber}).");
                return;
            }

            Debug.Log(
                $"Player {photonID} set their team, {(Enums.Team)team} (on {PhotonNetwork.LocalPlayer.ActorNumber}).");
            playersReadyDict[photonID] = ((Enums.Team)team, playersReadyDict[photonID].Item2,
                playersReadyDict[photonID].Item3);
        }

        public void RequestSetChampion(byte champion)
        {
            photonView.RPC("SetChampionRPC", RpcTarget.MasterClient, PhotonNetwork.LocalPlayer.ActorNumber, champion);
        }

        [PunRPC]
        private void SetChampionRPC(int photonID, byte champion)
        {
            photonView.RPC("SyncSetChampionRPC", RpcTarget.All, photonID, champion);
        }

        [PunRPC]
        public void SyncSetChampionRPC(int photonID, byte champion)
        {
            if (!playersReadyDict.ContainsKey(photonID)) return;

            playersReadyDict[photonID] = (playersReadyDict[photonID].Item1, champion, playersReadyDict[photonID].Item3);
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

            playersReadyDict[photonID] = (playersReadyDict[photonID].Item1,
                playersReadyDict[photonID].Item2,
                ready);

            if (!playersReadyDict[photonID].Item3) return;
            if (!IsEveryPlayerReady()) return;

            foreach (var key in allPlayersIDs)
                playersReadyDict[key] = (playersReadyDict[photonID].Item1,
                    playersReadyDict[photonID].Item2,
                    false);

            currentState.OnAllPlayerReady();
        }

        private bool IsEveryPlayerReady()
        {
            if (playersReadyDict.Count != expectedPlayerCount) return false;

            var team1Count = 0;
            var team2Count = 0;
            foreach (var kvp in playersReadyDict)
            {
                if (!kvp.Value.Item3) return false;
                if (kvp.Value.Item1 == Enums.Team.Team1) team1Count++;
                if (kvp.Value.Item1 == Enums.Team.Team2) team2Count++;
            }

            return team1Count == team2Count && team1Count == 2;
        }

        public IEnumerator StartingGame()
        {
            LobbyUIManager.Instance.RequestStartGame();
            yield return new WaitForSeconds(3f);
            SwitchState(1);
        }

        public void LoadMap()
        {
            // Load scene
            // Init pools
            // Init more stuff
            SendSetToggleReady(true);
        }

        public void MoveToGameScene()
        {
            PhotonNetwork.IsMessageQueueRunning = false;
            PhotonNetwork.LoadLevel(gameSceneName);
        }
    }
}