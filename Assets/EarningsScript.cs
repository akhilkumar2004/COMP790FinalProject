using UnityEngine;
using UnityEngine.UI;

public class EarningsManager : MonoBehaviour
{
    // Public fields for easy setup in the Unity Editor
    public Text earningsText; // Reference to a UI Text element to display earnings
    private float earnings = 0.0f; // Tracks the total earnings
    private float incrementAmount = 3.15f; // Amount to increment for correct orders

    void Start()
    {
        // Initialize the earnings display
        UpdateEarningsText();
    }

    // Call this method when the user fulfills a correct order
    public void CorrectOrder()
    {
        earnings += incrementAmount; // Increment earnings
        UpdateEarningsText(); // Update the display
    }

    // Updates the UI text with the current earnings
    private void UpdateEarningsText()
    {
        earningsText.text = "Earnings: $ " + earnings.ToString("F2"); // Format to 2 decimal places
    }
}