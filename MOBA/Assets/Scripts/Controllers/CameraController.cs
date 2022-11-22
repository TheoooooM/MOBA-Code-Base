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
        public static CameraController Instance;

        public void Awake()
        {
            if (Instance != null && Instance != this)
            {
                DestroyImmediate(gameObject);
                return;
            }
            
            Instance = this;
        }

        public void LinkCamera(Transform target)
        {
            player = target;
            InputManager.PlayerMap.Camera.LockToggle.performed += OnToggleCameraLock;
        }

        public void UnLinkCamera()
        {
            player = null;
            InputManager.PlayerMap.Camera.LockToggle.performed -= OnToggleCameraLock;
        }
        
        /// <summary>
        /// Actions Performed on Toggle CameraLock
        /// </summary>
        /// <param name="ctx"></param>
        private void OnToggleCameraLock(InputAction.CallbackContext ctx)
        {
            if (!ctx.performed) return;
            cameraLock = !cameraLock;
            Debug.Log("Camera Lock Toggled");
        }
        
        private void LateUpdate()
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
