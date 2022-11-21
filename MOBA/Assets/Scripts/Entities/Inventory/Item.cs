using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities.Inventory
{
    public abstract class Item
    {
        public string referenceName;
        public string itemName;
        public string description;

        public byte[] passiveCapacitiesIndexes;
        public byte[] activeCapacitiesIndexes;

        public abstract void OnItemAddedToInventory();
        public abstract void OnItemRemovedInventory();
    }
}

