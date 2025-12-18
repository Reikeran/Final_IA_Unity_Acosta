using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] Slider HpBar;
    public int Maxhealth = 100;
    public int health;
    private void Start()
    {
        health = Maxhealth;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        HpBar.value = health/ Maxhealth;
        if (health <= 0)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
