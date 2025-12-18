using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    [Header("References")]
    public Transform player;
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

    void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
}
