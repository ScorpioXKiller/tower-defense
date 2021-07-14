using System.Collections.Generic;
using UnityEngine;

public class PathBuilder : MonoBehaviour
{
    public delegate bool IsCurrentCellGround(int x, int y);

    private readonly List<GameObject> _pathCells = new List<GameObject>();

    public GameObject FirstPathCell { get; private set; }

    public void BuildPath(GameObject firstCell, int currentWayX, int currentWayY, int levelWidth, IsCurrentCellGround isCurrentCellIsGround, GameObject[,] LevelCells)
    {
        FirstPathCell = firstCell;

        GameObject currentPathCell;

        _pathCells.Add(FirstPathCell);

        while (true)
        {
            currentPathCell = null;

            if (currentWayX < (levelWidth - 1) && isCurrentCellIsGround(currentWayX + 1, currentWayY) &&
                !_pathCells.Exists(x => x == LevelCells[currentWayX + 1, currentWayY]))
            {
                currentPathCell = LevelCells[currentWayX + 1, currentWayY];
                currentWayX++;
            }

            else if (currentWayY < (levelWidth - 1) && isCurrentCellIsGround(currentWayX, currentWayY + 1) &&
                !_pathCells.Exists(x => x == LevelCells[currentWayX, currentWayY + 1]))
            {
                currentPathCell = LevelCells[currentWayX, currentWayY + 1];
                currentWayY++;
            }

            else if (currentWayX > 0 && isCurrentCellIsGround(currentWayX - 1, currentWayY) &&
                !_pathCells.Exists(x => x == LevelCells[currentWayX - 1, currentWayY]))
            {
                currentPathCell = LevelCells[currentWayX - 1, currentWayY];
                currentWayX--;
            }

            else if (currentWayY > 0 && isCurrentCellIsGround(currentWayX, currentWayY - 1) &&
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
