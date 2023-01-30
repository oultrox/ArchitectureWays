using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakerController : MonoBehaviour
{
    [SerializeField] private int _screenShakeFrames = 60;
    [SerializeField] private float _intensity = 2;
    [SerializeField] private float _frequency = 10;
    [SerializeField] private VoidEventChannelSO _lostGameEvent;

    private void Start()
    {
        _lostGameEvent.OnEventRaised += ShakeScreen;
    }

    void ShakeScreen()
    {
        StopAllCoroutines();
        StartCoroutine(ScreenShakeCoroutine());
    }

    IEnumerator ScreenShakeCoroutine()
    {
        var originalposition = transform.position;

        for (int i = 0; i < _screenShakeFrames; i++)
        {
            transform.position = originalposition + ((100 - i) * _intensity * Mathf.Cos(i * _frequency) * Vector3.right / _screenShakeFrames);
            yield return null;
        }

        transform.position = originalposition;
    }
}
