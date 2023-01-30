using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObstacle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private VoidEventChannelSO _lostGameEvent;

    private void OnCollisionEnter(Collision collision)
    {
        SelfDestruct();
        if(collision.gameObject.CompareTag("Player"))
        {
            _lostGameEvent.RaiseEvent();
        }
    }

    void SelfDestruct()
    {
        Instantiate(_particleSystem, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
