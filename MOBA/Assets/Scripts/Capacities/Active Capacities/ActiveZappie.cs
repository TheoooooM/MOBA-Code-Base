using UnityEngine;

namespace Entities.Capacities
{
    public class ActiveZappie : ActiveCapacity
    {
        private ActiveZappieSO so;
        private Vector3 dir;
        
        public override ActiveCapacitySO AssociatedActiveCapacitySO()
        {
            return CapacitySOCollectionManager.Instance.GetActiveCapacitySOByName(so.name);
        }

        public override bool TryCast(uint entityIndex, uint[] targets, Vector3[] position)
        {
            so = (ActiveZappieSO)AssociatedActiveCapacitySO();
            
            position[0].y = 1;
            var casterPos = caster.transform.position;
            casterPos.y = 1;
            
            dir = (position[0] - casterPos).normalized;
            
            return true;
        }

        public override void PlayFeedback()
        {
            var instantiateObj = PoolLocalManager.Instance.PoolInstantiate(so.projectile, caster.transform.position, Quaternion.identity);
            var damageOnCollide = instantiateObj.GetComponent<DamageOnCollide>();
            
            damageOnCollide.damage = so.damageAmount;
            
            instantiateObj.GetComponent<Rigidbody>().AddForce(dir * so.speed, ForceMode.Impulse);
        }
    }
}

