using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the Enemy prefab
    public LayerMask layerMask; // LayerMask to detect clicks on the LayerStage
    private bool hasSpawned = false; // Flag to check if an enemy has been spawned

    // Update is called once per frame
    void Update()
    {
        // Check if the left mouse button is clicked and an enemy has not been spawned yet
        if (Input.GetMouseButtonDown(0) && !hasSpawned)
        {
            // Create a ray from the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits something on the LayerStage
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                // Spawn an enemy at the hit point
                Spawn(hit.point);
            }

            // Set the flag to true to prevent further spawning
            hasSpawned = true;
        }
    }

    // Function to spawn an enemy at a specified position
    void Spawn(Vector3 position)
    {
        if (enemyPrefab != null)
        {
            Instantiate(enemyPrefab, position, Quaternion.identity);
        }
    }
}
