using System;
using Entities;
using Entities.Champion;
using UnityEngine;
using UnityEngine.UI;

public class EntityHealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    private UIManager uiManager;

    private void Start()
    {
        uiManager = UIManager.Instance;
    }

    public void SetHealthByValue(float value)
    {
        healthBar.fillAmount = value;
    }
    
    public void SetHealthByIndex(int entityIndex)
    {
        healthBar.fillAmount = EntityCollectionManager.GetEntityByIndex(entityIndex).GetComponent<Champion>().GetCurrentHpPercent();
    }
    
    public void SetActive(bool active)
    {
        healthBar.gameObject.SetActive(active);
    }
}
