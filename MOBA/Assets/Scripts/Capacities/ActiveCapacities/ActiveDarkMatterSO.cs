using Entities;
using Entities.Capacities;
using UnityEngine;


[CreateAssetMenu(menuName = "Capacity/ActiveCapacitySO/Dark Matter", fileName = "new Dark Matter")]
public class ActiveDarkMatterSO : ActiveCapacitySO
{
    public float zoneRadius;
    public float damageAmount;
    
    public override void TryCast(uint[] targets, Vector3[] direction)
    {
        Collider[] detected = Physics.OverlapSphere(direction[0], zoneRadius);

        foreach (var hit in detected)
        {
            Entity entityTouch = hit.GetComponent<Entity>();
            
            if (entityTouch)
            {
                IActiveLifeable entityActiveLifeable = entityTouch.GetComponent<IActiveLifeable>();
                
                entityActiveLifeable.DecreaseCurrentHpRPC(damageAmount);
            }
        }

    }

    public override void PlayFeedback()
    {
        throw new System.NotImplementedException();
    }
}
