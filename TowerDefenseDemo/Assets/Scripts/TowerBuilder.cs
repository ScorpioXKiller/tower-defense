using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _towerPrice;
    [SerializeField] private Shop _shop;


    public void TryBuild(Vector3 towerPosition)
    {
        if(_shop.TryCellTower())
        {
            GameObject tower = Instantiate(_shop.GetTower(0), towerPosition + new Vector3(0.5f, -0.5f), 
                                              Quaternion.identity, GetComponent<TowerBuilder>().transform);
        }
    }
}
