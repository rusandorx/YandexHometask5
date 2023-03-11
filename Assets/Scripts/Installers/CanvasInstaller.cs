using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CanvasInstaller : MonoInstaller
{
    [SerializeField] private Canvas _canvasPrefab;
    public override void InstallBindings()
    {
        var canvas = Container.InstantiatePrefab(_canvasPrefab);
        var coinsText = canvas.AddComponent<Text>();
        coinsText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        Container.Bind<Text>().WithId("CoinsText").FromInstance(coinsText).AsSingle();
    }
}