using UnityEngine;

public class EnemySensors : MonoBehaviour
{

    public float chaseRange = 8f;
    public float attackRange = 2f;

    private Transform player;
    [SerializeField] private Animator animator;
    private EnemyBase enemy;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GetComponent<EnemyBase>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        animator.SetBool("PlayerInChaseRange", distance <= chaseRange);

        bool inAttackRange = distance <= attackRange && enemy.CanAttack();
        animator.SetBool("PlayerInAttackRange", inAttackRange);
    }
}
