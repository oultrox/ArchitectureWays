using UnityEngine;
using System; //IMPORTANT

public class GameManager : MonoBehaviour
{

    public static event Action GameStarted, GameLost, ScoreIncremented;
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
        GameStarted?.Invoke();
    }

    public void LoseGame()
    {
        _isMatchActive = false;
        GameLost?.Invoke();
    }

    public void IncrementScore()
    {
        ScoreIncremented?.Invoke();
    }
}
