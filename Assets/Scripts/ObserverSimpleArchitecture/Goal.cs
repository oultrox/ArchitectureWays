using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    private void OnCollisionEnter(Collision collision)
    {
        _gameManager.IncrementScore();
    }


}
