using System.Collections;
using Controllers;
using Entities.FogOfWar;
using Entities.Inventory;
using UnityEngine;

namespace Entities.Champion
{
    public partial class Champion : Entity
    {
        public ChampionSO championSo;

        public byte attackAbilityIndex;
        public byte[] abilitiesIndexes = new byte[2];
        public byte ultimateAbilityIndex;

        private FogOfWarManager fowm;

        #region TEST_Iventory

        /*private int teamTMP = 1;

            IEnumerator Pomme()
        {
            //yield return new WaitUntil(() => PhotonNetwork.CountOfPlayers == 2);
            yield return new WaitForSeconds(4);
            EntityCollectionManager.AddEntity(this);
            
            UIManager.Instance.AssignInventory((int)entityIndex, teamTMP);
        }
        

        protected override void OnStart()
        {
            UIManager.ClickOnItem += RequestAddItem;

            entityIndex = (uint)photonView.ViewID;

            switch (entityIndex)
            {
                case 1001:
                    teamTMP = 1;
                    break;
                case 2001:
                    teamTMP = 2;
                    break;
                case 3001:
                    teamTMP = 1;
                    break;
                case 4001:
                    teamTMP = 2;
                    break;
            }

            StartCoroutine(Pomme());
        }        */
    #endregion

    
    protected override void OnStart()
    {
        fowm = FogOfWarManager.Instance;
        fowm.allViewables.Add(entityIndex,this);
    }

        protected override void OnUpdate()
        {
            MovePlayerMaster();
        }
        public override void OnInstantiated()
        {
            
        }

        public override void OnInstantiatedFeedback()
        {
            
        }
    }
}