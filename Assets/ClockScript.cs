using UnityEngine;
using TMPro;

public class ClockScript : MonoBehaviour
{
    private TextMeshPro textMeshPro;

    // Closing time string
    private string closingTime = "17:00:00";

    void Start()
    {
        // Get the TextMeshPro component attached to this GameObject
        textMeshPro = GetComponent<TextMeshPro>();
        if (textMeshPro == null)
        {
            Debug.LogError("TextMeshPro component not found! Make sure this script is attached to a GameObject with a TextMeshPro component.");
        }
    }

    void Update()
    {
        if (textMeshPro != null)
        {
            // Format the text to display the current time and closing time
            string currentTime = System.DateTime.Now.ToString("HH:mm:ss");
            textMeshPro.text = $"Current time-{currentTime}\nClosing time- {closingTime}";
        }
    }
}