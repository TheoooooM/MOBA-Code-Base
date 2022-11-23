using Entities.Champion;
using UnityEngine;
using UnityEngine.UI;

public partial class UIManager
{
    // Find the UI elements in the scene
    // and make them follow the player
    [SerializeField] private Image resourceBar;

    public void UpdateResourceBar()
    {
        float resource = player.GetComponent<Champion>().GetCurrentResource();
        resourceBar.fillAmount = resource;
    }
    
    public void LinkResourceUI(Transform target)
    {
        player = target;
    }
}
