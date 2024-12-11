using UnityEngine;
using UnityEngine.UI;

public class ChairPositionScript : MonoBehaviour
{
    public GameObject congratulationsText;
    public float displayDuration = 3f; 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CorrectChair"))
        {
            if (congratulationsText != null)
            {
                congratulationsText.SetActive(true);
                Invoke("HideCongratulationsText", displayDuration);
            }
            else
            {
                Debug.LogWarning("Congratulations text object is not assigned.");
            }
        }
    }

    private void HideCongratulationsText()
    {
        if (congratulationsText != null)
        {
            congratulationsText.SetActive(false);
        }
    }
}