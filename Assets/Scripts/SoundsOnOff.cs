using TMPro;
using UnityEngine;

public class SoundsOnOff : MonoBehaviour
{
    [SerializeField] private TMP_Text txt;

    public void TurnOnOff()
    {
        if (Sounds.on)
        {
            Sounds.on = false;
            txt.text = "SOUND ON";
        }
        else
        {
            Sounds.on = true;
            txt.text = "SOUND OFF";
        }
    }
}
