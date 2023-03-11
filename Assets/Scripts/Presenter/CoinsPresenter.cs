using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CoinsPresenter : MonoBehaviour
{
    [Inject] private Coins _coins;

    [Inject(Id = "CoinsText")] private Text _render;
    [SerializeField] private Animator _animator;

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
    
    // Методы, чтобы показать работоспособность
    private void Awake()
    {
        StartCoroutine(nameof(PickupCoin));
    }

    private IEnumerator PickupCoin()
    {
        while (true)
        {
            OnPickupCoin();
            yield return new WaitForSeconds(1);
        }
    }
}