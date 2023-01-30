using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    public int score { get; private set;} = 0;
    private Text text;


    void Start()
    {
        text = GetComponent<Text>();
        _gameManager.scoreIncremented += IncrementScore;
        _gameManager.gameStarted += ResetScore;
    }

    void ResetScore()
    {
        score = 0;
        DisplayScore();
    }

    void IncrementScore()
    {
        score++;
        DisplayScore();
    }

    private void DisplayScore()
    {
        text.text = score.ToString();
    }
}
