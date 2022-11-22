using Photon.Pun;
using Entities;

namespace Controllers
{
    public abstract class Controller : MonoBehaviourPun
    {
        protected Entity controlledEntity;

        private void Awake()
        {
            OnAwake();
        }

         protected virtual void OnAwake()
         {
             controlledEntity = GetComponent<Entity>();
         }
    }
}