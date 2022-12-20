using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] private GameObject music;
    [SerializeField] private AudioSource levelUp;
    [SerializeField] private AudioSource fail;
    [SerializeField] private AudioSource win;

    private static AudioSource soundLevelUp;
    private static AudioSource soundFail;
    private static AudioSource soundWin;

    private void Start()
    {
        soundLevelUp = levelUp;
        soundFail = fail;
        soundWin = win;

        if (Sounds.on)
            music.SetActive(true);
    }

    public static void LevelUp()
    {
        if (Sounds.on)
            soundLevelUp.PlayOneShot(soundLevelUp.clip);
    }

    public static void Fail()
    {
        if (Sounds.on)
            soundFail.PlayOneShot(soundFail.clip);
    }

    public static void Win()
    {
        if (Sounds.on)
            soundWin.PlayOneShot(soundWin.clip);
    }
}
