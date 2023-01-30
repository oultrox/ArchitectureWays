using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.ObserverChannelArchitecture.GUI
{
    public class GUIScoreIncreaser : MonoBehaviour
    {
        [SerializeField] private VoidEventChannelSO _increaseScoreEvent;
        [SerializeField] private VoidEventChannelSO _startGameEvent;
        private Text _text;
        
        public int Score { get; private set; } = 0;


        void Start()
        {
            _text = GetComponent<Text>();
            _increaseScoreEvent.OnEventRaised += IncrementScore;
            _startGameEvent.OnEventRaised += ResetScore;
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
}