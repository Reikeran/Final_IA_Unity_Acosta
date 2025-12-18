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
        float dist = Vector3.Distance(enemy.transform.position, enemy.CurrentTarget.position);

        enemy.agent.isStopped = false;

        if (dist > data.idealDistance)
        {
            enemy.agent.SetDestination(enemy.CurrentTarget.position);
        }
        else if (dist < data.minDistance)
        {
            Vector3 dir = (enemy.transform.position - enemy.CurrentTarget.position).normalized;
            enemy.agent.SetDestination(enemy.transform.position + dir * data.minDistance);
        }
        else
        {
            enemy.agent.isStopped = true;
        }

        float speed = enemy.agent.velocity.magnitude;
        animator.SetFloat("Speed", speed);
    }
}
