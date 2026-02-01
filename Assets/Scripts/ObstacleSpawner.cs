using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform player;

    public float spawnDistance = 40f; // Distance from the player
    public float spawnInterval = 10f; // Distance between obstacles
    public float minZ = -3f;
    public float maxZ = 3f;

    private float nextSpawnX;

    void Start()
    {
        nextSpawnX = player.position.x + spawnDistance;
    } // end of Start method

    void Update()
    {
        if (player.position.x + spawnDistance >= nextSpawnX)
        {
            SpawnObstacle();
            nextSpawnX += spawnInterval;
            spawnDistance += (float)0.01; // Increasing SpawnDistance to keep up with player's increasing speed
        }
    } // end of Update method

    void SpawnObstacle()
    {

        float randomZ = Random.Range(minZ, maxZ);

        Vector3 spawnPos = new Vector3(
            nextSpawnX,
            transform.position.y,   // ground height
            randomZ
        );

        // Spawn new obstacle
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
        // Destroying old obstacles to save memory
        Destroy(obstacle, 10f);

    } // end of SpawnObstacle method

} // end of ObstacleSpawner class
