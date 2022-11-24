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
            if(UIManager.Instance != null)UIManager.Instance.InstantiateHealthBarForEntity(entityIndex);
            if(UIManager.Instance != null)UIManager.Instance.InstantiateResourceBarForEntity(entityIndex);
        }

        protected override void OnUpdate()
        {
            MovePlayerMaster();
            //MovePlayerLocal();
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
            //GetComponent<Renderer>().material.color = championSo.color;
            
            
        }

        public void SyncApplyChampionSO(byte championSoIndex)
        {
            photonView.RPC("ApplyChampionSORPC", RpcTarget.All, championSoIndex);
        }
    }
}