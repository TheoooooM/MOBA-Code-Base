using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities.Capacities
{
//Asset Menu Synthax :
//[CreateAssetMenu(menuName = "Capacity/PassiveCapacitySO", fileName = "new PassiveCapacitySO")]
    public abstract class PassiveCapacitySO : ScriptableObject
    {
        [Tooltip("GP Name")] public string referenceName;

        [Tooltip("GD Name")] public string descriptionName;

        [TextArea(4, 4)] [Tooltip("Description of the capacity")]
        public string description;

        /// <summary>
        /// Define the type of Ab PassiveCapacity of this PassiveCapacitySO
        /// </summary>
        /// <param name="type">PassiveCapacity</param>
        public static Type type;

        [Tooltip("All types of the capacity")] public List<Enums.CapacityType> types;
    }
}