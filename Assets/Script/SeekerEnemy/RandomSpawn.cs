using UnityEngine;
using System.Collections;

public class RandomSpawn : MonoBehaviour
{
    // Array to hold the spawn points
    public Transform[] spawnPoints;

    // Prefab to spawn
    public GameObject objectToSpawn;

    // Time interval for spawning in seconds
    public float spawnInterval = 10f;

    // Unity Start method to initialize and start the Coroutine
    private void Start()
    {
        if (spawnPoints.Length == 0 || objectToSpawn == null)
        {
            Debug.LogError("Spawn points or object to spawn is not set.");
            return;
        }

        // Start the Coroutine for periodic spawning
        StartCoroutine(SpawnRoutine());
    }

    // Coroutine to spawn the object at regular intervals
    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            // Wait for the defined interval
            yield return new WaitForSeconds(spawnInterval);

            // Call the method to spawn an object
            SpawnRandomObject();
        }
    }

    // Method to spawn the object at a random spawn point
    private void SpawnRandomObject()
    {
        // Get a random index from the spawn points array
        int randomIndex = Random.Range(0, spawnPoints.Length);

        // Instantiate the object at the selected spawn point
        Instantiate(objectToSpawn, spawnPoints[randomIndex].position, spawnPoints[randomIndex].rotation);
    }
}