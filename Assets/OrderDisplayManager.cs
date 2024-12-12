using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class OrderDisplayManager : MonoBehaviour
{
    [System.Serializable]
    public class FoodItem
    {
        public string itemName;
    }

    [Header("UI References")]
    public TextMeshProUGUI orderTypeText;
    public GridLayoutGroup foodItemGrid;
    public GameObject foodItemTextPrefab;

    [Header("Food Items")]
    public List<FoodItem> burgers = new List<FoodItem>();
    public List<FoodItem> fries = new List<FoodItem>();
    public List<FoodItem> iceCreamFlavors = new List<FoodItem>();

    [Header("Order Generation Settings")]
    public int minOrderItems = 1;
    public int maxOrderItems = 3;

    // Current order tracking
    public List<FoodItem> currentOrderItems = new List<FoodItem>();
    public string currentOrderType;

    private void Start()
    {
        // Populate food items
        PopulateFoodItems();
        GenerateRandomOrder();
    }

    void PopulateFoodItems()
    {
        // Example food items (you can expand these in the inspector)
        burgers.Add(new FoodItem { itemName = "Cheeseburger" });
        burgers.Add(new FoodItem { itemName = "Veggie Burger" });

        fries.Add(new FoodItem { itemName = "Classic Fries" });
        fries.Add(new FoodItem { itemName = "Curly Fries" });

        iceCreamFlavors.Add(new FoodItem { itemName = "Vanilla" });
        iceCreamFlavors.Add(new FoodItem { itemName = "Chocolate" });
        iceCreamFlavors.Add(new FoodItem { itemName = "Strawberry" });
    }

    public void GenerateRandomOrder()
    {
        // Clear previous order
        currentOrderItems.Clear();
        foreach (Transform child in foodItemGrid.transform)
        {
            Destroy(child.gameObject);
        }

        // Select random order type
        currentOrderType = Random.Range(0, 2) == 0 ? "Dine In" : "Take Out";
        orderTypeText.text = currentOrderType;

        // Determine number of items in order
        int orderItemCount = Random.Range(minOrderItems, maxOrderItems + 1);

        // Generate order items
        for (int i = 0; i < orderItemCount; i++)
        {
            FoodItem selectedItem = GetRandomFoodItem();

            if (selectedItem != null)
            {
                // Add to current order
                currentOrderItems.Add(selectedItem);

                // Instantiate food item text in grid
                GameObject foodItemObj = Instantiate(foodItemTextPrefab, foodItemGrid.transform);

                // Get the TextMeshPro component
                TextMeshProUGUI itemText = foodItemObj.GetComponent<TextMeshProUGUI>();

                if (itemText != null)
                {
                    itemText.text = selectedItem.itemName;
                }
            }
        }
    }

    FoodItem GetRandomFoodItem()
    {
        // Randomly select a food category
        int categoryChoice = Random.Range(0, 3);

        switch (categoryChoice)
        {
            case 0: // Burgers
                return burgers.Count > 0 ? burgers[Random.Range(0, burgers.Count)] : null;
            case 1: // Fries
                return fries.Count > 0 ? fries[Random.Range(0, fries.Count)] : null;
            case 2: // Ice Cream
                return iceCreamFlavors.Count > 0 ? iceCreamFlavors[Random.Range(0, iceCreamFlavors.Count)] : null;
            default:
                return null;
        }
    }

    // Button method to generate a new order
    public void OnNewOrderButtonPressed()
    {
        GenerateRandomOrder();
    }
}