using System.Collections.Generic;
using UnityEngine;

public class Navigator : MonoBehaviour
{
    private PathBuilder _path;
    private List<GameObject> _pathCells = new List<GameObject>();

    public bool IsTargetReached => CurrentWayIndex >= _pathCells.Count - 1;
    public float TargetPoint => 0.2f;
    public int CurrentWayIndex { get; set; }

    public void Init()
    {
        CurrentWayIndex = 0;
        _path = FindObjectOfType<PathBuilder>();
        _pathCells = _path.GetPath();
    }

    public (Vector2 directionToTarget, Vector3 currentPath) GetDirectionToTarget()
    {
        var currentPath = new Vector3(_pathCells[CurrentWayIndex].transform.position.x + 0.5f,
                                      _pathCells[CurrentWayIndex].transform.position.y - 0.5f);

        Vector2 directionToTarget = currentPath - transform.position;

        return (directionToTarget.normalized, currentPath);  
    }

}
