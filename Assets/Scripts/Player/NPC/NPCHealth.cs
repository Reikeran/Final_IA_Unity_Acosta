using UnityEngine;

public class NPCHealth : MonoBehaviour
{
    public int maxHealth = 50;
    private int currentHealth;

    public bool IsAlive => currentHealth > 0;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (!IsAlive) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("NPC died");
        gameObject.SetActive(false);
    }
}
