using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField] [Range(1, 4)] private int _level;

    [SerializeField] private Cell _cell;
    [SerializeField] private PathBuilder _path;
    [SerializeField] private Transform _cellParent;
    [SerializeField] private Color[] _cellColor = new Color[3];

    private const int _width = 18;
    private const int _height = 10;

    private int _currentWayX;
    private int _currentWayY;
    
    private GameObject[,] _levelCells;
    private GameObject _firstCell;

    private bool IsCurrentCellGround(int x, int y) => _levelCells[x, y].GetComponent<Cell>().IsGround;

    private void Start()
    {
        BuildLevel();
        _path = GetComponentInChildren<PathBuilder>();
        _path.BuildPath(_firstCell, _currentWayX, _currentWayY, _width, IsCurrentCellGround, _levelCells);
    }

    private void BuildLevel()
    {
        _levelCells = new GameObject[_height, _width];

        for (int x = 0; x < _height; x++)
        {
            for (int y = 0; y < _width; y++)
            {
                CreateCell(x, y);
            }
        }
        SetLevelPosition();
    }

    private void CreateCell(int x, int y)
    {
        int colorIndex = int.Parse(LoadLevelText(_level)[x].ToCharArray()[y].ToString());
        _cell.SetColor(_cellColor[colorIndex]);

        if (colorIndex == 0)
            _cell.IsGround = false;
        else
            _cell.IsGround = true;

        GameObject cellPrefab = Instantiate(_cell.gameObject, _cell.GetWorldPosition(x, y), Quaternion.identity, _cellParent);

        if (_cell.IsGround && colorIndex == 2)
        {
            if (_firstCell == null)
            {
                _firstCell = cellPrefab;
                _currentWayX = x;
                _currentWayY = y;
            }
        }
        _levelCells[x, y] = cellPrefab;
    }

    private void SetLevelPosition()
    {
        transform.position = new Vector3(-3.888892f, -3.888886f, -5.030024e-06f);
        transform.rotation = Quaternion.Euler(180, 0, 90);
    }


    private string[] LoadLevelText(int level)
    {
        TextAsset tmpTxt = Resources.Load<TextAsset>("Level" + level);

        string tmpStr = tmpTxt.text.Replace(System.Environment.NewLine, string.Empty);

        return tmpStr.Split('!');
    }
}
