using System.Collections.Generic;
using Entities;
using UnityEngine;

public partial class UIManager
{
    [SerializeField] private Dictionary<int, Canvas> entitiesResource = new Dictionary<int, Canvas>();
    [SerializeField] private EntityResourceBar resourceBarPrefab;
    
    public void InstantiateResourceBarForEntity(int entityIndex)
    {
        if (EntityCollectionManager.GetEntityByIndex(entityIndex) != null && EntityCollectionManager.GetEntityByIndex(entityIndex).GetComponent<IResourceable>() != null)
        {
            Transform entityTransform = EntityCollectionManager.GetEntityByIndex(entityIndex).transform;
            Canvas canvas = Instantiate(canvasPrefab, entityTransform);
            EntityResourceBar resourceBar = Instantiate(resourceBarPrefab, canvas.transform);
            resourceBar.transform.LookAt(Camera.main.transform);
            entitiesResource.Add(entityIndex, canvas);
            resourceBar.SetResource(entityIndex);
        }
    }
}
