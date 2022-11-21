using UnityEngine;

namespace Entities.Champion
{
    public abstract class ChampionSO : ScriptableObject
    {
        public float maxHp;
        public float maxRessource;
        public float viewRange;
        public float referenceMoveSpeed;
        public byte attackAbilityIndex;
        public byte[] abilitiesIndexes = new byte[2];
        public byte ultimateAbilityIndex;
    }
}


