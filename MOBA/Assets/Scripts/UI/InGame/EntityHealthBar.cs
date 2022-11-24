using UnityEngine;
using UnityEngine.UI;

public class EntityHealthBar : MonoBehaviour
{
    public static EntityHealthBar Instance;
    
    [SerializeField] private Image healthBar;
    
    public void SetHealth(float health)
    {
        healthBar.fillAmount = health;
    }
}
