using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [Header("Score")]
    [SerializeField] int scoreValue = 10;

    public static event Action<int> OnEnemyKilled; 
    public float health = 30;
    public float deathDelay = 5;
    bool dead;
    Animator animator;
    EnemyBase enemyBase;
    void Awake()
    {
        
        animator = GetComponentInChildren<Animator>();
        enemyBase = GetComponent<EnemyBase>();
    }
    public void TakeDamage(float damage)
    {
        if (dead) return;

        health -= damage;

        if (health <= 0)
            Die();
    }

    void Die()
    {
        dead = true;

        OnEnemyKilled?.Invoke(scoreValue);

        animator.SetBool("Dead", true);

        if (enemyBase != null)
            enemyBase.Disable();

        DisableCombat();
        Destroy(gameObject, 5);
    }

    void DisableCombat()
    {
        foreach (Collider c in GetComponentsInChildren<Collider>())
            c.enabled = false;
    }
}
