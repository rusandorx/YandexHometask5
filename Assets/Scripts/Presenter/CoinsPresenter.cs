using UnityEngine;
using UnityEngine.UI;

public class CoinsPresenter : MonoBehaviour
{
    private Coins _coins;
    
    [SerializeField] private Text _render;
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        var amount = PlayerPrefs.GetInt("Coins", 0);
        _coins = new Coins(amount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Coin"))
            OnPickupCoin();
    }

    public void OnPickupCoin()
    {
        _coins.OnPickupCoin();
        RenderCoins();
    }

    public bool TryDiscard(int price)
    {
        if (!_coins.TryDiscard(price))
            return false;

        RenderCoins();
        return true;
    }

    private void RenderCoins()
    {
        _render.text = $"Coins: {_coins.Amount}";
        _animator.SetTrigger("OnPickupCoin");
        PlayerPrefs.SetInt("Coins", _coins.Amount);
    }
}