using UnityEngine;

public class RangedChaseState : StateMachineBehaviour
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyBase enemy = animator.GetComponent<EnemyBase>();
        RangedEnemyData data = animator.GetComponent<RangedEnemyData>();

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
            enemy.agent.isStopped = true;
        }
    }
}
