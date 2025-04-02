using System.Collections;
using UnityEngine;

public class Signal : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _volumeChange = .05f;
    private float _maxVolume = 1f;
    private float _delay = .1f;
    private WaitForSeconds _waitForSeconds;
    private Coroutine _coroutine;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_delay);
        _audioSource.volume = 0;
    }

    public void StartAlarm()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeVolume(targetVolume: _maxVolume));

        _audioSource.Play();
    }

    public void StopAlarm()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeVolume(targetVolume: 0f));
    }


    private IEnumerator ChangeVolume(float targetVolume)
    {
        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _volumeChange);

            yield return _waitForSeconds;
        }

        if (_audioSource.volume == 0)
        {
            _audioSource.Stop();
        }
    }
}