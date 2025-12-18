using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Spawning")]
    [SerializeField] EnemySpawner[] spawners;
    [SerializeField] float spawnInterval = 5f;
    [SerializeField] int minSpawns = 1;
    [SerializeField] int maxSpawns = 3;
    [SerializeField] TMP_Text scoreText;
    [Header("Score")]
    public int score;

    void OnEnable()
    {
        EnemyHealth.OnEnemyKilled += OnEnemyKilled;
    }

    void OnDisable()
    {
        EnemyHealth.OnEnemyKilled -= OnEnemyKilled;
    }

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            int amount = Random.Range(minSpawns, maxSpawns + 1);

            for (int i = 0; i < amount; i++)
            {
                EnemySpawner spawner =
                    spawners[Random.Range(0, spawners.Length)];
                spawner.Spawn();
            }
        }
    }

    void OnEnemyKilled(int value)
    {
        score += value;
        scoreText.text = "score: " + score;
    }
}
