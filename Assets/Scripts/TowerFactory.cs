using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    [SerializeField] GameObject towerParent;

    private Queue<Tower> towerQueue = new Queue<Tower>();
  

    public void AddTower(Waypoint baseWaypoint)
    {
        int numTowers = towerQueue.Count;
        if(numTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    private void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        Tower oldTower = towerQueue.Dequeue();

        oldTower.baseWaypoint.isPlaceable = true;
        newBaseWaypoint.isPlaceable = false;

        oldTower.baseWaypoint = newBaseWaypoint;
        oldTower.transform.position = newBaseWaypoint.transform.position;

        towerQueue.Enqueue(oldTower);
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        Tower towerObject = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        towerObject.transform.SetParent(towerParent.transform);
        baseWaypoint.isPlaceable = false;

        towerObject.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;
        
        towerQueue.Enqueue(towerObject);
    }
}
