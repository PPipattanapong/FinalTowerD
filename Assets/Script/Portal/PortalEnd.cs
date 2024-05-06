using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalEnd : MonoBehaviour
{
    public int enemyCount = 0;
    public bool isLoaded = false; 
    public int enemyThreshold = 5; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            DisableEnemy(other.gameObject); 
            IncrementEnemyCount(); // Update the count of disabled enemies
        }
    }

    private void DisableEnemy(GameObject enemy)
    {
        // Option 1: Deactivate the entire GameObject
        enemy.SetActive(false);

        // Optionally disable the collider to prevent further interactions
        Collider collider = enemy.GetComponent<Collider>();
        if (collider != null) collider.enabled = false;
    }

    public void IncrementEnemyCount()
    {
        enemyCount++; 

        if (enemyCount >= enemyThreshold && !isLoaded)
        {
            isLoaded = true;
            LoadNextScene(); 
        }
    }

    private void LoadNextScene()
    {
        // Load the next scene by its build index
        SceneManager.LoadScene(1); 
    }
}