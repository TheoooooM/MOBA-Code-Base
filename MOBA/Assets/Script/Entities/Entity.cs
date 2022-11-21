using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;


public class Entity : MonoBehaviourPun
{

    public uint entityIndex;
    
    void Start()
    {
        entityIndex = (uint)photonView.ViewID;
    }

    
    void Update()
    {
        
    }
}
