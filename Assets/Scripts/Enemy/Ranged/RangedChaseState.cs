using UnityEngine;

public class RangedChaseState : StateMachineBehaviour
{
    EnemyBase enemy;
    RangedEnemyData data;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
         enemy = animator.GetComponent<EnemyBase>();
         data = animator.GetComponent<RangedEnemyData>();
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
            enemy.agent.isStopped = true;
        }
    }
}
