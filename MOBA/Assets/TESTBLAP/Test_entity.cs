using System;
using System.Collections;
using System.Collections.Generic;
using Entities;
using Entities.Inventory;
using Photon.Pun;
using UnityEngine;

public class Test_entity : Entity, IInventoryable
{
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

    public Item GetItemOfSo(int soIndex)
    {
        throw new NotImplementedException();
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
    public void RequestActivateItem(byte itemIndex, int[] selectedEntities, Vector3[] positions)
    {
        throw new NotImplementedException();
    }

    public void ActivateItemRPC(byte index, int[] selectedEntities, Vector3[] positions)
    {
        throw new NotImplementedException();
    }

    public void SyncActivateItemRPC(byte index, int[] selectedEntities, Vector3[] positions)
    {
        throw new NotImplementedException();
    }

    public void RequestActivateItem(byte itemIndex)
    {
        throw new NotImplementedException();
    }

    public void SyncActivateItemRPC(byte index)
    {
        throw new NotImplementedException();
    }

    public void ActivateItemRPC(byte index)
    {
        throw new NotImplementedException();
    }

    public event GlobalDelegates.ByteIntArrayVector3ArrayDelegate OnActivateItem;
    public event GlobalDelegates.ByteIntArrayVector3ArrayDelegate OnActivateItemFeedback;


    private int teamTMP = 1;

        IEnumerator Pomme()
    {
        //yield return new WaitUntil(() => PhotonNetwork.CountOfPlayers == 4);
        yield return new WaitForSeconds(4);
        EntityCollectionManager.AddEntity(this);
        
        //UIManager.Instance.AssignInventory((int)entityIndex, teamTMP);
    }
        protected void Start()
    {
        UIManager.ClickOnItem += RequestAddItem;

        entityIndex = photonView.ViewID;

        switch (entityIndex)
        {
            case 1001:
                teamTMP = 1;
                break;
            case 2001:
                teamTMP = 2;
                break;
            case 3001:
                teamTMP = 1;
                break;
            case 4001:
                teamTMP = 2;
                break;
        }

        StartCoroutine(Pomme());
    }        
}
