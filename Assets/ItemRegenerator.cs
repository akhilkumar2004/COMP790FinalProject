using UnityEngine;

public class ItemRegenerator : MonoBehaviour
{
    [System.Serializable]
    public class ItemSpawnPoint
    {
        public GameObject itemPrefab; // Prefab of the item to spawn
        public Transform spawnPoint; // The position and rotation to spawn the item
    }

    public ItemSpawnPoint[] spawnPoints; // Array of items and their spawn points
    public float regenerationDelay = 1.0f; // Delay before regenerating items

    private bool isRegenerating = false;

    // Call this when all items are snapped into place
    public void RegenerateItems()
    {
        if (!isRegenerating)
        {
            isRegenerating = true;
            StartCoroutine(RegenerationCoroutine());
        }
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

        isRegenerating = false; // Allow regeneration again
    }
}
