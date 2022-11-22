namespace Controllers.Inputs
{
    public abstract class PlayerInputController : Controller
    {
        public static Enums.Team team;

        protected override void OnAwake()
        {
            base.OnAwake();
            if(!controlledEntity.photonView.IsMine) return;
            
            SetupInputMap();
            Link();
        }

        /// <summary>
        /// Setup the InputMap of The Player inputs
        /// </summary>
        void SetupInputMap()
        {
            InputManager.PlayerMap = new PlayerInputs();
            InputManager.PlayerMap.Enable();
        }

        /// <summary>
        /// Link Inputs to CallBacks Actions
        /// </summary>
        protected virtual void Link() 
        {
        }

        /// <summary>
        /// Unlink Inputs to CallBacks Actions
        /// </summary>
        protected virtual void Unlink()
        {

        }
    }
}
