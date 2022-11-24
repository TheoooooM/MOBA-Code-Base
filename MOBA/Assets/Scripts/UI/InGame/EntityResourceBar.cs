using Entities;
using UnityEngine;
using UnityEngine.UI;

public class EntityResourceBar : MonoBehaviour
{
    [SerializeField] private Image resourceBar;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    public void SetResourceByValue(float value)
    {
        resourceBar.fillAmount = value;
    }
    
    public void SetResourceByIndex(int entityIndex)
    {
        transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward, cam.transform.rotation * Vector3.up);
        resourceBar.fillAmount = EntityCollectionManager.GetEntityByIndex(entityIndex).GetComponent<IResourceable>().GetCurrentResourcePercent();
    }
    
    public void SetActive(bool active)
    {
        resourceBar.gameObject.SetActive(active);
    }
}
