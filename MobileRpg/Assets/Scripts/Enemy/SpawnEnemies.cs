using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private Enemy[] enemies;
    [SerializeField] private CircularGrid grid;
    private List<SnapPoint> freeSnapPoints = new List<SnapPoint>();
    private Enemy enemyToSpawn;
    private SnapPoint tempSnapPoints;
    [SerializeField] private Combat combat;
    [SerializeField] private Quest quest;
    private void Start()
    {
        SpawnEnemy();
        combat.OnNewTurn += SpawnEnemy;
    }
    [Button]
    private void SpawnEnemy()
    {
        enemyToSpawn = enemies[Random.Range(0, enemies.Length)];
        GetFreeSnapPointsInRow(enemyToSpawn.AttackRange);
        if (freeSnapPoints.Count == 0)
            return;
        enemyToSpawn = Instantiate(enemyToSpawn, GetSpawnPosition(), Quaternion.identity);
        enemyToSpawn.CurrentSnapPoint = tempSnapPoints;
        enemyToSpawn.OnDeatForQuest += quest.CheckQuests;
        combat.AddEnemy(enemyToSpawn);
        
    }
    private Vector3 GetSpawnPosition()
    {
        tempSnapPoints = freeSnapPoints[Random.Range(0, freeSnapPoints.Count)];
        tempSnapPoints.IsFree = false;
        return tempSnapPoints.Position;
    }
    private void GetFreeSnapPointsInRow(int row)
    {
        freeSnapPoints.Clear();
        foreach (var item in grid.SnapPoints)
        {
            if (item.Index.y == row && item.IsFree)
                freeSnapPoints.Add(item);
        }
    }

}
