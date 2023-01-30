using UnityEngine;
using System; //IMPORTANT

public class GameManager : MonoBehaviour
{

    public event Action gameStarted, gameLost, scoreIncremented;
    bool isPlaying = false;

    private void Update()
    {
        if (isPlaying == true)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isPlaying = true;
            StartGame();
        }
    }

    public void StartGame()
    {
        gameStarted?.Invoke();
    }

    public void LoseGame()
    {
        isPlaying = false;
        gameLost?.Invoke();
    }

    public void IncrementScore()
    {
        scoreIncremented?.Invoke();
    }
}
