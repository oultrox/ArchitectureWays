using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystem;
    
    void Start()
    {
        GameManager.GameLost += SelfDestruct;
    }

    private void OnCollisionEnter(Collision collision)
    {
        SelfDestruct();
    }

    void SelfDestruct()
    {
        GameManager.GameLost -= SelfDestruct;
        Instantiate(_particleSystem, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


}
