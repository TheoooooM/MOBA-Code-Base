using System;
using System.Collections;
using System.Collections.Generic;
using Entities;
using Entities.Champion;
using Photon.Pun;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(PhotonView))]
public class GameInstantiate : MonoBehaviourPun
{
   [SerializeField] private Champion playerPref;

   private void Start()
   {
      return;
      Vector3 pos = new Vector3(Random.Range(0f, 10f), 1, Random.Range(0f, 10f));
      Debug.Log(playerPref);
      Champion go = (Champion)PoolNetworkManager.Instance.PoolInstantiate(playerPref, pos, Quaternion.identity);
      go.SendStartPosition(pos);
      go.name = $"Player ID:{go.photonView.ViewID}";
   }
   
   
}
