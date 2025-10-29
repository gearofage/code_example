using UnityEngine;
using Zenject;

public class CarInstaller : MonoInstaller
{
    [SerializeField] private DesktopMoveInputKeyConfig _moveInputKeyConfig;
    [SerializeField] private GameObject _carPrefab;
    [SerializeField] private Transform[] _spawnPoints;

    public override void InstallBindings()
    {
        Container.BindInterfacesTo<PlayerCar>().FromComponentInNewPrefab(_carPrefab).AsSingle().NonLazy();
        Container.Bind<DesktopMoveInputKeyConfig>().FromInstance(_moveInputKeyConfig).AsSingle();
        Container.BindInterfacesAndSelfTo<DesktopMoveInput>().AsSingle();
        Container.BindInterfacesAndSelfTo<MoveHandler>().AsSingle();

        Container.BindInterfacesTo<FollowHandler>().AsSingle().NonLazy();
        Container.BindInterfacesTo<DeathHandler>().AsSingle().NonLazy();

        //Container.BindSignal<GameStartSignal>().ToMethod<IGameStartListener>(i => i.OnGameStart).FromResolveAll();
        //Container.BindSignal<GameEndSignal>().ToMethod<IGameEndListener>(i => i.OnGameEnd).FromResolveAll();
    }
}
