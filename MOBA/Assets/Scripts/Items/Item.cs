using System.Collections.Generic;
using Entities.Capacities;
using UnityEngine;

namespace Entities.Inventory
{
    public abstract class Item
    {
        public bool consumable;
        public int count;
        
        public Entity entityOfInventory;
        public IInventoryable inventory;

        public byte indexOfSOInCollection;
        
        public ItemSO AssociatedItemSO()
        {
            return ItemCollectionManager.GetItemSObyIndex(indexOfSOInCollection);
        }

        public virtual void OnItemAddedToInventory(Entity entity)
        {
            entityOfInventory = entity;
            inventory = entityOfInventory.GetComponent<IInventoryable>();
            var capacityCollection = CapacitySOCollectionManager.Instance;
            // TODO - Add passives
        }

        public virtual void OnItemAddedToInventoryFeedback(Entity entity)
        {
            entityOfInventory = entity;
            inventory = entityOfInventory.GetComponent<IInventoryable>();
            // TODO - Add passives feedbacks
        }

        public virtual void OnItemRemovedInventory()
        {
            
        }

        public virtual void OnItemRemovedInventoryFeedback()
        {
            
        }

        public virtual void OnItemActivated(int[] targets,Vector3[] positions)
        {
            var castable = entityOfInventory.GetComponent<ICastable>();
            if(castable == null) return;
            //foreach (var index in activeCapacitiesIndexes)
            {
                //castable.CastRPC(index,targets,positions);
            }
        }

        public virtual void OnItemActivatedFeedback(int[] targets,Vector3[] positions)
        {
            var castable = entityOfInventory.GetComponent<ICastable>();
            if(castable == null) return;
            //foreach (var index in activeCapacitiesIndexes)
            {
                //missing castableFeedback?
            }
        }


    }
}

