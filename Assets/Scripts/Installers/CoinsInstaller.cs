using UnityEngine;
using Zenject;

public class CoinsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var amount = PlayerPrefs.GetInt("Coins", 0);
        var coins = new Coins(amount);
        Container.Bind<Coins>().FromInstance(coins).AsSingle();
    }
}