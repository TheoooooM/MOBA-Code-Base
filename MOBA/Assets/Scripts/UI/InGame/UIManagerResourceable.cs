using System.Collections.Generic;
using Entities;
using UnityEngine;

public partial class UIManager
{
    [Header("ResourceBar Elements")]
    [SerializeField] public readonly Dictionary<int, EntityResourceBar> entitiesResource = new Dictionary<int, EntityResourceBar>();
    [SerializeField] private EntityResourceBar resourceBarPrefab;
    
    public void InstantiateResourceBarForEntity(int entityIndex)
    {
        var entity = EntityCollectionManager.GetEntityByIndex(entityIndex);
        if (entity == null) return;
        if (entity.GetComponent<IResourceable>() == null) return;
        Transform entityTransform = entity.transform;
        EntityResourceBar canvasResource = Instantiate(resourceBarPrefab, entityTransform.position + offset, Quaternion.identity, entityTransform);
        entitiesResource.Add(entityIndex, canvasResource);
        canvasResource.SetResourceByIndex(entityIndex);
    }
}
