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
        photonView.RPC("AddItemRPC", RpcTarget.MasterClient, index);
    }

    [PunRPC]
    public void SyncAddItemRPC(byte index)
    {
        UIManager.Instance.UpdateInventory(ItemCollectionManager.currentItems, entityIndex, this.photonView.ViewID);
    }

    [PunRPC]
    public void AddItemRPC(byte index)
    {
        if (ItemCollectionManager.currentItems.Count >= 3)
            return;

        //Item newItem = ItemCollectionManager.GetItem(index);

        ItemCollectionManager.TryAddToCurrentItems(index);

        //photonView.RPC("SyncAddItemRPC", RpcTarget.All, index);
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

    [PunRPC]
    public void SyncRemoveItemRPC(byte index)
    {
        throw new System.NotImplementedException();
    }

    [PunRPC]
    public void RemoveItemRPC(byte index)
    {
        throw new System.NotImplementedException();
    }

    public event GlobalDelegates.ByteDelegate OnRemoveItem;
    public event GlobalDelegates.ByteDelegate OnRemoveItemFeedback;


    IEnumerator Pomme()
    {
        //yield return new WaitUntil(() => PhotonNetwork.CountOfPlayers == 2);
        yield return new WaitForSeconds(4);
        EntityCollectionManager.AddEntity(this);


        UIManager.Instance.AssignInventory((int)entityIndex, teamTMP);
    }

    private void Start()
    {
        UIManager.ClickOnItem += RequestAddItem;

        entityIndex = (uint)photonView.ViewID;

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