using System.Collections.Generic;
using UnityEngine;

namespace Entities.Capacities
{
    public abstract class ActiveCapacity
    {
        private int referenceIndex;
        
        protected Entity caster;
        
        public abstract ActiveCapacitySO AssociatedActiveCapacitySO();

        public abstract bool TryCast(uint entityIndex,uint[] targets, Vector3[] position);

        public abstract void PlayFeedback();
    }
}

