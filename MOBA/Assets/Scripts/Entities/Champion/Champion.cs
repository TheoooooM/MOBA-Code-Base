using Controllers;
using UnityEngine;

namespace Entities.Champion
{
    public partial class Champion : Entity
    {
        public ChampionSO championSo;

        public byte attackAbilityIndex;
        public byte[] abilitiesIndexes = new byte[2];
        public byte ultimateAbilityIndex;

        protected override void OnStart() { }

        protected override void OnUpdate() { }
        public override void OnInstantiated()
        {
            
        }

        public override void OnInstantiatedFeedback()
        {
            
        }
    }
}