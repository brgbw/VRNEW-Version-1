using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    // List of prefabs to spawn
    [SerializeField]
    public GameObject[] spawnableObjects;
    // Location where the objects will be spawned
    [SerializeField]
    public Transform spawnLocation;
    // Spawn interval in seconds
    [SerializeField]
    public float spawnInterval;
    public GameObject timerscreen;

    private List<GameObject> spawnedObjects = new List<GameObject>();

    private void Start()
    {
  
        InvokeRepeating(nameof(SpawnRandomObject), 0f, spawnInterval);
        // Start spawning objects at regular intervals
        InvokeRepeating(nameof(ClearSpawnedObjects), 0f, spawnInterval);

    }

    void SpawnRandomObject()
    {
        if (timerscreen.activeSelf)
        {
            if (spawnableObjects.Length == 0) return;

            // Choose a random index from the list of spawnable objects
            int randomIndex = Random.Range(0, spawnableObjects.Length);
            // Instantiate the selected prefab at the spawn location
            GameObject spawneditem = Instantiate(spawnableObjects[randomIndex], spawnLocation.position, spawnLocation.rotation);
            spawnedObjects.Add(spawneditem);

        }
    }
    private void ClearSpawnedObjects()
    {

        if (timerscreen.activeSelf == false)
        {
            foreach (GameObject obj in spawnedObjects)
            {
                Destroy(obj);
            }
            spawnedObjects.Clear(); 
        }
       
    }
}

    
