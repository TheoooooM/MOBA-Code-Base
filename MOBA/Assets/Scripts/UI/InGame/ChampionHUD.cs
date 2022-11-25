using Entities;
using Entities.Capacities;
using Entities.Champion;
using UnityEngine;
using UnityEngine.UI;

public class ChampionHUD : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private Image resourceBar;
    [SerializeField] private Image spellPassive;
    [SerializeField] private Image spellOne;
    [SerializeField] private Image spellTwo;
    [SerializeField] private Image spellUltimate;
    [SerializeField] private Image spellPassiveCooldown;
    [SerializeField] private Image spellOneCooldown;
    [SerializeField] private Image spellTwoCooldown;
    [SerializeField] private Image spellUltimateCooldown;
    private IResourceable resourceable;
    private IActiveLifeable lifeable;
    private ICastable castable;

    public void InitHUD(Champion champion)
    {
        lifeable = champion.GetComponent<IActiveLifeable>();
        resourceable = champion.GetComponent<IResourceable>();
        castable = champion.GetComponent<ICastable>();
        var so = champion.championSo;

        healthBar.fillAmount = lifeable.GetCurrentHpPercent();
        resourceBar.fillAmount = resourceable.GetCurrentResourcePercent();
        
        UpdateIcons(champion);
        
        castable.OnCastFeedback += UpdateCooldown;

        lifeable.OnSetCurrentHpFeedback += UpdateFillPercentHealth;
        lifeable.OnSetCurrentHpPercentFeedback += UpdateFillPercentByPercentHealth;
        lifeable.OnIncreaseCurrentHpFeedback += UpdateFillPercentHealth;
        lifeable.OnDecreaseCurrentHpFeedback += UpdateFillPercentHealth;
        lifeable.OnIncreaseMaxHpFeedback += UpdateFillPercentHealth;
        lifeable.OnDecreaseMaxHpFeedback += UpdateFillPercentHealth;
        
        resourceable.OnSetCurrentResourceFeedback += UpdateFillPercentResource;
        resourceable.OnSetCurrentResourcePercentFeedback += UpdateFillPercentByPercentResource;
        resourceable.OnIncreaseCurrentResourceFeedback += UpdateFillPercentResource;
        resourceable.OnDecreaseCurrentResourceFeedback += UpdateFillPercentResource;
        resourceable.OnIncreaseMaxResourceFeedback += UpdateFillPercentResource;
        resourceable.OnDecreaseMaxResourceFeedback += UpdateFillPercentResource;
    }

    private void UpdateIcons(Champion champion)
    {
        var so = champion.championSo;
        spellPassive.sprite = champion.passiveCapacitiesList[0].AssociatedPassiveCapacitySO().icon;
        spellOne.sprite = so.activeCapacities[0].icon;
        spellTwo.sprite = so.activeCapacities[1].icon;
        spellUltimate.sprite = so.ultimateAbility.icon;
    }

    private void UpdateCooldown(byte capacityIndex, int[] intArray, Vector3[] vectors)
    {
        
    }
    
    private void UpdateFillPercentByPercentHealth(float value)
    {
        healthBar.fillAmount = value;
    }
    
    private void UpdateFillPercentHealth(float value)
    {
        healthBar.fillAmount = lifeable.GetCurrentHpPercent();
    }
    
    private void UpdateFillPercentByPercentResource(float value)
    {
        resourceBar.fillAmount = value;
    }

    private void UpdateFillPercentResource(float value)
    {
        resourceBar.fillAmount = resourceable.GetCurrentResource();
    }
}
