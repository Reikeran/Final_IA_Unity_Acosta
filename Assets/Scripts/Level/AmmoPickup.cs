using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoAmount = 12;

    private void OnTriggerEnter(Collider other)
    {
        Weapon weapon = other.GetComponentInChildren<Weapon>();
        if (weapon != null)
        {
            weapon.reserveAmmo += ammoAmount;
            Destroy(gameObject);
        }
    }
}
