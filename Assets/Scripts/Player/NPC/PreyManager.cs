using UnityEngine;

public class PreyManager : MonoBehaviour
{
    public static PreyManager Instance { get; private set; }

    private Transform currentPrey;

    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    public void SetPrey(Transform prey)
    {
        currentPrey = prey;

        // Notificar a todos los enemigos
        EnemyBase[] enemies = Object.FindObjectsByType<EnemyBase>(
            FindObjectsSortMode.None
        );
        foreach (EnemyBase enemy in enemies)
        {
            enemy.SetCurrentTarget(prey, TargetType.Prey);
        }
    }

    public void ClearPrey()
    {
        currentPrey = null;

        // Resetear target de todos los enemigos al jugador
        EnemyBase[] enemies = Object.FindObjectsByType<EnemyBase>(
            FindObjectsSortMode.None
        );
        foreach (EnemyBase enemy in enemies)
        {
            enemy.SetCurrentTarget(enemy.player, TargetType.Player);
        }
    }

    public Transform GetPrey()
    {
        return currentPrey;
    }
}
