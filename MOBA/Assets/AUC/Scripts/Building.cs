using System.Collections;
using System.Collections.Generic;
using Entities;
using UnityEngine;

namespace Entities
{
    public class Building : Entity
    {
        [Space]
        [Header("Life Building settings")]
        public bool isAlive;
        public int maxHealth;
        public int currentHealth;

        protected override void OnStart()
        {
            base.OnStart();
            currentHealth = maxHealth;
        }
    }
}

