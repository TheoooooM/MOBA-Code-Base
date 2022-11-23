using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancePlayer : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    private void Start()
    {
        Instantiate(playerPrefab);
    }
}