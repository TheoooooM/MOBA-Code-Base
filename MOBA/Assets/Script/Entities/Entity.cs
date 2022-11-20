using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Entity : MonoBehaviourPun
{

    public int entityIndex; // view ID of the entity

    private PhotonView view;
    
    void Start()
    {
        view = GetComponent<PhotonView>();
        entityIndex = view.ViewID;
    }

    
    void Update()
    {
        
    }
}
