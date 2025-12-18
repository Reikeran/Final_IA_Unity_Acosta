using UnityEngine;
using UnityEngine.AI;

public class RangedEnemyData : EnemyBase
{
    public float idealDistance = 6f;
    public float minDistance = 3f;
    private NavMeshAgent navAgent;

    [Header("Ranged")]
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 12f;

    void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();

        int jumpArea = NavMesh.GetAreaFromName("Jump");
        navAgent.SetAreaCost(jumpArea, 100f);

    }
    public void Shoot()
    {
        if (!CanAttack()) return;

        RegisterAttack();

        GameObject proj = Instantiate(
            projectilePrefab,
            firePoint.position,
            firePoint.rotation
        );

        Rigidbody rb = proj.GetComponent<Rigidbody>();
        rb.linearVelocity = firePoint.forward * projectileSpeed;
    }
}
