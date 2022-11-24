using UnityEngine;
using UnityEngine.UI;

public class EntityHealthBar : MonoBehaviour
{
    public static EntityHealthBar Instance;
    
    [SerializeField] private Image healthBar;

    public void SetHealth(float value)
    {
        healthBar.fillAmount = value;
    }
    
    public void SetHealth(int entityIndex, float value)
    {
        UIManager.Instance.entitiesHealth[entityIndex].healthBar.fillAmount = value;
    }
    
    public void SetActive(int entityIndex, bool active)
    {
        UIManager.Instance.entitiesHealth[entityIndex].gameObject.SetActive(active);
    }
}
