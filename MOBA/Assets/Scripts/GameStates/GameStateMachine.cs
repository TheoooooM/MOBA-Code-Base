using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Controllers.Inputs;
using Entities.Champion;
using Entities.Inventory;
using Photon.Pun;
using GameStates.States;
using UnityEngine;
using Random = UnityEngine.Random;

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

        /// <summary>
        /// Key : actorNumber, Values : Team, ChampionSOindex, ready
        /// </summary>
        private readonly Dictionary<int, PlayerData> playersReadyDict =
            new Dictionary<int, PlayerData>();

        public List<PlayerData> debugList;

        public uint expectedPlayerCount = 4;

        public ChampionSO[] allChampionsSo;
        public Enums.Team[] allTeams;

        public TeamColor[] teamColors;

        [Serializable]
        public struct TeamColor
        {
            public Enums.Team team;
            public Color color;
        }

        [Serializable]
        public class PlayerData
        {
            public Enums.Team team;
            public byte championSOIndex;
            public bool playerReady;
        }

        public string currentStateDebugString;

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

            OnTick += () => Debug.Log("Tick!");
        }

        private void Start()
        {
            if (PhotonNetwork.IsMasterClient)
            {
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
            //Debug.Log(currentState);
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
            currentStateDebugString = gamesStates[stateIndex].ToString();
            currentState.StartState();
        }

        private void RequestStartCurrentState()
        {
            photonView.RPC("StartCurrentStateRPC", RpcTarget.MasterClient);
        }

        [PunRPC]
        private void StartCurrentStateRPC()
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
        private void SyncStartCurrentStateRPC(byte index)
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
        private void TickRPC()
        {
            OnTickFeedback?.Invoke();
        }

        public Enums.Team GetPlayerTeam(int actorNumber)
        {
            return playersReadyDict.ContainsKey(actorNumber) ? playersReadyDict[actorNumber].team : Enums.Team.Neutral;
        }

        public Enums.Team GetPlayerTeam()
        {
            return GetPlayerTeam(PhotonNetwork.LocalPlayer.ActorNumber);
        }

        public byte GetPlayerChampionSOIndex(int actorNumber)
        {
            return playersReadyDict.ContainsKey(actorNumber) ? playersReadyDict[actorNumber].championSOIndex : (byte)0;
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
        private void AddPlayerRPC(int actorNumber)
        {
            photonView.RPC("SyncAddPlayerRPC", RpcTarget.All, actorNumber);
        }

        [PunRPC]
        private void SyncAddPlayerRPC(int actorNumber)
        {
            if (playersReadyDict.ContainsKey(actorNumber))
            {
                Debug.LogWarning($"This player already exists (on {PhotonNetwork.LocalPlayer.ActorNumber})!");
            }
            else
            {
                var playerData = new PlayerData
                {
                    team = Enums.Team.Neutral,
                    championSOIndex = 255,
                    playerReady = false
                };

                playersReadyDict.Add(actorNumber, playerData);
                debugList[actorNumber] = playerData;

                allPlayersIDs.Add(actorNumber);
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
        private void SyncSetTeamRPC(int photonID, byte team)
        {
            if (!playersReadyDict.ContainsKey(photonID))
            {
                Debug.LogWarning($"This player is not added (on {PhotonNetwork.LocalPlayer.ActorNumber}).");
                return;
            }

            playersReadyDict[photonID].team = (Enums.Team)team;
            debugList[photonID].team = (Enums.Team)team;
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
        private void SyncSetChampionRPC(int photonID, byte champion)
        {
            if (!playersReadyDict.ContainsKey(photonID)) return;

            playersReadyDict[photonID].championSOIndex = champion;
            debugList[photonID].championSOIndex = champion;
        }

        public void RequestSendDataDictionary()
        {
            photonView.RPC("SendDataDictionaryRPC", RpcTarget.MasterClient);
        }
        
        [PunRPC]
        private void SendDataDictionaryRPC()
        {
            foreach (var kvp in playersReadyDict)
            {
                photonView.RPC("SyncDataDictionaryRPC", RpcTarget.Others, kvp.Key, (byte)kvp.Value.team,
                    kvp.Value.championSOIndex, kvp.Value.playerReady);
            }
        }

        [PunRPC]
        private void SyncDataDictionaryRPC(int key, byte team, byte championSO, bool ready)
        {
            Debug.Log($"Je récupère les data du Master : {key}, {(Enums.Team)team}, {championSO}, {ready}");
            var data = new PlayerData
            {
                team = (Enums.Team)team,
                championSOIndex = championSO,
                playerReady = ready
            };

            playersReadyDict[key] = data;
            debugList[key] = data;
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

            playersReadyDict[photonID].playerReady = ready;
            debugList[photonID].playerReady = ready;

            if (!playersReadyDict[photonID].playerReady) return;
            if (!IsEveryPlayerReady()) return;

            foreach (var key in allPlayersIDs) playersReadyDict[key].playerReady = false;

            currentState.OnAllPlayerReady();
        }

        private bool IsEveryPlayerReady()
        {
            if (playersReadyDict.Count != expectedPlayerCount) return false;

            var team1Count = 0;
            var team2Count = 0;
            foreach (var kvp in playersReadyDict)
            {
                if (!kvp.Value.playerReady) return false;
                if (kvp.Value.team == Enums.Team.Team1) team1Count++;
                if (kvp.Value.team == Enums.Team.Team2) team2Count++;
            }

            return team1Count == team2Count && team1Count == 2;
        }

        public IEnumerator StartingGame()
        {
            LobbyUIManager.Instance.SendStartGame();
            yield return new WaitForSeconds(3f);
            SwitchState(1);
        }

        /// <summary>
        /// Executed by MapLoaderManager on a GO on the scene 'gameSceneName', so only once the scene is loaded
        /// </summary>
        public void LoadMap()
        {
            // TODO - init pools

            LinkChampionCapacityIndexes();

            ItemCollectionManager.LinkCapacityIndexes();

            InstantiateChampion();

            foreach (var actorNumber in playersReadyDict.Keys)
            {
                UIManager.Instance.AssignInventory(actorNumber);
            }

            SendSetToggleReady(true);
        }

        private void LinkChampionCapacityIndexes()
        {
            foreach (var championSo in allChampionsSo)
            {
                championSo.SetIndexes();
            }
        }

        private void InstantiateChampion()
        {
            var pos = new Vector3(Random.Range(0f, 10f), 1, Random.Range(0f, 10f));
            var champion = (Champion)PoolNetworkManager.Instance.PoolInstantiate(0, pos, Quaternion.identity);
            champion.SendStartPosition(pos);
            champion.name = $"Player ID:{PhotonNetwork.LocalPlayer.ActorNumber}";

            LinkController(champion);
            LinkChampionData(champion);
        }

        private void LinkController(Champion champion)
        {
            var controller = champion.GetComponent<PlayerInputController>();

            // We set local parameters
            controller.LinkControlsToPlayer();
            controller.LinkCameraToPlayer();
            //controller.TransferOwnerShipToMaster();
        }

        private void LinkChampionData(Champion champion)
        {
            // We take data

            var data = playersReadyDict[PhotonNetwork.LocalPlayer.ActorNumber];
            if (data.championSOIndex >= allChampionsSo.Length)
            {
                Debug.LogWarning("Make sure the mesh is valid. Selects default mesh.");
                data.championSOIndex = 1;
            }

            var championSo = allChampionsSo[data.championSOIndex];

            // We state name
            champion.name += $" / {championSo.name}";

            // We set team
            champion.RequestChangeTeam(data.team);

            // We sync data and champion mesh
            champion.SyncApplyChampionSO(data.championSOIndex);
        }

        [PunRPC]
        public void MoveToGameScene()
        {
            PhotonNetwork.IsMessageQueueRunning = false;
            PhotonNetwork.LoadLevel(gameSceneName);
        }
    }
}