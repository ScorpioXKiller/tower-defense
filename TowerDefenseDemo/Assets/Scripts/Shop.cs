using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private Tower[] _towers;
    [SerializeField] private GameCoins _coins;

    public bool TryCellTower()
    {
        int coinsForTower = _towers[0].Price;

        if (_coins.CanSpend(coinsForTower))
        {
            _coins.Spend();
            return true;
        }
        else
            return false;
    }

    public GameObject GetTower(int towerIndex)
    {
        return _towers[towerIndex].gameObject;
    }
}
