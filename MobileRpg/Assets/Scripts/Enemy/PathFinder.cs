using System.Collections.Generic;
using UnityEngine;

public class PathFinder
{
    private List<SnapPoint> freeSnapPointsInRange = new List<SnapPoint>();
    public SnapPoint FindPath(SnapPoint currentPosition, SnapPoint desireblePosition, 
        SnapPoint[,] snapPoints, int moveSpeed)
    {
        GetFreeSnapPointsInRange(currentPosition.Index, snapPoints, moveSpeed);
        if(freeSnapPointsInRange.Count == 0)
        {          
            return currentPosition;
        }
            
        return GetClosestPoint(desireblePosition.Index, freeSnapPointsInRange);
    }
    private void GetFreeSnapPointsInRange(Vector2Int positon, SnapPoint[,] snapPoints, int range)
    {
        
        freeSnapPointsInRange.Clear();
        foreach (var item in snapPoints)
        {         
            if (GetDistance(positon, item.Index) < range && item.IsFree)
            {
                Debug.Log(GetDistance(positon, item.Index));
                Debug.Log(range);
                freeSnapPointsInRange.Add(item);
            }
        }
    }
    private SnapPoint GetClosestPoint(Vector2Int desireblePosition, List<SnapPoint> freeSnapPoints)
    {
        SnapPoint snapPoint = freeSnapPoints[0];
        int distance = GetDistance(snapPoint.Index, desireblePosition);
        foreach (var item in freeSnapPoints)
        {
            if (GetDistance(desireblePosition, item.Index) < distance)
            {
                snapPoint = item;
                distance = GetDistance(item.Index, desireblePosition);
            }
        }
        return snapPoint;
    }
    private int GetDistance(Vector2Int a, Vector2Int b)
    {
        return (Mathf.Abs(a.x - b.x ) + Mathf.Abs(a.y - b.y)) / 2;
    }
}
