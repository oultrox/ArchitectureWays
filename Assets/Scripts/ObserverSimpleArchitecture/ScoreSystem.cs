using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    private Text _text;

    public int Score { get; private set;} = 0;

    void Start()
    {
        _text = GetComponent<Text>();
        _gameManager.scoreIncremented += IncrementScore;
        _gameManager.gameStarted += ResetScore;
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
