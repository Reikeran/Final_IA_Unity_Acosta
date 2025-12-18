using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public int health = 30;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
