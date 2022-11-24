using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities.Inventory
{
    public class HealthModItem : Item
    {
        private IActiveLifeable lifeable;
        
        public override void OnItemAddedEffects(Entity entity)
        {
            lifeable = entity.GetComponent<IActiveLifeable>();
            lifeable?.IncreaseMaxHpRPC(((HealthModItemSO)AssociatedItemSO()).healthMod);
        }

        public override void OnItemRemovedEffects(Entity entity)
        {
            lifeable?.DecreaseMaxHpRPC(((HealthModItemSO)AssociatedItemSO()).healthMod);
        }
    }
}