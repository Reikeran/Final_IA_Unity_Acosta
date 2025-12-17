using UnityEngine;

public class EnemySensors : MonoBehaviour
{
    public float chaseRange = 8f;
    public float attackRange = 2f;

    private Transform player;
    private Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        animator.SetBool("PlayerInChaseRange", distance <= chaseRange);
        animator.SetBool("PlayerInAttackRange", distance <= attackRange);
    }
}
