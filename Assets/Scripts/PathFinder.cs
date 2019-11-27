using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;
    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.left,
        Vector2Int.right,
        Vector2Int.down
    };

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartEnd();
        PathFind();
      //  ExploreNeighbours();
    }

    private void PathFind()
    {
        queue.Enqueue(startWaypoint);

        while(queue.Count > 0)
        {
            Waypoint searchCenter = queue.Dequeue();
            HaltIfEndFound(searchCenter);
        }
    }

    private void HaltIfEndFound(Waypoint startCenter)
    {
       if(startCenter == endWaypoint)
        {
            print("Searching from end node, therefore stopping"); // todo remove Log
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        foreach(Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = startWaypoint.GetGridPos() + direction;
            try
            {
                grid[explorationCoordinates].SetTopColor(Color.blue);
            }
            catch
            {
                // do nothing
            }
            
        }
    }

    private void ColorStartEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();

        foreach(Waypoint waypoint in waypoints)
        {
            Vector2Int gridPos = waypoint.GetGridPos();
            if(grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping overlapping block " + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
            }

        }
       
    }
}
