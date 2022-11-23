using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace Entities.Capacities
{
    public class DamageOnCollide : MonoBehaviour
    {
        [HideInInspector] public Entity caster;
        public float damage;
        [SerializeField] private List<byte> effectIndex = new List<byte>();
        
        private void OnTriggerEnter(Collider other)
        {
            Entity entity = other.GetComponent<Entity>();

            if (entity)
            {
                IActiveLifeable activeLifeable = entity.GetComponent<IActiveLifeable>();
                
                if (PhotonNetwork.IsMasterClient)
                {
                    activeLifeable.DecreaseCurrentHpRPC(damage);

                    foreach (byte index in effectIndex)
                    {
                        //TODO entity.AddPassive(index)
                    }
                }
            }
        }
    }
}


