using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject largeObstaclePrefab;
    [SerializeField] private GameObject mediumObstaclePrefab;
    [SerializeField] private GameObject smallObstaclePrefab;

    private void Start()
    {
        SpawnObstacle(largeObstaclePrefab,  new Vector2(-6f,  0f), 60f, 1.0f);
        SpawnObstacle(largeObstaclePrefab,  new Vector2( 6f,  0f), 60f, 1.0f);

        SpawnObstacle(mediumObstaclePrefab, new Vector2( 0f,  5f), 35f, 0.7f);
        SpawnObstacle(mediumObstaclePrefab, new Vector2(-4f, -4f), 35f, 0.7f);
        SpawnObstacle(mediumObstaclePrefab, new Vector2( 4f, -4f), 35f, 0.7f);

        SpawnObstacle(smallObstaclePrefab,  new Vector2( 0f, -8f), 15f, 0.4f);
        SpawnObstacle(smallObstaclePrefab,  new Vector2(-8f,  3f), 15f, 0.4f);
        SpawnObstacle(smallObstaclePrefab,  new Vector2( 8f,  3f), 15f, 0.4f);
        SpawnObstacle(smallObstaclePrefab,  new Vector2(-2f,  8f), 15f, 0.4f);
    }

    private void SpawnObstacle(GameObject prefab, Vector2 position, float hp, float dropChance)
    {
        GameObject go = Instantiate(prefab, position, Quaternion.identity);
        Obstacle obstacle = go.GetComponent<Obstacle>();
        if (obstacle != null)
            obstacle.Init(hp, dropChance, null);
    }
}
