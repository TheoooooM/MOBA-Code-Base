using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controllers
{
    public class CameraController : MonoBehaviour 
    {
        //Script for the camera to follow the player
        [SerializeField] private Transform player;
        
        [SerializeField] private float cameraDistance = 10f;
        [SerializeField] private float cameraHeight = 5f;
    
        [SerializeField] private float cameraSpeed = 0.1f;
        
        private bool cameraLock = true;
        private static CameraController mainCamera;

        private void Awake()
        {
            SetupInputMap();
            InputManager.PlayerMap.Camera.LockToggle.performed += OnToggleCameraLock;
        }

        private void Start()
        {
            mainCamera = this;
            //convert the camera Height to degrees
        }

        //create a static method to call from other scripts that links the transform of the player to the camera
        public static void SetPlayer(Transform player)
        {
            mainCamera.player = player;
        }
        

        /// <summary>
        /// Setup the Camera InputMap of The Player inputs
        /// </summary>
        void SetupInputMap()
        {
            InputManager.PlayerMap = new PlayerInputs();
            InputManager.PlayerMap.Enable();
            Debug.Log("Input Map Set Up");
        }

        /// <summary>
        /// Actions Performed on Toggle CameraLock
        /// </summary>
        /// <param name="ctx"></param>
        void OnToggleCameraLock(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                cameraLock = !cameraLock;
                Debug.Log("Camera Lock Toggled");
            }
        }
        
        private void Update()
        {
            //if the player is not null
            if (player !=  null)
            {
                //if the camera is locked the camera follows the player
                if (cameraLock)
                {
                    transform.position = new Vector3(player.position.x - cameraDistance,
                        player.position.y + cameraHeight, player.position.z - cameraDistance);
                    transform.LookAt(player);
                    Debug.Log("Camera Locked");
                }
                else
                {
                    //if the mouse is at the edge of the screen the camera moves
                    if (Input.mousePosition.x >= Screen.width - 1)
                    {
                        transform.position += new Vector3(cameraSpeed, 0, -cameraSpeed);
                    }

                    if (Input.mousePosition.x <= 0)
                    {
                        transform.position += new Vector3(-cameraSpeed, 0, cameraSpeed);
                    }

                    if (Input.mousePosition.y >= Screen.height - 1)
                    {
                        transform.position += new Vector3(cameraSpeed, 0, cameraSpeed);
                    }

                    if (Input.mousePosition.y <= 0)
                    {
                        transform.position += new Vector3(-cameraSpeed, 0, -cameraSpeed);
                    }

                    Debug.Log("Camera Unlocked");
                }
            }
        }
    }
}
