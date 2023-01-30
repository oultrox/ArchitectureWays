using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplayer : MonoBehaviour
{
    private Text _text;

    void Start()
    {
        _text = GetComponent<Text>();
        GameManager.GameStarted += SetStartText;
        GameManager.GameLost += SetLostText;
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
