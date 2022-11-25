using UnityEngine;

namespace Entities.Capacities
{
    public class ActiveZappie : ActiveCapacity
    {
        private ActiveZappieSO so;
        private Vector3 dir;

        public override bool TryCast(int casterIndex, int[] targets, Vector3[] position)
        {
            if (!base.TryCast(casterIndex, targets, position)) return false;
            
            Debug.Log("Perform a zappie bro");
            
            so = (ActiveZappieSO)AssociatedActiveCapacitySO();
            
            position[0].y = 1;
            var casterPos = caster.transform.position;
            casterPos.y = 1;
            
            dir = (position[0] - casterPos).normalized;
            
            Debug.Log(position[0]);
            
            return true;
        }

        public override void PlayFeedback(int casterIndex, int[] targetsEntityIndexes, Vector3[] targetPositions)
        {
            so = (ActiveZappieSO)AssociatedActiveCapacitySO();
            
            var instantiateObj = PoolLocalManager.Instance.PoolInstantiate(so.projectile, caster.transform.position, Quaternion.identity);
            var damageOnCollide = instantiateObj.GetComponent<DamageOnCollide>();
            
            damageOnCollide.damage = so.damageAmount;
            damageOnCollide.speed = so.speed;
            damageOnCollide.dir = dir;
        }
    }
}

