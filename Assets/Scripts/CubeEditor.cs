using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
   
    TextMesh textMesh;
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
        
    }

    // Update is called once per frame
    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void UpdateLabel()
    {
        textMesh = GetComponentInChildren<TextMesh>();
        string textLabel = waypoint.GetGridPos().x + "." + waypoint.GetGridPos().y;
        textMesh.text = textLabel;
        gameObject.name = textLabel;
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(
            waypoint.GetGridPos().x * gridSize, 
            0f, 
            waypoint.GetGridPos().y * gridSize
            );
    }
}
