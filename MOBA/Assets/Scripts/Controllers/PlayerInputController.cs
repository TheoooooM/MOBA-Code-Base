using Entities;
using Photon.Pun;

namespace Controllers.Inputs
{
    public abstract class PlayerInputController : Controller
    {
        protected override void OnAwake()
        {
            base.OnAwake();
            //SetupInputMap();
            //Link(controlledEntity);
        }

        /// <summary>
        /// Setup the InputMap of The Player inputs
        /// </summary>
        private void SetupInputMap()
        {
            InputManager.PlayerMap = new PlayerInputs();
            InputManager.PlayerMap.Enable();
        }
        
        public void LinkToPlayer()
        {
            if(!controlledEntity.photonView.IsMine) return;
            SetupInputMap();
            Link(controlledEntity);
        }
    }
}
