using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyBase enemyPrefab;
    [SerializeField] private float spawnInterval;
    private float cooldown;
    [SerializeField] private float spawnRange;

    private void Awake()
    {
        cooldown = spawnInterval;
    }

    private void Update()
    {
        if (cooldown <= 0)
        {
            Vector3 spawnDirection = Random.insideUnitCircle;
            Vector3 spawnPosition = PlayerCharacters.Instance.transform.position + spawnDirection.normalized * spawnRange;
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            cooldown = spawnInterval;
            return;
        }

        cooldown -= Time.deltaTime;
    }
}
