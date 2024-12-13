using UnityEngine;
using TMPro;

public class OrderManageScript : MonoBehaviour
{
    // TextMeshPro field for displaying order status
    public TextMeshPro textMeshPro;

    // Prefabs for validation
    public GameObject burgerPrefab;
    public GameObject redFriesPrefab;
    public GameObject blueFriesPrefab;
    public GameObject ketchupPrefab;
    public GameObject mayoPrefab;

    // Randomized required items for the current order
    private GameObject requiredBurger;
    private GameObject requiredFries;
    private GameObject requiredSauce;

    // References to items currently placed in the zones
    private GameObject placedBurger;
    private GameObject placedFries;
    private GameObject placedSauce;

    private string previousOrderText = ""; // Track the last order status

    void Start()
    {
        GenerateOrder();
    }

    public void ZoneItemEntered(string zoneType, GameObject item)
    {
        switch (zoneType)
        {
            case "Burger":
                if (IsPrefabInstanceOf(item, requiredBurger))
                {
                    placedBurger = item;
            
                }
                else
                {
                    UpdateOrderText("Incorrect burger in Burger zone!");
                }
                break;

            case "Fries":
                if (IsPrefabInstanceOf(item, requiredFries))
                {
                    placedFries = item;
 
                }
                else
                {
                    UpdateOrderText("Incorrect fries in Fries zone!");
                }
                break;

            case "Sauce":
                if (IsPrefabInstanceOf(item, requiredSauce))
                {
                    placedSauce = item;

                }
                else
                {
                    UpdateOrderText("Incorrect sauce in Sauce zone!");
                }
                break;
        }

        // Check if the order is complete
        if (placedBurger && placedFries && placedSauce)
        {
            CompleteOrder();
        }
    }

    public void ZoneItemExited(string zoneType, GameObject item)
    {
        switch (zoneType)
        {
            case "Burger":
                if (item == placedBurger)
                {
                    placedBurger = null;
    
                }
                break;

            case "Fries":
                if (item == placedFries)
                {
                    placedFries = null;
         
                }
                break;

            case "Sauce":
                if (item == placedSauce)
                {
                    placedSauce = null;
             
                }
                break;
        }
    }

    private void GenerateOrder()
    {
        // Randomly select fries and sauce
        requiredBurger = burgerPrefab;
        requiredFries = Random.value > 0.5f ? redFriesPrefab : blueFriesPrefab;
        requiredSauce = Random.value > 0.5f ? ketchupPrefab : mayoPrefab;

        // Display the generated order
        string friesName = requiredFries == redFriesPrefab ? "Red Fries" : "Blue Fries";
        string sauceName = requiredSauce == ketchupPrefab ? "Ketchup" : "Mayo";
        string currentOrderText = $"Order: Burger, {friesName}, {sauceName}";

        // Combine the previous order status with the current order
        if (string.IsNullOrEmpty(previousOrderText))
        {
            UpdateOrderText(currentOrderText);
        }
        else
        {
            UpdateOrderText($"{previousOrderText}\n\n{currentOrderText}");
        }
    }

    private void CompleteOrder()
    {
        // Save the completion message for the previous order
        previousOrderText = $"{textMeshPro.text}\nOrder completed!";

        // Destroy the placed items
        if (placedBurger) Destroy(placedBurger);
        if (placedFries) Destroy(placedFries);
        if (placedSauce) Destroy(placedSauce);

        // Reset references
        placedBurger = null;
        placedFries = null;
        placedSauce = null;

        // Generate a new order
        GenerateOrder();
    }

    private void UpdateOrderText(string message)
    {
        if (textMeshPro != null)
        {
            textMeshPro.text = message;
        }
    }

    private bool IsPrefabInstanceOf(GameObject instance, GameObject prefab)
    {
        return prefab != null && instance != null && instance.name.StartsWith(prefab.name);
    }
}