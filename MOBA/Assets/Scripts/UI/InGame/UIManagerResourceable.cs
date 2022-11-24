using System.Collections.Generic;
using Entities;
using UnityEngine;

public partial class UIManager
{
    [Header("ResourceBar Elements")]
    [SerializeField] private readonly Dictionary<int, Canvas> entitiesResource = new Dictionary<int, Canvas>();
    [SerializeField] private Vector3 offsetResourceBar = new Vector3(0, 2.0f, 0);
    [SerializeField] private EntityResourceBar resourceBarPrefab;
    
    public void InstantiateResourceBarForEntity(int entityIndex)
    {
        if (EntityCollectionManager.GetEntityByIndex(entityIndex) != null && EntityCollectionManager.GetEntityByIndex(entityIndex).GetComponent<IResourceable>() != null)
        {
            Transform entityTransform = EntityCollectionManager.GetEntityByIndex(entityIndex).transform;
            Canvas canvas = Instantiate(canvasPrefab, entityTransform);
            if (Camera.main != null) canvas.transform.LookAt(Camera.main.transform);
            EntityResourceBar resourceBar = Instantiate(resourceBarPrefab, Vector3.zero + offsetResourceBar, Quaternion.identity, canvas.transform);
            entitiesResource.Add(entityIndex, canvas);
            resourceBar.SetResource(entityIndex);
        }
    }
}
