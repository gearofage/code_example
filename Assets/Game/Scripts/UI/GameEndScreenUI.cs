using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameEndScreenUI : MonoBehaviour, IGameStartListener, IGameEndListener
{
    [SerializeField] private Button _startButton;

    private GameStateManager _gameStateManager;

    [Inject]
    public void Contruct(GameStateManager gameStateManager)
    {
        _gameStateManager = gameStateManager;
    }

    public void OnGameStart()
    {
        Hide();
    }

    public void OnGameEnd()
    {
        Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
        _startButton.onClick.AddListener(_gameStateManager.StartGame);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
        _startButton.onClick.RemoveAllListeners();
    }
}
