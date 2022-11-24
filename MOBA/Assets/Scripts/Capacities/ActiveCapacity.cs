using System.Collections.Generic;
using UnityEngine;

namespace Entities.Capacities
{
    public abstract class ActiveCapacity
    {
        public byte indexOfSOInCollection;
        
        public Entity caster;
        
        public ActiveCapacitySO AssociatedActiveCapacitySO()
        {
            return CapacitySOCollectionManager.GetActiveCapacitySOByIndex(indexOfSOInCollection);
        }
        
        public abstract bool TryCast(int entityIndex, int[] targets, Vector3[] position);

        public abstract void PlayFeedback();
    }
}

