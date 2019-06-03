using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawner : MonoBehaviour
{
    /// <summary>
    /// Hug Victim Prefab to Instantiate and Pool
    /// </summary>
    [Tooltip("Place the victim prefab game object here")]
    [SerializeField] GameObject hugVictimPrefab;
    
    /// <summary>
    /// How many seconds the people spawner should wait between spawns
    /// </summary>
    [Tooltip("How many seconds between victim spawns")]
    [SerializeField] float timeBetweenSpawns;


    /// <summary>
    /// How many victims should be pooled for spawning
    /// </summary>
    [Tooltip("How many victims should be pooled for spawning")]
    [SerializeField] int maximumVictimPool = 10;

    /// <summary>
    /// Positions where victims can be spawned
    /// </summary>
    [Header("Positions where the victims can spawn")]
    [SerializeField] Transform[] spawnPositions;

    /// <summary>
    /// Game object victim pool
    /// </summary>
    GameObject[] victimPool;

    private void Awake()
    {
        // Initialize the game object pool
        InitializeObjectPool();
        // Start the keep spawning victims coroutine
        StartCoroutine(KeepSpawningVictims());
    }

    /// <summary>
    /// Method called to inititalize the victim object pool
    /// </summary>
    void InitializeObjectPool()
    {
        // Inititalize the victim game object pool to the size of the maximum amount assigned
        victimPool = new GameObject[maximumVictimPool];
        
        // Loop through instantiating victims into the object pool
        for (int loopIndex = 0; loopIndex < maximumVictimPool; loopIndex++)
        {
            // Intantiate a victim inside the victim pool at the loop's index
            victimPool[loopIndex] = Instantiate(hugVictimPrefab, RandomSpawnPosition(), hugVictimPrefab.transform.rotation);

            // Disable the victim game objects instantiated after the first
            if(loopIndex > 0)
            {
                victimPool[loopIndex].SetActive(false);
            }

        }
    }



    /// <summary>
    /// Returns a random position within the spawn positions array
    /// </summary>
    /// <returns></returns>
    Vector3 RandomSpawnPosition()
    {
        return spawnPositions[Random.Range(0, spawnPositions.Length)].position;
    }

    /// <summary>
    /// IEnumerator intended to be used as a coroutine 
    /// </summary>
    /// <returns></returns>
    IEnumerator KeepSpawningVictims()
    {
        // Wait for the amount of seconds assigned
        yield return new WaitForSeconds(timeBetweenSpawns);
        // Spawn another enemy from the pool
        SpawnEnemyFromPool();
        // Start the spawn coroutine again
        StartCoroutine(KeepSpawningVictims());
        
    }

    /// <summary>
    /// Spawns an available object from the object pool
    /// </summary>
    void SpawnEnemyFromPool()
    {
        /// Loop through the victim pool
        for (int loopIndex = 0; loopIndex < victimPool.Length; loopIndex++)
        {
            // If the loop index victim is not active...
            if(victimPool[loopIndex].activeInHierarchy == false)
            {
                // Then position the victim to a random spawnable position, activate the victim game object, and then break out of the loop
                victimPool[loopIndex].transform.position = RandomSpawnPosition();
                victimPool[loopIndex].GetComponent<HugVictim>().happyParticles.SetActive(false);
                victimPool[loopIndex].GetComponent<HugVictim>().sadParticles.SetActive(false);
                victimPool[loopIndex].SetActive(true);
                break;
            }
        }
    }

    
}
