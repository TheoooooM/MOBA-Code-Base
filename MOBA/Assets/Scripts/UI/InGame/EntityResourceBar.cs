using Entities;
using UnityEngine;
using UnityEngine.UI;

namespace UIComponents
{
    public class EntityResourceBar : MonoBehaviour
    {
        [SerializeField] private Image resourceBar;
        private Entity linkedEntity;
        private IResourceable resourceable;
        private Camera cam;

        private void Start()
        {
            cam = Camera.main;
        }

        public void InitResourceBar(Entity entity)
        {
            linkedEntity = entity;
            resourceable = entity.GetComponent<IResourceable>();

            transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward, cam.transform.rotation * Vector3.up);
            resourceBar.fillAmount = resourceable.GetCurrentResourcePercent();

            resourceable.OnSetCurrentResourceFeedback += UpdateFillPercentByPercent;
            resourceable.OnIncreaseCurrentResourceFeedback += UpdateFillPercent;
            resourceable.OnDecreaseCurrentResourceFeedback += UpdateFillPercent;
        }

        private void UpdateFillPercentByPercent(float value)
        {
            resourceBar.fillAmount = value;
        }

        private void UpdateFillPercent(float value)
        {
            resourceBar.fillAmount = resourceable.GetCurrentResource();
        }

        public void SetActive(bool active)
        {
            resourceBar.gameObject.SetActive(active);
        }
    }
}