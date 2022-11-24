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

        protected override void OnStart()
        {
            fowm = FogOfWarManager.Instance;
            capacityCollection = CapacitySOCollectionManager.Instance;
            //fowm.allViewables.Add(entityIndex,this);
        }

        protected override void OnUpdate()
        {
            MovePlayerMaster();
            MovePlayerLocal();
        }

        public override void OnInstantiated() { }

        public override void OnInstantiatedFeedback() { }

        [PunRPC]
        public void ApplyChampionSORPC(byte championSoIndex)
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

            // TODO - Implement Model/Prefab/Animator
            
            Debug.Log("Instantiating champion for " + gameObject.name);
            var championMesh = Instantiate(championSo.championMeshPrefab, championInitPoint.position, Quaternion.identity, championInitPoint);
            championMesh.GetComponent<ChampionMeshLinker>().LinkTeamColor(team);
            
        }

        public void SyncApplyChampionSO(byte championSoIndex)
        {
            photonView.RPC("ApplyChampionSORPC", RpcTarget.All, championSoIndex);
        }
    }
}