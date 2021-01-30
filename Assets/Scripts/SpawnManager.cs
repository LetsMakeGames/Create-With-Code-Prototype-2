using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Initialize Variables
    public GameObject[] animalPrefabs;
    public int spawnSpeedChange = 0;

    private int timeLapse = 0;
    private int spawnTimer = 1;
    private float timer = 0.0f;
    private int animalIndex = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        // remember original spawn speed and copy to speedChange
        spawnSpeedChange = spawnTimer;

    }

    // Update is called once per frame
    void Update()
    {

        // Timer for counting seconds
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            // Randomize animalIndex every second
            animalIndex = Random.Range(0, 2);

            // Increment time to count runtime, increment timeLapse to count seconds, decrement spawnTimer to count time till spawn.
            timeLapse++;
            spawnTimer--;
            timer = 0;

        }
        
        // Spawn a random animal when spawnTimer reaches 0.
        if (spawnTimer == 0)
        {

            // Spawn random animal prefabs
            Instantiate(animalPrefabs[animalIndex], new Vector3(0, 0, 20), animalPrefabs[animalIndex].transform.rotation);

            // reset timer and randomize spawn speed change.
            spawnTimer = spawnSpeedChange;
            spawnSpeedChange = Random.Range(1, 5);

        }

    }
}
