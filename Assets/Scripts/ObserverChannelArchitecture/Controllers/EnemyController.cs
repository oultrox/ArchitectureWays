using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO _gameStartedEvent;
    [SerializeField] private VoidEventChannelSO _gameLostEvent;
    [SerializeField] private GameObject _enemyPrefab;
    private Coroutine _spawnroutine;

    private void Start()
    {
        _gameStartedEvent.OnEventRaised += StartSpawning;
        _gameLostEvent.OnEventRaised += StopSpawning;
    }

    private void StartSpawning()
    {
        _spawnroutine = StartCoroutine(SpawnEnemies());
    }

    private void StopSpawning()
    {
        if (_spawnroutine != null)
        {
            StopCoroutine(_spawnroutine);
        }
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Vector3 SpawnPosition = new Vector3(Random.Range(-6.5f, 6.5f), 7f, -2.35f);
            var enemy = Instantiate(_enemyPrefab, SpawnPosition, Random.rotation);

            yield return new WaitForSeconds(2f);
        }

    }
}
