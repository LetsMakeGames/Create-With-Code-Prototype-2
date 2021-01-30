using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Initialize Variables
    public GameObject[] animalPrefabs;
    public int spawnSpeedChange = 0;
    public int spawnRange = 15;
    public int spawnPositionZ = 20;

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

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnRange, spawnRange), 0, spawnPositionZ);

            // Spawn random animal prefabs
            Instantiate(animalPrefabs[animalIndex], spawnPosition, animalPrefabs[animalIndex].transform.rotation);

            // Set spawn timer to spawn speed change, then randomize next spawn speed change.
            spawnTimer = spawnSpeedChange;
            spawnSpeedChange = Random.Range(1, 5);

        }

    }
}
