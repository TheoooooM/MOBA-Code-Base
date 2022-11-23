using System.Collections.Generic;
using Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public partial class UIManager
{
    [SerializeField] private Dictionary<uint, GameObject> entitiesHealth = new Dictionary<uint, GameObject>();
    [SerializeField] private GameObject healthBarPrefab;

    public void InstantiateHealthBarForEntity(uint entityIndex)
    {
        if (EntityCollectionManager.GetEntityByIndex(entityIndex) != null && EntityCollectionManager.GetEntityByIndex(entityIndex).GetComponent<IActiveLifeable>() != null)
        {
            Transform entityTransform = EntityCollectionManager.GetEntityByIndex(entityIndex).transform;
            GameObject healthBar = Instantiate(healthBarPrefab, entityTransform.position, Quaternion.identity, entityTransform.GetComponentInChildren<Canvas>().transform);
            healthBar.transform.LookAt(Camera.main.transform);
            entitiesHealth.Add(entityIndex, healthBar);
            SetHealthBar(entityIndex);
        }
    }
    
    public void SetHealthBar(uint entityIndex)
    {
        if (entitiesHealth.ContainsKey(entityIndex))
        {
            GameObject healthBar = entitiesHealth[entityIndex];
            healthBar.GetComponentInChildren<Image>().fillAmount = EntityCollectionManager.GetEntityByIndex(entityIndex).GetComponent<IActiveLifeable>().GetCurrentHpPercent();
        }
    }
}
