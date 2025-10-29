using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField] private StartScreenUI startScreenUI;
    [SerializeField] private GameScreenUI gameScreenUI;
    [SerializeField] private GameEndScreenUI gameEndScreenUI;

    public override void InstallBindings()
    {
        Container.BindInterfacesTo<StartScreenUI>().FromInstance(startScreenUI).AsSingle();
        Container.BindInterfacesTo<GameScreenUI>().FromInstance(gameScreenUI).AsSingle();
        Container.BindInterfacesTo<GameEndScreenUI>().FromInstance(gameEndScreenUI).AsSingle();
    }
}
