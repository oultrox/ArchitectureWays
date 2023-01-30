using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem ps;
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
        Instantiate(ps, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


}
