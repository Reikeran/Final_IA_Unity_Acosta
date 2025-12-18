using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    [SerializeField] private GameObject[] enemyPrefabs;

    public void Spawn()
    {
        if (enemyPrefabs == null || enemyPrefabs.Length == 0)
        {
           
            return;
        }

        Vector3 spawnPos = transform.position;

        if (NavMesh.SamplePosition(spawnPos, out NavMeshHit hit, 3f, NavMesh.AllAreas))
        {
            spawnPos = hit.position;
        }
        else
        {
            
            return;
        }

        GameObject prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        Instantiate(prefab, spawnPos, Quaternion.identity);
    }
}
