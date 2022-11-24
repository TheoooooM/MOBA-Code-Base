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
        if (EntityCollectionManager.GetEntityByIndex(entityIndex) != null && EntityCollectionManager.GetEntityByIndex(entityIndex).GetComponent<IResourceable>() != null)
        {
            Transform entityTransform = EntityCollectionManager.GetEntityByIndex(entityIndex).transform;
            EntityResourceBar canvasResource = Instantiate(resourceBarPrefab, entityTransform.position + offset, Quaternion.identity, entityTransform);
            canvasResource.transform.LookAt(canvasResource.transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
            entitiesResource.Add(entityIndex, canvasResource);
            canvasResource.SetResource(entityIndex);
        }
    }
}
