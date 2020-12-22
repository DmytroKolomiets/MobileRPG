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
            
        return GetClosestPoint(desireblePosition.Index, freeSnapPointsInRange, snapPoints.GetLength(0));
    }
    private void GetFreeSnapPointsInRange(Vector2Int positon, SnapPoint[,] snapPoints, int range)
    {
        
        freeSnapPointsInRange.Clear();
        foreach (var item in snapPoints)
        {         
            if (GetDistance(positon, item.Index, snapPoints.GetLength(0)) < range && item.IsFree)
            {
                freeSnapPointsInRange.Add(item);
            }
        }
    }
    private SnapPoint GetClosestPoint(Vector2Int desireblePosition, 
        List<SnapPoint> freeSnapPoints, int arrayXLenth)
    {
        SnapPoint snapPoint = freeSnapPoints[0];
        int distance = GetDistance(snapPoint.Index, desireblePosition, arrayXLenth);
        foreach (var item in freeSnapPoints)
        {
            if (GetDistance(desireblePosition, item.Index, arrayXLenth) < distance)
            {
                snapPoint = item;
                distance = GetDistance(item.Index, desireblePosition, arrayXLenth);
            }
        }
        return snapPoint;
    }
    private int GetDistance(Vector2Int a, Vector2Int b, int arrayXLenth)
    {
        return (GetDistanceCorrectionForRadial(a.x, b.x, arrayXLenth) + Mathf.Abs(a.y - b.y)) / 2;
    }
    private int GetDistanceCorrectionForRadial(int aX, int bX,  int arrayXLenth)
    {
        int distance = Mathf.Abs(aX - bX);
        return distance > (arrayXLenth / 2) ? arrayXLenth - distance : distance;
    }
}
