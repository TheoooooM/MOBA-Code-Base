using System.Collections.Generic;
using Entities.Capacities;
using UnityEngine;

namespace Entities.Inventory
{
    public abstract class Item
    {
        public string referenceName;
        public string itemName;
        public string description;
        public uint usesLeft;

        public byte[] passiveCapacitiesIndexes;
        public byte[] activeCapacitiesIndexes;
        public Entity entityOfInventory;
        public IInventoryable inventory;

        public abstract ItemSO AssociatedItemSo();

        public virtual void OnItemAddedToInventory(Entity entity)
        {
            entityOfInventory = entity;
            inventory = entityOfInventory.GetComponent<IInventoryable>();
            var capacityCollection = CapacitySOCollectionManager.Instance;
            foreach (var index in passiveCapacitiesIndexes)
            {
                //addPassiveCapacity
            }
        }

        public virtual void OnItemAddedToInventoryFeedback(Entity entity)
        {
            entityOfInventory = entity;
            inventory = entityOfInventory.GetComponent<IInventoryable>();
            foreach (var index in passiveCapacitiesIndexes)
            {
                //addPassiveCapacityFeedback
            }
        }

        public virtual void OnItemRemovedInventory()
        {
            
        }

        public virtual void OnItemRemovedInventoryFeedback()
        {
            
        }

        public virtual void OnItemActivated(uint[] targets,Vector3[] positions)
        {
            var castable = entityOfInventory.GetComponent<ICastable>();
            if(castable == null) return;
            foreach (var index in activeCapacitiesIndexes)
            {
                castable.CastRPC(index,targets,positions);
            }
        }

        public virtual void OnItemActivatedFeedback(uint[] targets,Vector3[] positions)
        {
            var castable = entityOfInventory.GetComponent<ICastable>();
            if(castable == null) return;
            foreach (var index in activeCapacitiesIndexes)
            {
                //missing castableFeedback?
            }
        }


    }
}

