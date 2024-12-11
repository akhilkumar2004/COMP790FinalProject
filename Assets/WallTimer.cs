using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class WallTimer : MonoBehaviour
{
    public float timeLimit = 600f; // 10 minutes in seconds
    public TMP_Text timerText; // Assign your TextMeshPro 3D Text object here

    private float remainingTime;
    private bool timerActive = true;

    void Start()
    {
        remainingTime = timeLimit;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (timerActive)
        {
            remainingTime -= Time.deltaTime;

            if (remainingTime <= 0)
            {
                remainingTime = 0;
                timerActive = false;
                TimeUp();
            }

            UpdateTimerDisplay();
        }
    }

    private void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    private void TimeUp()
    {
        Debug.Log("Time is up!");
        // Add additional actions for when the timer reaches 0
    }

    public void ResetTimer()
    {
        remainingTime = timeLimit;
        timerActive = true;
    }
}
