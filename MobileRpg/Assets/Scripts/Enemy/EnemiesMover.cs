using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMover : MonoBehaviour
{
    //[SerializeField] private CircularGrid grid;
    //[SerializeField] private List<Enemy> enemies = new List<Enemy>();
    //public List<SnaPpoint> FreeSnapPoints = new List<SnaPpoint>();

    //private void Start()
    //{
    //    GetSnapPoints();
    //}
    //public void MoveEnemy(Enemy enemy, SnaPpoint snaPpoint)
    //{
    //    if(enemy.Preset.AvaliableAttackRange )
    //    FreeSnapPoints.Add(GetSnapPoint(enemy.gameObject.transform.position));
    //}
    //private void GetSnapPoints()
    //{
    //    foreach (var item in grid.SnapPoints)
    //    {
    //        FreeSnapPoints.Add(item);
    //    }
    //}
    //private SnaPpoint GetSnapPoint(Vector3 position)
    //{
    //    for (int i = 0; i < FreeSnapPoints.Count; i++)
    //    {
    //        if (FreeSnapPoints[i].position == position)
    //            return FreeSnapPoints[i];
    //    }
    //    Debug.LogError("SnapPoint not found");
    //    return new SnaPpoint();
    //}
    //private int GetRowToMoveTo(Enemy enemy, int currentRow)
    //{
    //    Mathf.Abs(currentRow - enemy.Preset.AvaliableAttackRange);
    //}
}
