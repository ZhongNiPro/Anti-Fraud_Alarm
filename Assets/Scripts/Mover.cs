using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Mover : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    private float _speed = 5f;

    private void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis(Horizontal), 0, Input.GetAxis(Vertical));

        transform.Translate(direction * _speed * Time.deltaTime);
    }
}
