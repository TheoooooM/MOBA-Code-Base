using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities.Inventory
{
    public class HealthModItem : Item
    {
        private IActiveLifeable lifeable;
        
        public override void OnItemAddedToInventory(Entity entity)
        {
            base.OnItemAddedToInventory(entity);
            lifeable = entity.GetComponent<IActiveLifeable>();
            lifeable?.IncreaseMaxHpRPC(((HealthModItemSO)AssociatedItemSO()).healthMod);
        }

        public override void OnItemRemovedFromInventory()
        {
            base.OnItemRemovedFromInventory();
            lifeable?.DecreaseMaxHpRPC(((HealthModItemSO)AssociatedItemSO()).healthMod);
        }
    }
}