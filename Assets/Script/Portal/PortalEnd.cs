using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalEnd : MonoBehaviour
{
    public int enemyCount = 0; // Number of enemies that triggered
    public bool isLoaded = false; // To avoid reloading the scene multiple times
    public int enemyThreshold = 5; // Number of enemies required to load the next scene

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            DisableEnemy(other.gameObject); // Disable the enemy
            IncrementEnemyCount(); // Update the count of disabled enemies
        }
    }

    private void DisableEnemy(GameObject enemy)
    {
        // Option 1: Deactivate the entire GameObject
        enemy.SetActive(false);

        // Option 2: Only disable the renderer to make it invisible (alternative approach)
        // Renderer renderer = enemy.GetComponent<Renderer>();
        // if (renderer != null) renderer.enabled = false;

        // Optionally disable the collider to prevent further interactions
        Collider collider = enemy.GetComponent<Collider>();
        if (collider != null) collider.enabled = false;
    }

    public void IncrementEnemyCount()
    {
        enemyCount++; // Increment the enemy count

        if (enemyCount >= enemyThreshold && !isLoaded)
        {
            isLoaded = true;
            LoadNextScene(); // Load the next scene when threshold is met
        }
    }

    private void LoadNextScene()
    {
        // Load the next scene by its build index
        SceneManager.LoadScene(1); // Change 1 to your desired build index
    }
}