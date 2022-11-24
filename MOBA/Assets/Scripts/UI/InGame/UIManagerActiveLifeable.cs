using System.Collections.Generic;
using Entities;
using UnityEngine;

public partial class UIManager
{
    [SerializeField] private Dictionary<int, EntityHealthBar> entitiesHealth = new Dictionary<int, EntityHealthBar>();
    [SerializeField] private EntityHealthBar healthBarPrefab;

    public void InstantiateHealthBarForEntity(int entityIndex)
    {
        if (EntityCollectionManager.GetEntityByIndex(entityIndex) != null && EntityCollectionManager.GetEntityByIndex(entityIndex).GetComponent<IActiveLifeable>() != null)
        {
            Transform entityTransform = EntityCollectionManager.GetEntityByIndex(entityIndex).transform;
            EntityHealthBar healthBar = Instantiate(healthBarPrefab, entityTransform.position, Quaternion.identity, entityTransform.GetComponentInChildren<Canvas>().transform);
            healthBar.transform.LookAt(Camera.main.transform);
            entitiesHealth.Add(entityIndex, healthBar);
            healthBar.SetHealth(entityIndex);
        }
    }
}
