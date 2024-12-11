using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{    // Define behavior on collision
    public void OnCollisionEnter(Collision collision)
    {
        // Check if the object colliding is tagged as "Zombie"
        if (collision.gameObject.CompareTag("Zombie"))
        {
            Debug.Log(collision.gameObject.tag);

            Destroy(gameObject);
        }
    }
}

