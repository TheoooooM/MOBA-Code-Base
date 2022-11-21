using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
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

        protected override void OnAwake()
        {
            base.OnAwake();
        }

        private void Start()
        {
            champion = controlledEntity as Champion;
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
                return (uint)hit.transform.GetComponent<Entity>()?.entityIndex;
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
        /// Actions Performed on Move
        /// </summary>
        /// <param name="ctx"></param>
        void OnMove(InputAction.CallbackContext ctx)
        {
            
        }

        protected override void Link()
        {
            InputManager.PlayerMap.Attack.Attack.performed += OnAttack;
            
            InputManager.PlayerMap.Capacity.Capacity0.performed += OnActivateCapacity0;
            InputManager.PlayerMap.Capacity.Capacity1.performed += OnActivateCapacity1;
            InputManager.PlayerMap.Capacity.Capacity2.performed += OnActivateCapacity2;
            
            InputManager.PlayerMap.Movement.Move.performed += OnMove;
        }
        
        protected override void Unlink()
        {
            InputManager.PlayerMap.Attack.Attack.performed -= OnAttack;
            
            InputManager.PlayerMap.Capacity.Capacity0.performed -= OnActivateCapacity0;
            InputManager.PlayerMap.Capacity.Capacity1.performed -= OnActivateCapacity1;
            InputManager.PlayerMap.Capacity.Capacity2.performed -= OnActivateCapacity2;
            
            InputManager.PlayerMap.Movement.Move.performed -= OnMove;
        }
    }
}
