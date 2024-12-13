using UnityEngine;
using TMPro;

public class MoneyManageScript : MonoBehaviour
{
    // TextMeshPro field for displaying earnings
    public TextMeshPro earningsText;

    // Variable to track daily earnings
    private float dailyEarnings = 0f;

    void Start()
    {
        UpdateEarningsText();
    }

    public void AddEarnings(float amount)
    {
        dailyEarnings += amount;
        UpdateEarningsText();
    }

    private void UpdateEarningsText()
    {
        if (earningsText != null)
        {
            earningsText.text = $"Daily Earnings: ${dailyEarnings:F2}";
        }
    }
}