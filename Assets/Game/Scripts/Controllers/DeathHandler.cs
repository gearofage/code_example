public class DeathHandler : IGameUpdatable
{
    private readonly ICar _car;
    private readonly GameStateManager _gameStateManager;
    public DeathHandler(ICar car, GameStateManager gameStateManager)
    {
        _car = car;
        _gameStateManager = gameStateManager;
    }

    public void OnUpdate()
    {
        if(_car.Transform.position.y < -1f)
        {
            _gameStateManager.EndGame();
        }
    }
}