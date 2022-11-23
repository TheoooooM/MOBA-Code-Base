using Entities.Champion;
using UnityEngine;
using UnityEngine.UI;

public partial class UIManager
{
    // Find the UI elements in the scene
    // and make them follow the player
    [SerializeField] private Image healthBar;
    
    public void UpdateLifeBar()
    {
        float resource = player.GetComponent<Champion>().GetCurrentHp();
        healthBar.fillAmount = resource;
    }
    
    public void LinkLifeUI(Transform target)
    {
        player = target;
    }
}
