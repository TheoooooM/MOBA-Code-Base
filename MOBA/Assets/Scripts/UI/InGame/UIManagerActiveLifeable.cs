using Entities;
using UnityEngine;
using UIComponents;

public partial class UIManager
{
    [Header("HealthBar Elements")]
    [SerializeField] private EntityHealthBar healthBarPrefab;

    public void InstantiateHealthBarForEntity(int entityIndex)
    {
        var entity = EntityCollectionManager.GetEntityByIndex(entityIndex);
        if (entity == null) return;
        if (entity.GetComponent<IActiveLifeable>() == null) return;
        var entityTransform = entity.transform;
        var canvasHealth = Instantiate(healthBarPrefab, entityTransform.position + offset, Quaternion.identity, entityTransform);
        canvasHealth.InitHealthBar(entity);
    }
    
}
