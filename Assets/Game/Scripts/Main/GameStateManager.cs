using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameStateManager
{
    public event Action OnGameStart;
    public event Action OnGameEnd;
    
    public GameStates GameState { get; private set; }

    private readonly List<IGameStateListener> gameListeners = new();

    //[Inject] private SignalBus _signalBus;

    public void AddGameListener(IGameStateListener listener)
    {
        if(gameListeners.Contains(listener))
        {
            Debug.LogWarningFormat("Listener is already added", listener.GetType());
            return;
        }
        gameListeners.Add(listener);
    }

    public void RemoveGameListener(IGameStateListener listener)
    {
        gameListeners.Remove(listener);
    }

    public void StartGame()
    {
        if (GameState == GameStates.START) return;

        GameState = GameStates.START;

        //_signalBus.Fire<GameStartSignal>();

        OnGameStart?.Invoke();

        foreach (var listener in gameListeners)
        {
            if(listener is IGameStartListener startListener)
            {
                startListener.OnGameStart();
            }
        }
    }

    public void EndGame()
    {
        if (GameState == GameStates.END) return;

        GameState = GameStates.END;

        //_signalBus.Fire<GameEndSignal>();

        OnGameEnd?.Invoke();

        foreach (var listener in gameListeners)
        {
            if (listener is IGameEndListener endListener)
            {
                endListener.OnGameEnd();
            }
        }
    }
}