using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [Header("Reward")]
    [SerializeField] private int rewardAmmo = 40;

    private bool collected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (collected) return;

        
        if (other.CompareTag("Player"))
        {
            collected = true;

            
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddBullet(rewardAmmo);
            }

            
            Destroy(gameObject);
        }
    }
}
