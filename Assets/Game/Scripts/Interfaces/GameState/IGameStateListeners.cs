public interface IGameStateListener { }

public interface IGameStartListener : IGameStateListener
{
    void OnGameStart();
}

public interface IGameEndListener : IGameStateListener
{
    void OnGameEnd();
}
