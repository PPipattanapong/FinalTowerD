using UnityEngine;
using System.Collections;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private float spawnCooldown = 10f;

    private void Start()
    {
        if (spawnPoints.Length == 0 || objectToSpawn == null)
        {
            Debug.LogError("Spawn points or object to spawn is not set.");
            return;
        }

        StartCoroutine(SpawnRoutine());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnAtAllPoints();
        }
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnCooldown);
            SpawnRandomObject();
        }
    }

    private void SpawnRandomObject()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(objectToSpawn, spawnPoints[randomIndex].position, spawnPoints[randomIndex].rotation);
    }

    private void SpawnAtAllPoints()
    {
        foreach (var point in spawnPoints)
        {
            Instantiate(objectToSpawn, point.position, point.rotation);
        }
    }
}