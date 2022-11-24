using Entities.Capacities;
using Entities.FogOfWar;
using GameStates;
using Photon.Pun;

using UnityEngine;

namespace Entities.Champion
{
    public partial class Champion : Entity
    {
        public ChampionSO championSo;
        public Transform championInitPoint;
        public Transform championMesh;

        private FogOfWarManager fowm;
        private CapacitySOCollectionManager capacityCollection;
        private UIManager uiManager;

        protected override void OnStart()
        {
            fowm = FogOfWarManager.Instance;
            SetupNavMesh();
            capacityCollection = CapacitySOCollectionManager.Instance;
            uiManager = UIManager.Instance;
            //fowm.allViewables.Add(entityIndex,this);
            if(uiManager != null)
            {
                uiManager.InstantiateHealthBarForEntity(entityIndex);
                uiManager.InstantiateResourceBarForEntity(entityIndex);
            }

            currentRotateSpeed = 10f; // A mettre dans prefab, je peux pas y toucher pour l'instant
        }

        protected override void OnUpdate()
        {
            Move();
            Rotate();
            CheckMoveDistance(); // Lol
        }

        public override void OnInstantiated() { }

        public override void OnInstantiatedFeedback() { }

        [PunRPC]
        public void ApplyChampionSORPC(byte championSoIndex, byte team)
        {
            var so = GameStateMachine.Instance.allChampionsSo[championSoIndex];
            championSo = so;
            maxHp = championSo.maxHp;
            currentHp = maxHp;
            maxResource = championSo.maxRessource;
            currentResource = championSo.maxRessource;
            viewRange = championSo.viewRange;
            referenceMoveSpeed = championSo.referenceMoveSpeed;
            currentMoveSpeed = referenceMoveSpeed;
            attackDamage = championSo.attackDamage;
            attackAbilityIndex = championSo.attackAbilityIndex;
            abilitiesIndexes = championSo.activeCapacitiesIndexes;
            ultimateAbilityIndex = championSo.ultimateAbilityIndex;
            
             var championMesh = Instantiate(championSo.championMeshPrefab, championInitPoint.position,
                Quaternion.identity, championInitPoint);

            this.team = (Enums.Team)team;
            championMesh.GetComponent<ChampionMeshLinker>().LinkTeamColor(this.team);
            elementsToShow.Add(championMesh);
        }

        public void SyncApplyChampionSO(byte championSoIndex, Enums.Team team)
        {
            photonView.RPC("ApplyChampionSORPC", RpcTarget.All, championSoIndex, (byte)team);
        }
    }
}