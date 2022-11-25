using Entities;
using UnityEngine;
using UIComponents;

public partial class UIManager
{
    [Header("ResourceBar Elements")]
    [SerializeField] private EntityResourceBar resourceBarPrefab;
    
    public void InstantiateResourceBarForEntity(int entityIndex)
    {
        var entity = EntityCollectionManager.GetEntityByIndex(entityIndex);
        if (entity == null) return;
        if (entity.GetComponent<IResourceable>() == null) return;
        var entityTransform = entity.transform;
        var canvasResource = Instantiate(resourceBarPrefab, entityTransform.position + offset, Quaternion.identity, entityTransform);
        canvasResource.InitResourceBar(entity);
    }
}