using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controllers
{
    public class CameraController : MonoBehaviour
    {
        private PlayerInputs inputMap;

        private void Awake()
        {
            SetupInputMap();
            inputMap.Camera.LockToggle.performed += OnToggleCameraLock;
        }

        /// <summary>
        /// Setup the Camera InputMap of The Player inputs
        /// </summary>
        void SetupInputMap()
        {
            inputMap = new PlayerInputs();
            inputMap.Enable();
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
