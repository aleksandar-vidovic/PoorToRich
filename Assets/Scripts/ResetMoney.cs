using UnityEngine;

public class ResetMoney : MonoBehaviour
{
    private void Start()
    {
        if (Money.amount != 0)
            Money.amount = 0;
    }
}
