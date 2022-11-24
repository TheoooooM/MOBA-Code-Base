using System.Collections.Generic;
using Entities;
using UnityEngine;

public partial class UIManager
{
    [Header("HealthBar Elements")]
    [SerializeField] private readonly Dictionary<int, Canvas> entitiesHealth = new Dictionary<int, Canvas>();
    [SerializeField] private Vector3 offsetHealthBar = new Vector3(0, 2.5f, 0);
    [SerializeField] private EntityHealthBar healthBarPrefab;

    public void InstantiateHealthBarForEntity(int entityIndex)
    {
        if (EntityCollectionManager.GetEntityByIndex(entityIndex) != null && EntityCollectionManager.GetEntityByIndex(entityIndex).GetComponent<IActiveLifeable>() != null)
        {
            Transform entityTransform = EntityCollectionManager.GetEntityByIndex(entityIndex).transform;
            Canvas canvas = Instantiate(canvasPrefab, entityTransform);
            if (Camera.main != null) canvas.transform.LookAt(Camera.main.transform);
            EntityHealthBar healthBar = Instantiate(healthBarPrefab, Vector3.zero + offsetHealthBar, Quaternion.identity, canvas.transform);
            entitiesHealth.Add(entityIndex, canvas);
            healthBar.SetHealth(entityIndex);
        }
    }
}
