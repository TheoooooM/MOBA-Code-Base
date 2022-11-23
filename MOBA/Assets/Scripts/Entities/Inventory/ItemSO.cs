using UnityEngine;
using System;


namespace Entities.Inventory
{
    //Asset Menu Syntax :
    //[CreateAssetMenu(menuName = "ItemSO", fileName = "new ItemSO")]
    public abstract class ItemSO : ScriptableObject
    {
        [Tooltip("GP Name")] public string referenceName;
        [Tooltip("GD Name")] public string itemName;
        [TextArea(4, 4)] [Tooltip("Description of the item")] public string description;

        public byte[] passiveCapacitiesIndexes;
        public byte[] activeCapacitiesIndexes;
        
        public Sprite SpriteOfItem;

        /// <returns>the type of Item associated with this ItemSO</returns>
        public abstract Type GetAssociatedItemType();
    }
}
