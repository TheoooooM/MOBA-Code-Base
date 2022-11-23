using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Entities;
using Entities.Champion;

namespace Controllers.Inputs
{
    public class ChampionInputController : PlayerInputController
    {
        private Champion champion;
        private uint[] selectedEntity;
        private Vector3 cursorWorldPos;
        private bool isMoving;
        private Vector2 moveInput;
        private Vector3 moveVector;

        protected override void OnAwake()
        {
            base.OnAwake();
        }

        private void Start()
        {
            champion = controlledEntity as Champion;
        }

        private void Update()
        {
        }


        /// <summary>
        /// Actions Performed on Attack Activation
        /// </summary>
        /// <param name="ctx"></param>
        private void OnAttack(InputAction.CallbackContext ctx){}
        
        /// <summary>
        /// Actions Performed on Capacity 0 Activation
        /// </summary>
        /// <param name="ctx"></param>
        private void OnActivateCapacity0(InputAction.CallbackContext ctx)
        {
        }
        /// <summary>
        /// Actions Performed on Capacity 1 Activation
        /// </summary>
        /// <param name="ctx"></param>
        private void OnActivateCapacity1(InputAction.CallbackContext ctx)
        {
        }
        /// <summary>
        /// Actions Performed on Capacity 2 Activation
        /// </summary>
        /// <param name="ctx"></param>
        private void OnActivateCapacity2(InputAction.CallbackContext ctx)
        {
        }

        /// <summary>
        /// Actions Performed on Item 0 Activation
        /// </summary>
        /// <param name="ctx"></param>
        private void OnActivateItem0(InputAction.CallbackContext ctx)
        {
        }
        /// <summary>
        /// Actions Performed on Item 1 Activation
        /// </summary>
        /// <param name="ctx"></param>
        private void OnActivateItem1(InputAction.CallbackContext ctx)
        {
        }
        /// <summary>
        /// Actions Performed on Item 2 Activation
        /// </summary>
        /// <param name="ctx"></param>
        private void OnActivateItem2(InputAction.CallbackContext ctx)
        {
        }

        /// <summary>
        /// Get Entity(ies) point by mouse
        /// </summary>
        /// <param name="mousePos"></param>
        /// <returns></returns>
        private uint GetMouseOverEntity(Vector2 mousePos)
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(mouseRay, out RaycastHit hit))
            {
                var ent = hit.transform.GetComponent<Entity>();
                if (ent) return ent.entityIndex;
            }

            return 999999;
        }
        /// <summary>
        /// Get World Position of mouse
        /// </summary>
        /// <param name="mousePos"></param>
        /// <returns></returns>
        private Vector3 GetMouseOverWorldPos(Vector2 mousePos)
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(mouseRay, out RaycastHit hit))
            {
                return hit.point;
            }

            return Vector3.zero;
        }

        /// <summary>
        /// Actions Performed on Move direction Change
        /// </summary>
        /// <param name="ctx"></param>
        void OnMoveChange(InputAction.CallbackContext ctx)
        {
            Debug.Log("Move");
            moveInput = ctx.ReadValue<Vector2>();
            moveVector = new Vector3(moveInput.x, 0, moveInput.y);
            champion.RequestMoveDir(moveVector);
        }

        protected override void Link()
        {
            InputManager.PlayerMap.Attack.Attack.performed += OnAttack;
            
            InputManager.PlayerMap.Capacity.Capacity0.performed += OnActivateCapacity0;
            InputManager.PlayerMap.Capacity.Capacity1.performed += OnActivateCapacity1;
            InputManager.PlayerMap.Capacity.Capacity2.performed += OnActivateCapacity2;

            InputManager.PlayerMap.Movement.Move.performed += OnMoveChange;
            InputManager.PlayerMap.Movement.Move.canceled += OnMoveChange;
            CameraController.Instance.LinkCamera(controlledEntity.transform);
        }
        
        protected override void Unlink()
        {
            InputManager.PlayerMap.Attack.Attack.performed -= OnAttack;
            
            InputManager.PlayerMap.Capacity.Capacity0.performed -= OnActivateCapacity0;
            InputManager.PlayerMap.Capacity.Capacity1.performed -= OnActivateCapacity1;
            InputManager.PlayerMap.Capacity.Capacity2.performed -= OnActivateCapacity2;
            
            InputManager.PlayerMap.Movement.Move.performed -= OnMoveChange;
            InputManager.PlayerMap.Movement.Move.canceled -= OnMoveChange;
            CameraController.Instance.UnLinkCamera();
        }
    }
}
