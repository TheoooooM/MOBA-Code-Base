using System;
using System.Collections;
using System.Collections.Generic;
using Entities;
using Entities.Inventory;
using Photon.Pun;
using UnityEngine;

public class Test_entity : Entity, IInventoryable
{
    public int teamTMP = -1;
    
    protected override void OnStart()
    {
        
    }

    protected override void OnUpdate()
    {
        
    }

    public override void OnInstantiated()
    {

    }

    public override void OnInstantiatedFeedback()
    {

    }

    public Item[] GetItems()
    {
        
        throw new System.NotImplementedException();
    }

    public Item GetItem(int index)
    {
        throw new System.NotImplementedException();
    }

    public void RequestAddItem(byte index)
    {
        throw new System.NotImplementedException();
    }

    public void SyncAddItemRPC(byte index)
    {
        throw new System.NotImplementedException();
    }

    public void AddItemRPC(byte index)
    {
        throw new System.NotImplementedException();
    }

    public event GlobalDelegates.ByteDelegate OnAddItem;
    public event GlobalDelegates.ByteDelegate OnAddItemFeedback;
    
    public void RequestRemoveItem(byte index)
    {
        throw new System.NotImplementedException();
    }

    public void RequestRemoveItem(Item item)
    {
        throw new System.NotImplementedException();
    }

    public void SyncRemoveItemRPC(byte index)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveItemRPC(byte index)
    {
        throw new System.NotImplementedException();
    }

    public event GlobalDelegates.ByteDelegate OnRemoveItem;
    public event GlobalDelegates.ByteDelegate OnRemoveItemFeedback;
    
    
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
        if (GetComponent<Entity>().photonView.IsMine)
         GetComponent<Entity>().photonView.RPC("AssignInventory", RpcTarget.AllViaServer, PhotonNetwork.LocalPlayer.ActorNumber,
             ((int)teamTMP - 1) * 2);
    }
    
    private void Start()
    {
        //UIManager.Instance.ClickOnItem += RequestAddItem;
        switch (PhotonNetwork.LocalPlayer.ActorNumber)
        {
            case 1:
                teamTMP = 1;
                break;
            case 2:
                teamTMP = 2;
                break;
            case 3:
                teamTMP = 1;
                break;
            case 4:
                teamTMP = 2;
                break;
        }
        StartCoroutine(Pomme());
    }
}
