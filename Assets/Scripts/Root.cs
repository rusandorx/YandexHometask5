using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private CoinsPresenter _coinsPresenter;

    private Coins _coinsModel;

    private void Awake()
    {
        var amount = PlayerPrefs.GetInt("Coins", 0);
        _coinsModel = new Coins(amount);

        _coinsPresenter.Init(_coinsModel);
    }
}