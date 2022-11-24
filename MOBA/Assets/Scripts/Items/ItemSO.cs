using UnityEngine;
using System;
using Entities.Capacities;


namespace Entities.Inventory
{
    //Asset Menu Syntax :
    //[CreateAssetMenu(menuName = "ItemS", fileName = "new ItemSO")]
    public abstract class ItemSO : ScriptableObject
    {
        [Tooltip("GP Name")] public string referenceName;
        [Tooltip("GD Name")] public string itemName;
        [TextArea(4, 4)] [Tooltip("Description of the item")] public string description;

        [Header("Gameplay")]
        public bool consumable;
        [Tooltip("In seconds")] public float activationCooldown = 0;
        public PassiveCapacitySO[] passiveCapacities;
        [HideInInspector] public byte[] passiveCapacitiesIndexes;
        public ActiveCapacitySO[] activeCapacities;
        [HideInInspector] public byte[] activeCapacitiesIndexes;
        
        public Sprite sprite;

        /// <returns>the type of Item associated with this ItemSO</returns>
        public abstract Type AssociatedType();

        [HideInInspector] public byte indexInCollection;
        
        public void SetIndexes()
        {
            // Passives
            passiveCapacitiesIndexes = new byte[passiveCapacities.Length];
            for (var index = 0; index < passiveCapacities.Length; index++)
            {
                var passiveCapacitySo = passiveCapacities[index];
                passiveCapacitiesIndexes[index] =
                    CapacitySOCollectionManager.GetPassiveCapacitySOIndex(passiveCapacitySo);
            }
            // Actives
            activeCapacitiesIndexes = new byte[activeCapacitiesIndexes.Length];
            for (var index = 0; index < activeCapacitiesIndexes.Length; index++)
            {
                var activeCapacitySo = activeCapacities[index];
                activeCapacitiesIndexes[index] =
                    CapacitySOCollectionManager.GetActiveCapacitySOIndex(activeCapacitySo);
            }
        }
    }
}
