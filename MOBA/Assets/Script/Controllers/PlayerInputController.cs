using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controllers.Inputs
{
    public abstract class PlayerInputController : Controller
    {
        protected PlayerInputs inputMap;

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
            inputMap = new PlayerInputs();
            inputMap.Enable();
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