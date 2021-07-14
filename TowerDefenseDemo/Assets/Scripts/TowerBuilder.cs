using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _towerPrice;
    [SerializeField] private Shop _shop;

    private Vector3 offset = new Vector3(0.5f, -0.5f);

    public void TryBuild(Vector3 towerPosition)
    {
        if(_shop.TryCellTower())
        {
            Instantiate(_shop.GetTower(0), 
                        towerPosition + offset,                                             
                        Quaternion.identity, 
                        GetComponent<TowerBuilder>().transform);
        }
    }
}
