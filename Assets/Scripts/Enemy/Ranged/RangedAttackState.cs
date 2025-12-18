using UnityEngine;

public class RangedAttackState : StateMachineBehaviour
{
    EnemyBase enemy;
    RangedEnemyData data;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponentInParent<EnemyBase>();
        data = animator.GetComponentInParent<RangedEnemyData>();

        enemy.agent.isStopped = true;
        enemy.lastAttackTime = Time.time;

        Shoot();
    }

    void Shoot()
    {
        if (data.projectilePrefab == null || data.firePoint == null)
            return;
        GameObject proj = Object.Instantiate(
            data.projectilePrefab,
            data.firePoint.position,
            Quaternion.LookRotation(enemy.transform.forward)
        );

        EnemyProjectile projectile = proj.GetComponent<EnemyProjectile>();
        projectile.speed = data.projectileSpeed;
        projectile.Init(enemy.transform.forward);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.agent.isStopped = false;
    }
}
