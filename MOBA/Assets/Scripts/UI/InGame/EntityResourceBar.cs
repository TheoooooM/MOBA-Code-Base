using System;
using Entities;
using Entities.Champion;
using UnityEngine;
using UnityEngine.UI;

public class EntityResourceBar : MonoBehaviour
{
    [SerializeField] private Image resourceBar;
    private UIManager uiManager;

    private void Start()
    {
        uiManager = UIManager.Instance;
    }

    public void SetResourceByValue(float value)
    {
        resourceBar.fillAmount = value;
    }
    
    public void SetResourceByIndex(int entityIndex)
    {
        resourceBar.fillAmount = EntityCollectionManager.GetEntityByIndex(entityIndex).GetComponent<Champion>().GetCurrentResourcePercent();
    }
    
    public void SetActive(bool active)
    {
        resourceBar.gameObject.SetActive(active);
    }
}
