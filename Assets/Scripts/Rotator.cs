using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(_rotationSpeed * Time.deltaTime * Vector3.up);
    }
}
