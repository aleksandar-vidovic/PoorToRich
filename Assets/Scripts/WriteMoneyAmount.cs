using TMPro;
using UnityEngine;

public class WriteMoneyAmount : MonoBehaviour
{
    [SerializeField] private TMP_Text txt;

    private void Start()
    {
        txt.text = Money.amount.ToString();
    }
}
