using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathBuilder : MonoBehaviour
{
    [SerializeField] private List<GameObject> _pathCells = new List<GameObject>();

    public GameObject[,] LevelCells = new GameObject[10, 18];

    public GameObject FirstPathCell { get; private set; }

    private bool IsCurrentCellGround(int x, int y) => LevelCells[x, y].GetComponent<Cell>().IsGround;

    public void BuildPath(GameObject firstCell, int currentWayX, int currentWayY, int levelWidth)
    {
        FirstPathCell = firstCell;

        GameObject currentPathCell;

        _pathCells.Add(FirstPathCell);

        while (true)
        {
            currentPathCell = null;

            if (currentWayX < (levelWidth - 1) && IsCurrentCellGround(currentWayX + 1, currentWayY) &&
                !_pathCells.Exists(x => x == LevelCells[currentWayX + 1, currentWayY]))
            {
                currentPathCell = LevelCells[currentWayX + 1, currentWayY];
                currentWayX++;
            }

            else if (currentWayY < (levelWidth - 1) && IsCurrentCellGround(currentWayX, currentWayY + 1) &&
                !_pathCells.Exists(x => x == LevelCells[currentWayX, currentWayY + 1]))
            {
                currentPathCell = LevelCells[currentWayX, currentWayY + 1];
                currentWayY++;
            }

            else if (currentWayX > 0 && IsCurrentCellGround(currentWayX - 1, currentWayY) &&
                !_pathCells.Exists(x => x == LevelCells[currentWayX - 1, currentWayY]))
            {
                currentPathCell = LevelCells[currentWayX - 1, currentWayY];
                currentWayX--;
            }

            else if (currentWayY > 0 && IsCurrentCellGround(currentWayX, currentWayY - 1) &&
                !_pathCells.Exists(x => x == LevelCells[currentWayX, currentWayY - 1]))
            {
                currentPathCell = LevelCells[currentWayX, currentWayY - 1];
                currentWayY--;
            }

            else
                break;

            _pathCells.Add(currentPathCell);
        }
    }

    public List<GameObject> GetPath()
    {
        return _pathCells;
    }
}
