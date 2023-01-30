using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreSystem : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private ScoreSystem scoreSystem;
    private int highscore = 0;
    private Text text;
    
    void Start()
    {
        text = GetComponent<Text>();
        _gameManager.gameLost += CheckForHighScore;
    }

    void CheckForHighScore()
    {
        if( scoreSystem.Score > highscore)
        {
            highscore = scoreSystem.Score;
            text.text = "High Score: " + highscore.ToString();
        }
    }
}
