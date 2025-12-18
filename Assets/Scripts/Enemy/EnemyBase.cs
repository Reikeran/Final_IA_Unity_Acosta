// EnemyBase.cs
using UnityEngine;
using UnityEngine.AI;

public enum TargetType { Player, Prey }

public class EnemyBase : MonoBehaviour
{
    [Header("References")]
    public Transform player;//movement target
    public NavMeshAgent agent;

    [Header("Visual")]
    public Transform visual;

    [Header("Current Stats")]
    public float attackCooldown = 1.2f;
    public float damage = 10;

    [Header("Base Stats")]
    public float baseDamage = 10f;
    public float baseAttackCooldown = 1.5f;

    [Header("Enrage")]
    [Range(0f, 1f)]
    public float enrageThreshold = 0.3f;

    public float damageMultiplier = 1.5f;
    public float cooldownMultiplier = 0.6f;

    [HideInInspector] public float lastAttackTime;

    public Transform CurrentTarget { get; private set; }
    public TargetType CurrentTargetType { get; private set; }

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        SetCurrentTarget(player, TargetType.Player);
        damage = baseDamage;

        EnemySpeedData speedData = GetComponent<EnemySpeedData>();
        if (speedData != null)
        {
            agent.speed = speedData.moveSpeed;
            agent.autoTraverseOffMeshLink = speedData.canUseNavMeshLinks;
        }
    }

    protected virtual void OnEnable()
    {
        PlayerHealth.OnHealthChanged += OnPlayerHealthChanged;
    }

    protected virtual void OnDisable()
    {
        PlayerHealth.OnHealthChanged -= OnPlayerHealthChanged;
    }

    void OnPlayerHealthChanged(float healthRatio)
    {
        if (healthRatio <= enrageThreshold)
            EnterEnrage();
        else
            ExitEnrage();
    }

    void EnterEnrage()
    {
        damage = baseDamage * damageMultiplier;
        attackCooldown = baseAttackCooldown * cooldownMultiplier;
    }

    void ExitEnrage()
    {
        damage = baseDamage;
        attackCooldown = baseAttackCooldown;
    }

    public bool CanAttack()
    {
        return Time.time - lastAttackTime >= attackCooldown;
    }

    protected void RegisterAttack()
    {
        lastAttackTime = Time.time;
    }

    public void Disable()
    {
        if (agent != null)
            agent.enabled = false;
    }

    // Funciones para cambiar target
    public void SetCurrentTarget(Transform target, TargetType type)
    {
        CurrentTarget = target;
        CurrentTargetType = type;
    }

    public void SetCurrentTarget(Transform target)
    {
        if (target == player)
            SetCurrentTarget(player, TargetType.Player);
        else
            SetCurrentTarget(target, TargetType.Prey);
    }
}
