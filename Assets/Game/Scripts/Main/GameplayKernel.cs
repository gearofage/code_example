using System.Collections.Generic;
using Zenject;

public class GameplayKernel : MonoKernel, IGameStartListener, IGameEndListener
{
    [Inject]
    private GameStateManager _gameStateManager;

    [Inject(Optional = true, Source = InjectSources.Local)]
    private readonly List<IGameUpdatable> _updatables = new();

    [Inject(Optional = true, Source = InjectSources.Local)]
    private readonly List<IGameFixedUpdatable> _fixedUpdatables = new();

    [Inject(Optional = true, Source = InjectSources.Local)]
    private readonly List<IGameStateListener> _listeners = new();

    public override void Start()
    {
        base.Start();
        _gameStateManager.AddGameListener(this);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        _gameStateManager.RemoveGameListener(this);
    }

    public override void Update()
    {
        base.Update();

        if (_gameStateManager.GameState == GameStates.START)
        {
            foreach (var updatable in _updatables)
                updatable.OnUpdate();

            foreach (var fixedUpdatable in _fixedUpdatables)
                fixedUpdatable.OnFixedUpdate();
        }
    }

    public void OnGameStart()
    {
        foreach (var listener in _listeners)
        {
            if (listener is IGameStartListener startListener)
            {
                startListener.OnGameStart();
            }
        }
    }

    public void OnGameEnd()
    {
        foreach (var listener in _listeners)
        {
            if (listener is IGameEndListener endListener)
            {
                endListener.OnGameEnd();
            }
        }
    }
}
