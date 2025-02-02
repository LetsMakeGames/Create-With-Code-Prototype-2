﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Initialize Variables
    public GameObject player;
    public GameObject projectilePrefab;

    public float horizontalInput = 0.0f;
    public float speed = 75.0f;

    private int bounds = 20;
    
    public int isFire = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get player input
        horizontalInput = Input.GetAxis("Horizontal");

        // Move Player
        MovePlayer();

        // Fire Projectile
        FireProjectile();
    }

    void MovePlayer()
    {
        if (Input.GetButton("Fire3"))
        {
            // Move player left/right with sprint.
            player.transform.position += (Vector3.right * horizontalInput * (speed * 3) * Time.deltaTime);
        } else
        {
            // Move player left/right, no sprint.
            player.transform.position += (Vector3.right * horizontalInput * speed * Time.deltaTime);
        }


        // Restrict player to world bounds
        if (player.transform.position.x < -bounds)
        {
            // Set player position to left bounds
            player.transform.position = new Vector3(-bounds, transform.position.y, transform.position.z);
        }
        else if (player.transform.position.x > bounds)
        {
            // Set player position to right bounds
            player.transform.position = new Vector3(bounds, transform.position.y, transform.position.z);
        }

    }

    void FireProjectile()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // Instantiate a projectile
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            isFire = 1;
        }
    }
}
