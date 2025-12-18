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
        FacePlayerInstant();

        if (data.projectilePrefab == null || data.firePoint == null)
            return;

        GameObject proj = Object.Instantiate(
            data.projectilePrefab,
            data.firePoint.position,
            Quaternion.LookRotation(enemy.visual.forward)
        );

        EnemyProjectile projectile = proj.GetComponent<EnemyProjectile>();
        projectile.speed = data.projectileSpeed;
        projectile.damage = enemy.damage;
        projectile.Init(enemy.visual.forward);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.agent.isStopped = false;
       
    }

    void FacePlayerInstant()
    {
        Vector3 dir = enemy.player.position - enemy.visual.position;
        dir.y = 0f;

        if (dir.sqrMagnitude < 0.001f) return;

        enemy.visual.rotation = Quaternion.LookRotation(dir);
    }

}
