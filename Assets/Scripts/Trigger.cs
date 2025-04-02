using UnityEngine;

public class Triger : MonoBehaviour
{
    [SerializeField] private Signal _signal;

    private void OnTriggerEnter(Collider other)
    {
        _signal.StartAlarm();
    }

    private void OnTriggerExit(Collider other)
    {
        _signal.StopAlarm();
    }
}
