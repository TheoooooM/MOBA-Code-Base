using System.Collections;
using System.Collections.Generic;
using Entities;
using UnityEngine;

public class MinionSpawner : MonoBehaviour
{
    public Transform spawnPointForMinion;
    public Entity minionPrefab;
    public int spawnMinionAmount = 5;
    public float spawnMinionInterval = 1.7f;
    public float spawnCycleTime = 30;
    private readonly float spawnSpeed = 30;
    public Color minionColor;
    public List<Transform> pathfinding = new List<Transform>();
    public List<Objectives> enemyTowers = new List<Objectives>();
    public string unitTag;
    
    private void Update()
    {
        // Spawn de minion tous les spawnCycleTime secondes
        spawnCycleTime += Time.deltaTime;
        if (spawnCycleTime >= spawnSpeed)
        {
            StartCoroutine(SpawnMinionCo());
            spawnCycleTime = 0;
        }
    }
    
    private IEnumerator SpawnMinionCo()
    {
        for (int i = 0; i < spawnMinionAmount; i++)
        {
            SpawnMinion();
            yield return new WaitForSeconds(spawnMinionInterval);
        }
    }

    private void SpawnMinion()
    {
        Entity minionGO = PoolNetworkManager.Instance.PoolInstantiate(minionPrefab, spawnPointForMinion.position, Quaternion.identity);
        
        MinionTest minionScript = minionGO.GetComponent<MinionTest>();
        minionScript.myWaypoints = pathfinding;
        minionScript.TowersList = enemyTowers;
        minionScript.tag = unitTag;
        minionGO.GetComponent<MeshRenderer>().material.color = minionColor;
    }
}
