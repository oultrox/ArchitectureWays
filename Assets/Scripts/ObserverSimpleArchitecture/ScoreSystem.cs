using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    private Text _text;

    public int Score { get; private set;} = 0;

    void Start()
    {
        _text = GetComponent<Text>();
        GameManager.ScoreIncremented += IncrementScore;
        GameManager.GameStarted += ResetScore;
    }

    void ResetScore()
    {
        Score = 0;
        DisplayScore();
    }

    void IncrementScore()
    {
        Score++;
        DisplayScore();
    }

    private void DisplayScore()
    {
        _text.text = Score.ToString();
    }
}
