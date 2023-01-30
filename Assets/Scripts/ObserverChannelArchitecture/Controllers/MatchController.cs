using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class MatchController : MonoBehaviour
{
    private bool _isMatchActive = false;
    [SerializeField] private VoidEventChannelSO _startGameEvent;

    // Update is called once per frame
    void Update()
    {
        if (_isMatchActive == true)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isMatchActive = true;
            StartGame();
        }
    }

    public void StartGame()
    {
        _startGameEvent.RaiseEvent();
    }
}
