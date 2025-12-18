using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public NavMeshAgent agent;

    [Header("Combat")]
    public float attackCooldown = 1.2f;
    public int damage = 10;

    [HideInInspector] public float lastAttackTime;

    void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        EnemySpeedData speedData = GetComponent<EnemySpeedData>();
        if (speedData != null)
        {
            agent.speed = speedData.moveSpeed;
            agent.autoTraverseOffMeshLink = speedData.canUseNavMeshLinks;
        }
    }
    public bool CanAttack()
    {
        return Time.time - lastAttackTime >= attackCooldown;
    }
    protected void RegisterAttack()
    {
        lastAttackTime = Time.time;
    }
}
