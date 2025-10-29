using UnityEngine;

public class GameScreenUI : MonoBehaviour, IGameStartListener, IGameEndListener
{
    public void OnGameStart()
    {
        gameObject.SetActive(true);
    }

    public void OnGameEnd()
    {
        gameObject.SetActive(false);
    }
}