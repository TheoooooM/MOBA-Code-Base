using Controllers;
using Entities.FogOfWar;
using UnityEngine;

namespace Entities.Champion
{
    public partial class Champion : Entity
    {
        public ChampionSO championSo;
        
        private FogOfWarManager fowm;
        protected override void OnStart()
        {
            fowm = FogOfWarManager.Instance;
            //fowm.allViewables.Add(entityIndex,this);
        }

        protected override void OnUpdate()
        {
            MovePlayerMaster();
            MovePlayerLocal();
        }
        public override void OnInstantiated()
        {
            
        }

        public override void OnInstantiatedFeedback()
        {
            
        }
    }
}