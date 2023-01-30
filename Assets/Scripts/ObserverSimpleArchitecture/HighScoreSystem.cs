using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreSystem : MonoBehaviour
{
    [SerializeField] private ScoreSystem scoreSystem;
    private int highscore = 0;
    private Text text;
    
    void Start()
    {
        text = GetComponent<Text>();
        GameManager.GameLost += CheckForHighScore;
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
