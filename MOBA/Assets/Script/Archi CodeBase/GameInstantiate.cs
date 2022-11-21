using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(PhotonView))]
public class GameInstantiate : MonoBehaviourPun
{
   [SerializeField] private GameObject playerPref;

   private void Start()
   {
      Vector3 pos = new Vector3(Random.Range(0f, 10f), 1, Random.Range(0f, 10f));
      GameObject go = PhotonNetwork.Instantiate(playerPref.name, pos, Quaternion.identity);
      go.name = $"Player ID:{go.GetComponent<PhotonView>().ViewID}";
   }
   
   
}
