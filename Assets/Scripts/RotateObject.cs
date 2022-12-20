using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private Vector3 speed;

    private void Update()
    {
        transform.Rotate(speed * Time.deltaTime);
    }
}
