using UnityEngine;
using UnityEngine.AI;

public class RangedEnemyData : EnemyBase
{
    public float idealDistance = 6f;
    public float minDistance = 3f;

    [Header("Ranged")]
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 12f;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        int jumpArea = NavMesh.GetAreaFromName("Jump");
        agent.SetAreaCost(jumpArea, 100f);

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
