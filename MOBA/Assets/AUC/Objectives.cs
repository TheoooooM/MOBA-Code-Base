using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectives : MonoBehaviour
{
    public bool isAlive;
    public int maxHealth;
    public int currentHealth;
    
    private void Start()
    {
        currentHealth = maxHealth;
    }
}
