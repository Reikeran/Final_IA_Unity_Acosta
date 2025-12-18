using UnityEngine;

public class EnemySensors : MonoBehaviour
{
    [Header("Ranges")]
    public float chaseRange = 8f;
    public float attackRange = 2f;

    [SerializeField] private Animator animator;

    private EnemyBase enemy;
    private Transform player;
    private Transform currentPrey;

    void Start()
    {
        enemy = GetComponentInParent<EnemyBase>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Por defecto target al jugador
        enemy.SetCurrentTarget(player, TargetType.Player);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Prey"))
        {
            currentPrey = other.transform;
            enemy.SetCurrentTarget(currentPrey, TargetType.Prey);
        }
    }

    void Update()
    {
        // Si había prey pero ahora ya no existe, volver al jugador
        if (currentPrey == null || !currentPrey.gameObject.activeInHierarchy)
        {
            if (enemy.CurrentTargetType == TargetType.Prey)
            {
                enemy.SetCurrentTarget(player, TargetType.Player);
            }
        }

        Transform target = enemy.CurrentTarget;

        // Actualizar animaciones
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        animator.SetBool("PlayerInChaseRange", distanceToTarget <= chaseRange);
        animator.SetBool("PlayerInAttackRange", distanceToTarget <= attackRange && enemy.CanAttack());
    }
}
