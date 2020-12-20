using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] enemies;
    [SerializeField] private CircularGrid grid;
    private List<SnapPoint> freeSnapPoints = new List<SnapPoint>();
    private Enemy enemyToSpawn;
    private SnapPoint tempSnapPoints;
    [SerializeField] private Combat combat;
    [SerializeField] private Quest quest;
    [SerializeField] private EnemiesMover enemiesMover;
    private void Start()
    {
        SpawnEnemy();
        combat.OnNewTurn += SpawnEnemy;
    }
    [Button]
    private void SpawnEnemy()
    {
        enemyToSpawn = enemies[Random.Range(0, enemies.Length)];
        GetFreeSnapPoints();
        if (freeSnapPoints.Count == 0)
            return;
        enemyToSpawn = Instantiate(enemyToSpawn, GetSpawnPosition(), Quaternion.identity);
        enemyToSpawn.CurrentSnapPoint = tempSnapPoints;
        enemyToSpawn.OnDeatForQuest += quest.CheckQuests;
        enemiesMover.AddEnemy(enemyToSpawn);
        combat.AddEnemy(enemyToSpawn);
        
    }
    private Vector3 GetSpawnPosition()
    {
        tempSnapPoints = freeSnapPoints[Random.Range(0, freeSnapPoints.Count)];
        tempSnapPoints.IsFree = false;
        return tempSnapPoints.Position;
    }
    private void GetFreeSnapPoints()
    {
        freeSnapPoints.Clear();
        foreach (var item in grid.SnapPoints)
        {
            if (item.IsFree)
                freeSnapPoints.Add(item);
        }
    }

}
