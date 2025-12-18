using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int maxAmmoInClip = 12;
    public int currentAmmo;
    public int reserveAmmo = 36;

    public float reloadTime = 1.5f;
    private bool isReloading;

    void Awake()
    {
        currentAmmo = maxAmmoInClip;
    }

    void Update()
    {
        if (isReloading) return;

        if (Input.GetButtonDown("Fire1"))
            Shoot();

        if (Input.GetKeyDown(KeyCode.R))
            Reload();
    }

    void Shoot()
    {
        if (currentAmmo <= 0) return;

        currentAmmo--;
        Debug.Log("Bang! Ammo: " + currentAmmo);

        // spawn bullet / raycast
    }

    void Reload()
    {
        if (currentAmmo == maxAmmoInClip) return;
        if (reserveAmmo <= 0) return;

        StartCoroutine(ReloadRoutine());
    }

    System.Collections.IEnumerator ReloadRoutine()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);

        int needed = maxAmmoInClip - currentAmmo;
        int taken = Mathf.Min(needed, reserveAmmo);

        currentAmmo += taken;
        reserveAmmo -= taken;

        isReloading = false;
    }
}
