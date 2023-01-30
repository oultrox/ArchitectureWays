using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIComboSystem : MonoBehaviour
{
    private Text _text;

    void Start()
    {
        _text = GetComponent<Text>();
        _text.text = "";
        GameManager.ScoreIncremented += ComboUp;
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
