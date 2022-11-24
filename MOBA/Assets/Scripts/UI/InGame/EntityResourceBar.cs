using UnityEngine;
using UnityEngine.UI;

public class EntityResourceBar : MonoBehaviour
{
    public static EntityResourceBar Instance;
    
    [SerializeField] private Image resourceBar;
    
    public void SetResource(float value)
    {
        resourceBar.fillAmount = value;
    }
    
    public void SetResource(int entityIndex, float value)
    {
        UIManager.Instance.entitiesResource[entityIndex].resourceBar.fillAmount = value;
    }
    
    public void SetActive(int entityIndex, bool active)
    {
        UIManager.Instance.entitiesResource[entityIndex].gameObject.SetActive(active);
    }
}
