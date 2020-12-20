using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class EnemiesMover : MonoBehaviour
{
    [SerializeField] private CircularGrid grid;
    private PathFinder pathFinder = new PathFinder();
    private List<SnapPoint> SnapPointsInAttackRange = new List<SnapPoint>();
    [SerializeField] private List<Enemy> enemies = new List<Enemy>();

    [Button]
    public void MoveEnemies()
    {
        foreach (var item in enemies)
        {
            MoveEnemy(item);
        }
    }
    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
        enemy.OnDeath += () => { enemies.Remove(enemy); };
    }
    private void MoveEnemy(Enemy enemy)
    {
        GetSnapPointInAttakRange(enemy);
        if (SnapPointsInAttackRange.Count == 0)
            return;
        enemy.Move(pathFinder.FindPath(enemy.CurrentSnapPoint,
            SnapPointsInAttackRange[Random.Range(0, SnapPointsInAttackRange.Count)],
            grid.SnapPoints, enemy.Preset.MoveSpeed));
    }
    private void GetSnapPointInAttakRange(Enemy enemy)
    {
        SnapPointsInAttackRange.Clear();
        foreach (var item in grid.SnapPoints)
        {
            if (item.IsFree && item.Index.y == enemy.Preset.AvaliableAttackRange)
            {
                SnapPointsInAttackRange.Add(item);
            }
        }
    }
}
