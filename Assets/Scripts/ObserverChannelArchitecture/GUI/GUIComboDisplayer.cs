using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.ObserverChannelArchitecture.GUI
{
    public class GUIComboDisplayer : MonoBehaviour
    {
        [SerializeField] private VoidEventChannelSO _scoreIncreaseEvent;
        private Text _text;

        void Start()
        {
            _text = GetComponent<Text>();
            _text.text = "";
            _scoreIncreaseEvent.OnEventRaised += ComboUp;
        }

        private void ComboUp()
        {
            StartCoroutine(UpdatComboText());
        }

        private IEnumerator UpdatComboText()
        {
            _text.text = ("Good job!");
            yield return new WaitForSeconds(1);
            _text.text = "";
        }
    }
}