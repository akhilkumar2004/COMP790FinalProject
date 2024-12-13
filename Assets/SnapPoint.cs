using UnityEngine;

public class SnapPoint : MonoBehaviour
{
    public string requiredItem; // Tag of the item expected here
    private bool isOccupied = false;
    public ItemRegenerator regenerator;
    public OrderManageScript orderManager; // Reference to the Order Manager
    public string zoneType; // Type of this zone (e.g., "Burger", "Fries", "Sauce")

    private void OnTriggerEnter(Collider other)
    {
        if (!isOccupied && other.CompareTag(requiredItem))
        {
            // Snap the item to this point
            other.transform.position = transform.position;
            other.transform.rotation = transform.rotation;

            // Mark this snap point as occupied
            isOccupied = true;

            // Notify the Order Manager that an item was placed
            if (orderManager != null)
            {
                orderManager.ZoneItemEntered(zoneType, other.gameObject);
            }

            // Notify the Item Regenerator
            if (regenerator != null)
            {
                regenerator.ItemPlaced();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(requiredItem))
        {
            // Mark the snap point as unoccupied if the item is removed
            isOccupied = false;

            // Notify the Order Manager that an item was removed
            if (orderManager != null)
            {
                orderManager.ZoneItemExited(zoneType, other.gameObject);
            }
        }
    }
}