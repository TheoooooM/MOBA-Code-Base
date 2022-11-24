using Entities;
using UnityEngine;
using UnityEngine.UI;

namespace UIComponents
{
    public class EntityHealthBar : MonoBehaviour
    {
        [SerializeField] private Image healthBar;
        private Entity linkedEntity;
        private IActiveLifeable lifeable;
        private Camera cam;

        private void Start()
        {
            cam = Camera.main;
        }
    
        public void InitHealthBar(Entity entity)
        {
            linkedEntity = entity;
            lifeable = entity.GetComponent<IActiveLifeable>();
        
            transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward, cam.transform.rotation * Vector3.up);
            healthBar.fillAmount = lifeable.GetCurrentHpPercent();
               
            lifeable.OnSetCurrentHpPercentFeedback += UpdateFillPercentByPercent;
            lifeable.OnIncreaseCurrentHpFeedback += UpdateFillPercent;
            lifeable.OnDecreaseCurrentHpFeedback += UpdateFillPercent;
        }

        private void UpdateFillPercentByPercent(float value)
        {
            healthBar.fillAmount = value;
        }
    
        private void UpdateFillPercent(float value)
        {
            healthBar.fillAmount = lifeable.GetCurrentHpPercent();
        }

        public void SetActive(bool active)
        {
            healthBar.gameObject.SetActive(active);
        }
    }

}

