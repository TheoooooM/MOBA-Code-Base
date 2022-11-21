using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace Controllers
{
    public abstract class Controller : MonoBehaviourPun
    {
        protected Entity controlledEntity;

         void Awake()
        {
            OnAwake();
        }

         protected virtual void OnAwake()
         {
             controlledEntity = GetComponent<Entity>();
         }
    }
}