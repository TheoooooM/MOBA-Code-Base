using System;
using System.Collections;
using System.Collections.Generic;
using Entities;
using Photon.Pun;
using UnityEngine;

public class PoolNetworkManager : MonoBehaviour
{
    [Serializable]
    public class ElementData
    {
        public Entity Element;
        public uint amount;
    }

    private bool isSetup;

    public static PoolNetworkManager Instance;

    [SerializeField] private List<ElementData> poolElements;

    private static Dictionary<Entity, Queue<Entity>> queuesDictionary;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        Instance = this;
        SetupDictionary();
    }

    private void Start()
    {
        
    }

    private void SetupDictionary()
    {
        queuesDictionary = new Dictionary<Entity, Queue<Entity>>();
        foreach (var elementData in poolElements)
        {
            Queue<Entity> newQueue = new Queue<Entity>();
            for (int i = 0; i < elementData.amount; i++)
            {
                Entity entity = Instantiate(elementData.Element, transform);
                entity.gameObject.SetActive(false);
                newQueue.Enqueue(entity);
            }
            queuesDictionary.Add(elementData.Element, newQueue);
        }
    }

    public Entity PoolInstantiate(Entity entityRef, Vector3 position, Quaternion rotation, Transform parent = null)
    {
        if(!isSetup)SetupDictionary();
        Debug.Log(entityRef);
        Entity entity;
        if (parent == null) parent = transform;
        if (queuesDictionary.ContainsKey(entityRef))
        {
            var queue = queuesDictionary[entityRef];
            if (queue.Count == 0)
            {
                entity = PhotonNetwork.Instantiate(entityRef.gameObject.name, position, rotation).GetComponent<Entity>();
            }
            else
            {
                entity = queue.Dequeue();
                entity.SendSyncInstantiate(position,rotation);
            }
        }
        else
        {
            Debug.Log("New pool of " + entityRef.gameObject.name);
            queuesDictionary.Add(entityRef, new Queue<Entity>());
            
            entity = Instantiate(entityRef, position, rotation, parent);
        }

        return entity;
    }
}
