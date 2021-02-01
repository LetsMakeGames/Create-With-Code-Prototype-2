using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Initialize Variables
    private int bounds = 20;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If game object is out of bounds, delete game object.
        if (transform.position.z > bounds || transform.position.z < -bounds || transform.position.x > bounds || transform.position.x < -bounds)
        {
            if (transform.position.z < -bounds)
            {
                Debug.Log("Game Over! No animals should be left unfed!");
                Destroy(gameObject);
            }
            Destroy(gameObject);
        }
    }
}
