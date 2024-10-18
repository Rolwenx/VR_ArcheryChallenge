using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Targets : MonoBehaviour
{
    /*public GameObject target;
    public string level;
    public float spawnInterval = 3f; // Seconds between spawns
    public int maxTargets = 10; // Max targets allowed in scene

    private float spawnTimer = 0f;
    private float spawnRange = 5f; // Range for spawning

    void Start()
    {
        // Get level from PlayerPrefs if needed
        level = PlayerPrefs.GetString("level", "easy"); // Default to "easy"
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;

        // Check if we should spawn a new target
        if (spawnTimer >= spawnInterval && GameObject.FindGameObjectsWithTag("Target").Length < maxTargets)
        {
            SpawnTarget();
            spawnTimer = 0f; // Reset the timer
        }
    }

    void SpawnTarget()
    {
        // Ensure targets are spawned within a defined range (plane)
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnRange, spawnRange), 
            Random.Range(-spawnRange, spawnRange), 
            0);

        Instantiate(target, spawnPosition, Quaternion.identity);
    }*/

     public GameObject target;
    public int level; // Integer representing the difficulty level
    public float spawnInterval = 3f; // Seconds between spawns
    public int maxTargets = 10; // Max targets allowed in scene

    private float spawnTimer = 0f;
    private float spawnRange = 5f; // Range for spawning

    void Start()
    {
        // You can set the level directly here or from another script
        // level = 1 for "easy", level = 2 for "medium", etc.
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;

        // Check if we should spawn a new target
        if (spawnTimer >= spawnInterval && GameObject.FindGameObjectsWithTag("Target").Length < maxTargets)
        {
            SpawnTarget();
            spawnTimer = 0f; // Reset the timer
        }
    }

    void SpawnTarget()
{
    // Ensure targets are spawned within a defined range for x, but fixed on top of the y-axis
    Vector3 spawnPosition = new Vector3(
        Random.Range(-spawnRange, spawnRange),  // Random x position
        Random.Range(1f,5f),                                    // Fixed y position (on top of the axis)
        0);                                    // z axis is 0 for 2D

    GameObject newTarget = Instantiate(target, spawnPosition, Quaternion.identity);

    // Set the tag for the new target
    newTarget.tag = "Target";

    // Assign the difficulty level to the new target
    newTarget.GetComponent<Targets_movements>().level = level;
}

}
