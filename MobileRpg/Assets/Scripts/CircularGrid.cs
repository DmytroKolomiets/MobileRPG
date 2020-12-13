using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularGrid : MonoBehaviour
{
    [SerializeField] private int segmentsCount;
    [SerializeField] private int rows;
    [SerializeField] private float rowsDistance;
    private Vector3 point;
    public SnapPoint[,] SnapPoints;
    
    void Awake()
    {        
        SnapPoints = new SnapPoint[segmentsCount, rows];
        CreatGrid(segmentsCount, rows, rowsDistance);
    }
    private void CreatGrid(int x, int y, float rowDistance)
    {
        for (int i = 0; i < y; i++)
        {
            CreatSegments(x, rowDistance * (i + 1), i);
        }
    }
    private void CreatSegments(int count, float distance, int index)
    {
        for (int i = 0; i < count; i++)
        {
            CreatOnCircle(i * (360f / count), distance);
            SnapPoints[i, index] = new SnapPoint(point, new Vector2Int(i, index));
        }
    }
    private void CreatOnCircle(float angle, float distance)
    {

        float a = angle * Mathf.PI / 180f;
        point.x = Mathf.Sin(a) * distance;
        point.z = Mathf.Cos(a) * distance;
        //GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //go.transform.position = point;
    }
}
public class SnapPoint
{
    public SnapPoint(Vector3 position, Vector2Int index)
    {
        this.Position = position;
        this.Index = index;
        IsFree = true;
    }
    public Vector3 Position { get; private set; }
    public Vector2Int Index { get; private set; }
    public bool IsFree;
}
