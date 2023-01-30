using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.ObserverChannelArchitecture.GUI
{
    public class GUITextDisplayer : MonoBehaviour
    {
        [SerializeField] private VoidEventChannelSO _gameStartEvent;
        [SerializeField] private VoidEventChannelSO _gameLostEvent;
        private Text _text;


        void Start()
        {
            _text = GetComponent<Text>();
            _gameStartEvent.OnEventRaised += SetStartText;
            _gameLostEvent.OnEventRaised += SetLostText;
        }

        void SetStartText()
        {
            StopAllCoroutines();
            _text.text = "GO!";
            StartCoroutine(ClearText());
        }

        void SetLostText()
        {
            StopAllCoroutines();
            _text.text = "GAME OVER\nPRESS SPACE TO RESTART";
        }

        IEnumerator ClearText()
        {
            yield return new WaitForSeconds(2);
            _text.text = "";
        }
    }
}