using UnityEngine;

public class SnapPoint : MonoBehaviour
{
    public string CorrectItem; // Tag of the item expected here
    private bool isOccupied = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isOccupied && other.CompareTag(CorrectItem))
        {
            // Snap the item to this point
            other.transform.position = transform.position;
            other.transform.rotation = transform.rotation;

            // Mark this snap point as occupied
            isOccupied = true;

            // Optional: Notify a manager about the placed item
            //OrderManager.Instance.ItemPlaced(requiredItemTag);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(CorrectItem))
        {
            // Mark the snap point as unoccupied if the item is removed
            isOccupied = false;
        }
    }
}
