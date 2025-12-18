using UnityEngine;
using UnityEngine.AI;

public class RangedEnemyData : EnemyBase
{
    [Header("Ranged Settings")]
    public float idealDistance = 6f; // distancia a mantener del target
    public float minDistance = 3f;

    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 12f;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        // 
        int jumpArea = NavMesh.GetAreaFromName("Jump");
        agent.SetAreaCost(jumpArea, 100f);
    }

    public void Shoot()
    {
        if (!CanAttack()) return;

        RegisterAttack();

        if (projectilePrefab == null || firePoint == null) return;

        GameObject proj = Instantiate(
            projectilePrefab,
            firePoint.position,
            firePoint.rotation
        );

        Rigidbody rb = proj.GetComponent<Rigidbody>();
        if (rb != null)
            rb.linearVelocity = (CurrentTarget.position - firePoint.position).normalized * projectileSpeed;
    }
}
