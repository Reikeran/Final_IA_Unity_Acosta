using UnityEngine;

public class RangedChaseState : StateMachineBehaviour
{
    EnemyBase enemy;
    RangedEnemyData data;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponentInParent<EnemyBase>();
         data = animator.GetComponentInParent<RangedEnemyData>();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float dist = Vector3.Distance(enemy.transform.position, enemy.player.position);
        enemy.agent.isStopped = false;

        if (dist > data.idealDistance)
        {
            
            enemy.agent.SetDestination(enemy.player.position);
        }
        else if (dist < data.minDistance)
        {
            Vector3 dir = (enemy.transform.position - enemy.player.position).normalized;
            enemy.agent.SetDestination(enemy.transform.position + dir * 3f);
        }
        else
        {
            FacePlayer();
            
            enemy.agent.isStopped = true;
        }
        float speed = enemy.agent.velocity.magnitude;
        animator.SetFloat("Speed", speed);
    }
    void FacePlayer()
    {
        Vector3 dir = enemy.player.position - enemy.transform.position;
        dir.y = 0f;

        if (dir.sqrMagnitude < 0.001f) return;

        Quaternion targetRot = Quaternion.LookRotation(dir);
        enemy.transform.rotation = Quaternion.Slerp(
            enemy.transform.rotation,
            targetRot,
            Time.deltaTime * 50f
        );
    }
}
