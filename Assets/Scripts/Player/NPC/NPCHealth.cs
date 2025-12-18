using UnityEngine;

public class NPCHealth : MonoBehaviour, IDamageable
{
    public float maxHealth = 50;
    private float currentHealth;

    public bool IsAlive => currentHealth > 0;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Die()
    {
        gameObject.SetActive(false);
    }

    public void TakeDamage(float damage)
    {
        if (!IsAlive) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }
}
