using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public Transform door; // Assign your door GameObject here
    public float rotationAngle = -90f; // Degrees to rotate (set to -90 for the desired direction)
    public float rotationSpeed = 2f; // Speed of rotation

    private bool isDoorOpen = false;

    public void OpenDoor()
    {
        if (!isDoorOpen)
        {
            StartCoroutine(RotateDoor());
            isDoorOpen = true;
        }
    }

    private System.Collections.IEnumerator RotateDoor()
    {
        Quaternion initialRotation = door.rotation;
        Quaternion targetRotation = Quaternion.Euler(0, rotationAngle, 0) * initialRotation;

        while (Quaternion.Angle(door.rotation, targetRotation) > 0.1f)
        {
            door.rotation = Quaternion.Slerp(door.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            yield return null;
        }

        // Snap to target rotation for precision
        door.rotation = targetRotation;
    }
}