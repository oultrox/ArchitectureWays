using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSpot : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO _increaseScoreEvent;

    private void OnCollisionEnter(Collision collision)
    {
        _increaseScoreEvent.RaiseEvent();
    }
}
