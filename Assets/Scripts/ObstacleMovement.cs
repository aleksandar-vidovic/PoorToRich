using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private float distance;

    private float moveSpeed;

    private void Start()
    {
        moveSpeed = speed;
    }

    private void Update()
    {
        Move();
    }

    private void ContinueMovement()
    {
        moveSpeed = speed;
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            target.position = new Vector3(target.position.x + distance, target.position.y, target.position.z);
            distance *= -1;
            moveSpeed = 0;
            Invoke("ContinueMovement", 1);
        }
    }
}
