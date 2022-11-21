using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controllers
{
    public class CameraController : MonoBehaviour
    {

        private void Awake()
        {
            SetupInputMap();
            InputManager.PlayerMap.Camera.LockToggle.performed += OnToggleCameraLock;
        }

        /// <summary>
        /// Setup the Camera InputMap of The Player inputs
        /// </summary>
        void SetupInputMap()
        {
            InputManager.PlayerMap = new PlayerInputs();
            InputManager.PlayerMap.Enable();
        }

        /// <summary>
        /// Actions Performed on Toggle CameraLock
        /// </summary>
        /// <param name="ctx"></param>
        void OnToggleCameraLock(InputAction.CallbackContext ctx)
        {
        }
    }
}
