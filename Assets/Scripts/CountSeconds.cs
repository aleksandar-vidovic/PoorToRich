using System;
using TMPro;
using UnityEngine;

public class CountSeconds : MonoBehaviour
{
    [SerializeField] private TMP_Text txtTime;
    [SerializeField] private SceneLoadReload reload;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject moneyAnim;
    [SerializeField] private Animator playerAnim;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Transform mainCamera;
    [SerializeField] private TMP_Text txtMoney;
    [SerializeField] private GameObject buttonReplay;

    private bool timeIsUp;
    private int totalTime;
    private float timer;
    private int elapsedTime;
    private bool gameEnd;

    private void Start()
    {
        totalTime = 60;
        elapsedTime = 60;
        timer = 0;
    }

    private void Update()
    {
        if (!gameEnd && !timeIsUp)
        {
            timer += Time.deltaTime;
            int seconds = (int)(timer % 60);
            elapsedTime = totalTime - seconds;

            if (elapsedTime == 1)
            {
                timeIsUp = true;
                txtTime.text = "0";
                PlaySound.Fail();
                Invoke("Reload", 1);
                return;
            }

            if (Convert.ToInt32(txtTime) != elapsedTime)
            {
                txtTime.text = elapsedTime.ToString();
            }

            if (player.position.z > 122)
                GameWin();
        }
    }

    private void GameWin()
    {
        gameEnd = true;
        playerMovement.enabled = false;
        playerAnim.SetTrigger("win");
        ZoomInCamera();
        moneyAnim.SetActive(true);
        PlaySound.Win();
        if (elapsedTime > 10)
            Money.amount += 5000;
        else
            Money.amount += 3000;
        txtMoney.text = Money.amount.ToString();
        buttonReplay.SetActive(true);
    }

    private void ZoomInCamera()
    {
        mainCamera.position = new Vector3(player.position.x, player.position.y + 1.2f, player.position.z + 3.65f);
        mainCamera.Rotate(25, 180, 0, Space.Self);
    }

    private void Reload()
    {
        reload.SceneReloading();
    }
}
