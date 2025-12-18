using UnityEngine;
using System.Collections;
using TMPro;

public class Weapon : MonoBehaviour
{
    [Header("Ammo")]
    public int maxAmmoInClip = 12;
    public int currentAmmo;
    public int reserveAmmo = 36;

    [Header("Reload")]
    public float reloadTime = 1.5f;
    private bool isReloading;

    [Header("Shooting")]
    public float fireRate = 0.2f;
    public float range = 50f;
    public int damage = 10;

    [Header("Visuals")]
    public LineRenderer tracer;

    [Header("References")]
    public Transform muzzle;

    private float nextFireTime;
    public TMP_Text ammoText;
    void Awake()
    {
        currentAmmo = maxAmmoInClip;
        RefreshAmmoText();
    }

    public void Shoot()
    {
        if (isReloading) return;
        if (Time.time < nextFireTime) return;
        if (currentAmmo <= 0) return;

        nextFireTime = Time.time + fireRate;
        currentAmmo--;

        Vector3 origin = muzzle.position;
        Vector3 direction = muzzle.forward;

        Vector3 endPoint = origin + direction * range;

        if (Physics.Raycast(origin, direction, out RaycastHit hit, range))
        {
            endPoint = hit.point;

            if (hit.collider.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(damage);
            }

        }
        RefreshAmmoText();
        StartCoroutine(ShotEffect(origin, endPoint));
    }

    public void Reload()
    {
        if (isReloading) return;
        if (currentAmmo == maxAmmoInClip) return;
        if (reserveAmmo <= 0) return;

        StartCoroutine(ReloadRoutine());
    }

    IEnumerator ReloadRoutine()
    {
        isReloading = true;
        ammoText.text = "Reloading...";
        yield return new WaitForSeconds(reloadTime);
        int needed = maxAmmoInClip - currentAmmo;
        int taken = Mathf.Min(needed, reserveAmmo);

        currentAmmo += taken;
        reserveAmmo -= taken;

        isReloading = false;
        RefreshAmmoText();
    }

    IEnumerator ShotEffect(Vector3 start, Vector3 end)
    {
        if (!tracer) yield break;

        tracer.SetPosition(0, start);
        tracer.SetPosition(1, end);
        tracer.enabled = true;

        yield return new WaitForSeconds(0.05f);

        tracer.enabled = false;
    }
    public void RefreshAmmoText()
    {
        ammoText.text = currentAmmo + "/" + reserveAmmo;
    }
}
