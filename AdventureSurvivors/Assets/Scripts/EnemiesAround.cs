using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesAround : MonoBehaviour
{
    private List<EnemyBase> enemiesOnMap;
    public EnemyBase closestEnemy { get; private set; }

    private void Awake()
    {
        enemiesOnMap = new List<EnemyBase>();

        EnemyBase.OnAnyEnemySpawned += EnemyBase_OnAnyEnemySpawned;
        EnemyBase.OnAnyEnemyDead += EnemyBase_OnAnyEnemyDead;
    }

    private void Start()
    {
        StartCoroutine(SetClosestEnemy());
    }

    private void EnemyBase_OnAnyEnemyDead(EnemyBase enemy)
    {
        enemiesOnMap.Remove(enemy);
    }

    private void EnemyBase_OnAnyEnemySpawned(EnemyBase enemy)
    {
        enemiesOnMap.Add(enemy);
    }

    private void OnDestroy()
    {
        EnemyBase.OnAnyEnemySpawned -= EnemyBase_OnAnyEnemySpawned;
        EnemyBase.OnAnyEnemyDead -= EnemyBase_OnAnyEnemyDead;
    }

    public EnemyBase GetClosestEnemy(Vector2 position)
    {
        EnemyBase closestEnemy = null;
        float minDistance = float.MaxValue;

        foreach(EnemyBase enemy in enemiesOnMap)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if(distance < minDistance)
            {
                closestEnemy = enemy;
                minDistance = distance;
            }
        }

        return closestEnemy;
    }

    private IEnumerator SetClosestEnemy()
    {
        while (true)
        {
            closestEnemy = GetClosestEnemy(transform.position);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
