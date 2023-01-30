using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Events;

public class MatchController : MonoBehaviour
{
    private bool _isMatchActive = false;
    [SerializeField] private VoidEventChannelSO _startGameEvent;
    [SerializeField] private VoidEventChannelSO _lostGameEvent;

    private void Start()
    {
        _lostGameEvent.OnEventRaised += ResetMatchStatus;
    }

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

    private void ResetMatchStatus()
    {
        _isMatchActive = false;
    }
}
