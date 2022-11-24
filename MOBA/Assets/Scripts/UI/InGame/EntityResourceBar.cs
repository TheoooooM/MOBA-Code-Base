using UnityEngine;
using UnityEngine.UI;

public class EntityResourceBar : MonoBehaviour
{
    public static EntityResourceBar Instance;
    
    [SerializeField] private Image resourceBar;
    
    public void SetResource(float health)
    {
        resourceBar.fillAmount = health;
    }
}
