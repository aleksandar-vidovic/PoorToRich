using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float runSpeed;
    [SerializeField] private Animator anim;
    [SerializeField] private SceneLoadReload reload;
    [SerializeField] private GameObject timer;

    private bool allowedToMove;
    private bool moving;
    private float speed;
    private Vector3 dir;
    private bool collided;
    private bool timerActivated;

    private void Start()
    {
        allowedToMove = true;
        dir = new Vector3(0, 0, 1);
    }

    private void Update()
    {
        MovePlayer();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!collided && hit.collider.tag == "Obstacle")
        {
            collided = true;
            allowedToMove = false;
            if (moving)
            {
                anim.SetTrigger("idle");
                speed = 0;
            }
            PlaySound.Fail();
            Invoke("Reloading", 1);
        }
    }

    private void PlayerMovementInput()
    {
        if (allowedToMove)
        {
            if (!timerActivated)
            {
                timer.SetActive(true);
                timerActivated = true;
            }

            if (!moving)
            {
                anim.SetTrigger("run");
                moving = true;
                speed = runSpeed;
            }
            else
            {
                anim.SetTrigger("idle");
                moving = false;
                speed = 0.01f;
            }
        }
    }

    private void MovePlayer()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            PlayerMovementInput();

        else if (Input.GetKeyDown(KeyCode.Space)) //KEYBOARD TEST
            PlayerMovementInput();

        controller.Move(dir * speed * Time.deltaTime);
    }

    private void Reloading()
    {
        reload.SceneReloading();
    }
}
