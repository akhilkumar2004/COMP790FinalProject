using UnityEngine;

public class ItemRegenerator : MonoBehaviour
{
    [System.Serializable]
    public class ItemSpawnPoint
    {
        public GameObject itemPrefab; // Prefab of the item to spawn
        public Transform spawnPoint; // Position and rotation for spawning
    }

    [Header("Regeneration Settings")]
    public ItemSpawnPoint[] spawnPoints; // Array of item spawn points
    public float regenerationDelay = 1.0f; // Delay before regenerating items
    public int itemsToPlaceBeforeRegeneration = 3; // Number of items required to trigger regeneration

    private int itemsPlaced = 0; // Tracks the number of items placed
    private bool isRegenerating = false;

    public void ItemPlaced()
    {
        itemsPlaced++;

        if (itemsPlaced >= itemsToPlaceBeforeRegeneration)
        {
            RegenerateItems();
            itemsPlaced = 0; // Reset the count after regeneration
        }
    }

    private void RegenerateItems()
    {
        if (isRegenerating) return;

        isRegenerating = true;
        StartCoroutine(RegenerationCoroutine());
    }

    private System.Collections.IEnumerator RegenerationCoroutine()
    {
        // Optional delay before regenerating items
        yield return new WaitForSeconds(regenerationDelay);

        foreach (ItemSpawnPoint spawnPoint in spawnPoints)
        {
            if (spawnPoint.itemPrefab != null && spawnPoint.spawnPoint != null)
            {
                // Instantiate the item prefab at the spawn point
                Instantiate(spawnPoint.itemPrefab, spawnPoint.spawnPoint.position, spawnPoint.spawnPoint.rotation);
            }
        }

        isRegenerating = false;
    }
}
