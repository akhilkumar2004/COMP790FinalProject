using UnityEngine;

public class StewScript : MonoBehaviour
{
    [SerializeField] private GameObject objectToRotate;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CorrectSpice"))
        {
            Destroy(collision.gameObject);

            if (objectToRotate != null)
            {
                objectToRotate.transform.Rotate(0f, -90f, 0f);
            }
        }
    }
}