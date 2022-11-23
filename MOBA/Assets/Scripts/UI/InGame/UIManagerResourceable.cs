using System.Collections.Generic;
using Entities;
using UnityEngine;
using UnityEngine.UI;

public partial class UIManager
{
    [SerializeField] private Dictionary<uint, GameObject> entitiesResource = new Dictionary<uint, GameObject>();
    [SerializeField] private GameObject resourceBarPrefab;
    
    public void InstantiateResourceBarForEntity(uint entityIndex)
    {
        if (EntityCollectionManager.GetEntityByIndex(entityIndex) != null && EntityCollectionManager.GetEntityByIndex(entityIndex).GetComponent<IResourceable>() != null)
        {
            Transform entityTransform = EntityCollectionManager.GetEntityByIndex(entityIndex).transform;
            GameObject ResourceBar = Instantiate(resourceBarPrefab, entityTransform.position, Quaternion.identity, entityTransform.GetComponentInChildren<Canvas>().transform);
            ResourceBar.transform.LookAt(Camera.main.transform);
            entitiesResource.Add(entityIndex, ResourceBar);
            SetResourceBar(entityIndex);
        }
    }

    public void SetResourceBar(uint entityIndex)
    {
        if (entitiesHealth.ContainsKey(entityIndex))
        {
            GameObject resourceBar = entitiesHealth[entityIndex];
            resourceBar.GetComponentInChildren<Image>().fillAmount = EntityCollectionManager.GetEntityByIndex(entityIndex).GetComponent<IResourceable>().GetCurrentResourcePercent();
        }
    }
}
