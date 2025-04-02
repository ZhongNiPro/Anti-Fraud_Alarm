using UnityEngine;

public class Signal : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _volumeChange = 1f;
    private float _targetVolume = 0f;

    private void Update()
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _volumeChange * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Move move))
        {
            _targetVolume = 1f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Move move))
        {
            _targetVolume = 0f;
        }
    }
}
