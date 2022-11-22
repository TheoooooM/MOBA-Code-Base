using System;
using System.Collections;
using System.Collections.Generic;
using Controllers.Inputs;
using Entities;
using Photon.Pun;
using UnityEngine;

public class TEST_blapeze : MonoBehaviour
{ 
    void Start()
    {
        switch (PhotonNetwork.LocalPlayer.ActorNumber)
        {
            case 1:
                Test_Controller_blapeze.team = Enums.Team.Team1;
                break;
            case 2:
                Test_Controller_blapeze.team = Enums.Team.Team2;
                break;
            case 3:
                Test_Controller_blapeze.team = Enums.Team.Team1;
                break;
            case 4:
                Test_Controller_blapeze.team = Enums.Team.Team2;
                break;
        }
        StartCoroutine(Pomme());

    }

    [PunRPC]
    public void AssignInventory(int index, int team)
    {
        int indexInventory = team;

        indexInventory += Convert.ToInt32(UIManager.Instance.InventoryAssigned(team));
        UIManager.Instance.AssignInventory(index, indexInventory);
    }
    
    IEnumerator Pomme()
    {
        yield return new WaitUntil(() => PhotonNetwork.CountOfPlayers == 2);
        yield return new WaitForSeconds(10);
        //if (GetComponent<Entity>().photonView.IsMine)
            GetComponent<Entity>().photonView.RPC("AssignInventory", RpcTarget.AllViaServer, PhotonNetwork.LocalPlayer.ActorNumber,
                ((int)PlayerInputController.team - 1) * 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
