using Assets.Scripts.ObserverChannelArchitecture.GUI;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.ObserverChannelArchitecture.Controllers
{
    public class HighScoreController : MonoBehaviour
    {
        [SerializeField] private VoidEventChannelSO _lostGameEvent;
        [SerializeField] private GUIScoreIncreaser scoreSystem;
        private int highscore = 0;
        private Text text;


        void Start()
        {
            text = GetComponent<Text>();
            _lostGameEvent.OnEventRaised += CheckForHighScore;
        }

        void CheckForHighScore()
        {
            if (scoreSystem.Score > highscore)
            {
                highscore = scoreSystem.Score;
                text.text = "High Score: " + highscore.ToString();

            }
        }
    }
}