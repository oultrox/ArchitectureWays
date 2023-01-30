using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] int ScreenShakeFrames = 100;
    [SerializeField] float intensity = .01f, frequency;
    [SerializeField] private GameManager _gameManager;
    private void Start()
    {
        _gameManager.gameLost += ShakeScreen;
    }

    void ShakeScreen()
    {
        StopAllCoroutines();
        StartCoroutine(ScreenShakeCoroutine());
    }

    IEnumerator ScreenShakeCoroutine()
    {
        var originalposition = transform.position;

        for(int i = 0; i < ScreenShakeFrames ; i++)
        {
            transform.position = originalposition + ((100 - i) * intensity * Mathf.Cos(i * frequency) * Vector3.right / ScreenShakeFrames);
            yield return null;
        }

        transform.position = originalposition;
    }
}
