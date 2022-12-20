using UnityEngine;

public class ZoomOutCamera : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;
    [SerializeField] private Transform player;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            ZoomOut();

        else if (Input.GetKeyDown(KeyCode.Space)) //KEYBOARD TEST
            ZoomOut();
    }

    private void ZoomOut()
    {
        mainCamera.position = new Vector3(player.position.x, player.position.y + 9.15f, player.position.z - 10);
        mainCamera.Rotate(25, 180, 0, Space.Self);
        gameObject.SetActive(false);
    }
}
