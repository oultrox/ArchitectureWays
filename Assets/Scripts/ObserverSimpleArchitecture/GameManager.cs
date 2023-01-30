using UnityEngine;
using System; //IMPORTANT

public class GameManager : MonoBehaviour
{

    public event Action gameStarted, gameLost, scoreIncremented;
    private bool _isMatchActive = false;

    private void Update()
    {
        if (_isMatchActive == true)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isMatchActive = true;
            StartGame();
        }
    }

    public void StartGame()
    {
        gameStarted?.Invoke();
    }

    public void LoseGame()
    {
        _isMatchActive = false;
        gameLost?.Invoke();
    }

    public void IncrementScore()
    {
        scoreIncremented?.Invoke();
    }
}
