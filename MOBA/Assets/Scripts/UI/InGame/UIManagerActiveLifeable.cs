using System.Collections.Generic;
using Entities;
using UnityEngine;

public partial class UIManager
{
    [Header("HealthBar Elements")]
    [SerializeField] private readonly Dictionary<int, EntityHealthBar> entitiesHealth = new Dictionary<int, EntityHealthBar>();
    [SerializeField] private EntityHealthBar healthBarPrefab;

    public void InstantiateHealthBarForEntity(int entityIndex)
    {
        if (EntityCollectionManager.GetEntityByIndex(entityIndex) != null && EntityCollectionManager.GetEntityByIndex(entityIndex).GetComponent<IActiveLifeable>() != null)
        {
            Transform entityTransform = EntityCollectionManager.GetEntityByIndex(entityIndex).transform;
            Vector3 direction = Camera.main.transform.position - entityTransform.position;
            EntityHealthBar canvasHealth = Instantiate(healthBarPrefab, entityTransform.position + offset, Quaternion.identity, entityTransform);
            canvasHealth.transform.LookAt(canvasHealth.transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
            entitiesHealth.Add(entityIndex, canvasHealth);
            canvasHealth.SetHealth(entityIndex);
        }
    }
}
