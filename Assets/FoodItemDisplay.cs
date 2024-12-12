using UnityEngine;
using UnityEngine.UI;

public class FoodItemDisplay : MonoBehaviour
{
    [Header("UI Components")]
    public Image foodImage;

    // Method to set the food item sprite
    public void SetFoodSprite(Sprite foodSprite)
    {
        if (foodImage != null && foodSprite != null)
        {
            foodImage.sprite = foodSprite;
            foodImage.preserveAspect = true;
        }
    }
}