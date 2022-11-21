using System.Collections.Generic;
using UnityEngine;

namespace Entities.Capacities
{
//Asset Menu Synthax :
//[CreateAssetMenu(menuName = "Capacity/ActiveCapacitySO", fileName = "new ActiveCapacitySO")]
    public abstract class ActiveCapacitySO : ScriptableObject
    {
        [Tooltip("GP Name")] public string referenceName;

        [Tooltip("GD Name")] public string descriptionName;

        [TextArea(4, 4)] [Tooltip("Description of the capacity")]
        public string description;

        [Tooltip("Cooldown in second")] public float cooldown;

        [Tooltip("All types of the capacity")] private List<Enums.CapacityType> types;
    }
}