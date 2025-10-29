using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField]
    private GameCamera _camera;
    public override void InstallBindings()
    {
        Container.Bind<GameStateManager>().AsSingle().NonLazy();
        Container.BindInterfacesTo<GameCamera>().FromInstance(_camera).AsSingle().NonLazy();

        /*
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<GameStartSignal>();
            Container.DeclareSignal<GameEndSignal>();

            Container.BindSignal<GameStartSignal>().ToMethod<IGameStartListener>(i => i.OnGameStart).FromResolveAll();
            Container.BindSignal<GameEndSignal>().ToMethod<IGameEndListener>(i => i.OnGameEnd).FromResolveAll();
        */
    }
}

//public struct GameStartSignal { }
//public struct GameEndSignal { }