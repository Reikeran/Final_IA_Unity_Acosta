using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Enemy Spawning")]
    [SerializeField] private EnemySpawner[] enemySpawners;
    [SerializeField] private float enemySpawnInterval = 5f;
    [SerializeField] private int enemyMinSpawns = 1;
    [SerializeField] private int enemyMaxSpawns = 3;
    [SerializeField] private Weapon playerGun;
    [Header("NPC Spawning")]
    [SerializeField] private NPCSpawner[] npcSpawners;

    [Header("Score")]
    [SerializeField] private TMP_Text scoreText;
    public int score;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

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
        StartCoroutine(EnemySpawnLoop());
    }

    private IEnumerator EnemySpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemySpawnInterval);

            int amount = Random.Range(enemyMinSpawns, enemyMaxSpawns + 1);

            for (int i = 0; i < amount; i++)
            {
                if (enemySpawners.Length == 0) continue;

                EnemySpawner spawner = enemySpawners[Random.Range(0, enemySpawners.Length)];
                spawner.Spawn();
            }
        }
    }
    public void RespawnNPCAfterDelay(float delay)
    {
        StartCoroutine(RespawnNPCCoroutine(delay));
    }

    private IEnumerator RespawnNPCCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (npcSpawners.Length == 0) yield break;

        NPCSpawner spawner = npcSpawners[Random.Range(0, npcSpawners.Length)];
        spawner.Spawn();
    }
 
    public void AddBullet(int ammount)
    {
        playerGun.reserveAmmo += ammount;
        playerGun.RefreshAmmoText();

    }

    public void AddScore(int value)
    {
        score += value;
        if (scoreText != null)
            scoreText.text = "score: " + score;
    }

    private void OnEnemyKilled(int value)
    {
        AddScore(value);
    }
   public void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
