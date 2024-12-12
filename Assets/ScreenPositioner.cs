using UnityEngine;

public class ScreenPositioner : MonoBehaviour
{
    [Header("Positioning Settings")]
    public Vector3 screenOffset = new Vector3(0, 1.5f, 2f); // Adjust based on your VR truck layout
    public Vector3 screenRotation = new Vector3(0, 0, 0); // Rotation if needed

    void Start()
    {
        // Position the entire screen setup
        transform.position = screenOffset;
        transform.rotation = Quaternion.Euler(screenRotation);
    }

    // Optional: Add method to adjust position dynamically
    public void AdjustPosition(Vector3 newOffset)
    {
        transform.position = newOffset;
    }
}