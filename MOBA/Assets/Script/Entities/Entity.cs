using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Entity : MonoBehaviourPun
{

    public uint entityIndex; // view ID of the entity

    private PhotonView view;
    
    void Start()
    {
        view = GetComponent<PhotonView>();
        entityIndex = (uint)view.ViewID;
    }

    
    void Update()
    {
        
    }
}
