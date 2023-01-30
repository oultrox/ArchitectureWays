using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystem;
    private GameManager _gameManager;
    
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.gameLost += SelfDestruct;
    }

    private void OnCollisionEnter(Collision collision)
    {
        SelfDestruct();
    }

    void SelfDestruct()
    {
        _gameManager.gameLost -= SelfDestruct;
        Instantiate(_particleSystem, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


}
