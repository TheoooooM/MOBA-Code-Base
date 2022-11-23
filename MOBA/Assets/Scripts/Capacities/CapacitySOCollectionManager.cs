using System.Collections.Generic;
using UnityEngine;

namespace Entities.Capacities
{
    public class CapacitySOCollectionManager : MonoBehaviour
    {

        public static CapacitySOCollectionManager Instance;

        /// <summary>
        /// List the Index of each active capacity by his capacityName
        /// Via "allActiveCapacities"
        /// <param name="key"> Capacity Name</param>
        /// <param name="value"> index of allActiveCapacities</param>
        /// </summary>
        private readonly Dictionary<string, byte> activeCapacityIndexReferenceDict = new Dictionary<string, byte>();

        /// <summary>
        /// Reference of All Active Capacities 
        /// </summary>
        [SerializeField] private List<ActiveCapacitySO> allActiveCapacities = new List<ActiveCapacitySO>();
        
        /// <summary>
        /// List the Index of each passive capacity by his capacityName
        /// Via "allPassiveCapacities"
        /// <param name="key"> Capacity Reference Name</param>
        /// <param name="value"> index of capacity in allPassiveCapacities</param>
        /// </summary>
        private readonly Dictionary<string, byte> passiveCapacityIndexReferenceDict = new Dictionary<string, byte>();

        /// <summary>
        /// Reference of All Passive Capacities 
        /// </summary>
        [SerializeField] private List<PassiveCapacitySO> allPassiveCapacities;

        private void Awake()
        {
            if (Instance != null)
            {
                DestroyImmediate(gameObject);
                return;
            }

            Instance = this;
        }

        //=========================ACTIVE=====================================

        /// <summary>
        /// Sets the activeCapacityIndexReferenceDict Dictionary values 
        /// </summary>
        private void SetActiveCapacityIndexReferenceDict()
        {
            for (byte i = 0; i < allActiveCapacities.Count; i++)
            {
                activeCapacityIndexReferenceDict.Add(allActiveCapacities[i].referenceName, i);
            }
        }

        /// <summary>
        /// Return Active Capacity by his Reference Name
        /// </summary>
        /// <param name="name">Capacity Reference Name</param>
        /// <returns></returns>
        public ActiveCapacitySO GetActiveCapacitySOByName(string name)
        {
            return allActiveCapacities[activeCapacityIndexReferenceDict[name]];
        }

        /// <summary>
        /// Return Active Capacity by his Index in allActiveCapacities
        /// </summary>
        /// <param name="index">Capacity Index</param>
        /// <returns></returns>
        public ActiveCapacitySO GetActiveCapacitySOByIndex(byte index)
        {
            return allActiveCapacities[index];
        }

        /// <summary>
        /// Return Index of Active Capacity by his Reference Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public byte GetActiveCapacitySOIndexByName(string name)
        {
            return activeCapacityIndexReferenceDict[name];
        }

        //=========================PASSIF=====================================

        /// <summary>
        /// Sets the passiveCapacityIndexReferenceDict Dictionary values 
        /// </summary>
        private void SetPassiveCapacityIndexReferenceDict()
        {
            for (byte i = 0; i < allPassiveCapacities.Count; i++)
            {
                passiveCapacityIndexReferenceDict.Add(allPassiveCapacities[i].referenceName, i);
            }
        }

        /// <summary>
        /// Return Passive Capacity by his Reference Name
        /// </summary>
        /// <param name="name">Capacity Reference Name</param>
        /// <returns></returns>
        public PassiveCapacitySO GetPassiveCapacitySOByName(string name)
        {
            return allPassiveCapacities[passiveCapacityIndexReferenceDict[name]];
        }

        /// <summary>
        /// Return Passive Capacity by his Index in allPassiveCapacities
        /// </summary>
        /// <param name="index">Capacity Index</param>
        /// <returns></returns>
        public PassiveCapacitySO GetPassiveCapacitySOByIndex(byte index)
        {
            return allPassiveCapacities[index];
        }

        /// <summary>
        /// Return Index of Passive Capacity by his Reference Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public byte GetPassiveCapacityIndexSOByName(string name)
        {
            return passiveCapacityIndexReferenceDict[name];
        }
    }
}