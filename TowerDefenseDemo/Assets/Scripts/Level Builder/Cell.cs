using System;
using UnityEngine;

public class Cell : MonoBehaviour
{  
    [SerializeField] private SpriteRenderer _cellSP;
    [SerializeField] private Color _highlightColor;

    private TowerBuilder _builder;

    private Color _baseColor;

    public bool IsGround = false;
    public bool HasTower = false;

    private void Start()
    {
        _baseColor = _cellSP.color;
        _builder = FindObjectOfType<TowerBuilder>();
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));

        float cellSizeX = _cellSP.bounds.size.x;
        float cellSizeY = _cellSP.bounds.size.y;

        return new Vector3(worldPos.x + (cellSizeX * x), worldPos.y + (cellSizeY * -y));      
    }

    public void SetColor(Color color)
    {
        _cellSP.color = color;
    }

    private void OnMouseEnter()
    {
        if (!IsGround)
            _cellSP.color = _highlightColor;
    }

    private void OnMouseExit()
    {
        _cellSP.color = _baseColor;
    }

    private void OnMouseDown()
    {
        if (!IsGround && !HasTower)
        {
            _builder.TryBuild(transform.position);
            HasTower = true;
        }
    }
}