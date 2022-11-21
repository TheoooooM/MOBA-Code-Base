using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Capacities
{
    public abstract class PassiveCapacity
    {
        private int referenceIndex; //Index Reference in CapacitySOCollectionManager

        private PassiveCapacitySO so; //Reference to his Scriptable Object

        private int count; //Amount of Stacks

        public List<Enums.CapacityType> types; //All types of the capacity

        /// <summary>
        /// Call when a Stack of the capicity is Added
        /// </summary>
        public virtual void OnAdded()
        {
        }

        /// <summary>
        /// Call Feedback of the Stack on when Added
        /// </summary>
        public virtual void OnAddedFeedback()
        {
        }

        /// <summary>
        /// Call when a Stack of the capicity is Removed
        /// </summary>
        public virtual void OnRemoved()
        {
        }

        /// <summary>
        /// Call Feedback of the Stack on when Removed
        /// </summary>
        public virtual void OnRemoveFeedback()
        {
        }
    }
}
