using UnityEngine;

public class ObjectChecker : MonoBehaviour
{
    public GameObject[] objects; // Array of objects to check
    public Transform[] targetPositions; // Target positions for each object
    public float positionThreshold = 0.1f; // Acceptable margin of error
    public DoorOpener doorOpener; // Reference to the DoorOpener script

    private void Update()
    {
        if (AllObjectsInPosition())
        {
            doorOpener.OpenDoor();
            enabled = false; // Disable this script once the door opens
        }
    }

    private bool AllObjectsInPosition()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (Vector3.Distance(objects[i].transform.position, targetPositions[i].position) > positionThreshold)
            {
                return false; // An object is not in the correct position
            }
        }
        return true; // All objects are in position
    }
}
