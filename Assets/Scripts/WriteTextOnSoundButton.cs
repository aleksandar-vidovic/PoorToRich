using TMPro;
using UnityEngine;

public class WriteTextOnSoundButton : MonoBehaviour
{
    [SerializeField] private TMP_Text txt;

    private void Start()
    {
        if (Sounds.on)
            txt.text = "SOUND OFF";
        else
            txt.text = "SOUND ON";
    }
}
