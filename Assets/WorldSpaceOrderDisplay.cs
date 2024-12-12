using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorldSpaceOrderDisplay : MonoBehaviour
{
    [Header("Screen Components")]
    public Canvas orderCanvas;
    public RectTransform canvasRectTransform;
    public Camera mainCamera;

    [Header("Order Display Elements")]
    public TextMeshProUGUI orderTypeText;
    public Transform foodItemContainer;
    public GameObject foodItemPrefab;

    [Header("Screen Positioning")]
    public Vector2 screenSize = new Vector2(1.6f, 0.9f); // 16:9 aspect ratio
    public float screenDistance = 0.1f; // Distance from backing object

    void Start()
    {
        // Ensure proper world space setup
        SetupWorldSpaceCanvas();
    }

    void SetupWorldSpaceCanvas()
    {
        // Ensure canvas is in World Space render mode
        orderCanvas.renderMode = RenderMode.WorldSpace;

        // Set canvas size to match desired screen dimensions
        if (canvasRectTransform != null)
        {
            canvasRectTransform.sizeDelta = screenSize * 100; // Multiply by 100 for proper scaling
        }

        // Position canvas slightly in front of the backing object
        if (orderCanvas != null)
        {
            orderCanvas.transform.localPosition = Vector3.forward * screenDistance;
            orderCanvas.transform.localRotation = Quaternion.identity;
        }
    }

    // Method to add food item to the display
    public void AddFoodItemToDisplay(Sprite foodIcon)
    {
        // Instantiate food item in the container
        GameObject foodItemObj = Instantiate(foodItemPrefab, foodItemContainer);

        // Get the image component and set the sprite
        Image foodImage = foodItemObj.GetComponent<Image>();
        if (foodImage != null)
        {
            foodImage.sprite = foodIcon;
            foodImage.preserveAspect = true;
        }
    }

    // Clear all current food items
    public void ClearFoodItems()
    {
        // Remove all existing food items
        foreach (Transform child in foodItemContainer)
        {
            Destroy(child.gameObject);
        }
    }

    // Update order type text
    public void SetOrderType(string orderType)
    {
        if (orderTypeText != null)
        {
            orderTypeText.text = orderType;
        }
    }
}