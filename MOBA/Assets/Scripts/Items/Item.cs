using System.Collections.Generic;
using Entities.Capacities;
using UnityEngine;

namespace Entities.Inventory
{
    public abstract class Item
    {
        public bool consumable;
        
        public int count;
        public float timer;
        public Entity entityOfInventory;
        public IInventoryable inventory;

        public byte indexOfSOInCollection;

        public ItemSO AssociatedItemSO()
        {
            return ItemCollectionManager.GetItemSObyIndex(indexOfSOInCollection);
        }

        public void OnItemAddedToInventory(Entity entity)
        {
            if (consumable) count++;
            entityOfInventory = entity;
            inventory = entityOfInventory.GetComponent<IInventoryable>();
            OnItemAddedEffects(entity);
            var capacityCollection = CapacitySOCollectionManager.Instance;
            // TODO - Add passives
        }

        public abstract void OnItemAddedEffects(Entity entity);

        public virtual void OnItemAddedToInventoryFeedback(Entity entity)
        {
            entityOfInventory = entity;
            inventory = entityOfInventory.GetComponent<IInventoryable>();
            OnItemRemovedEffects(entity);
            // TODO - Add passives feedbacks
        }

        public abstract void OnItemRemovedEffects(Entity entity);

        public virtual void OnItemRemovedFromInventory()
        {
        }

        public virtual void OnItemRemovedInventoryFeedback()
        {
        }

        public virtual void OnItemActivated(int[] targets, Vector3[] positions)
        {
        }


        public virtual void OnItemActivatedFeedback(int[] targets, Vector3[] positions)
        {
        }
    }
}