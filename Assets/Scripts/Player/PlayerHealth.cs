using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public static event Action<float> OnHealthChanged;
    [SerializeField] Slider HpBar;
    public float Maxhealth = 100;
    public float health;
    private void Start()
    {
        health = Maxhealth;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        HpBar.value = health/ Maxhealth;
        if (health <= 0)
            Die();
        OnHealthChanged?.Invoke(health / Maxhealth);
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
