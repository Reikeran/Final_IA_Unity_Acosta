using UnityEngine;

public class MeleeChaseState : StateMachineBehaviour
{
    private EnemyBase enemy;
    private MeleeEnemyData meleeData;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
         meleeData = animator.GetComponent<MeleeEnemyData>();
         enemy = animator.GetComponent<EnemyBase>();

    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.agent.isStopped = false;
        Vector3 offset = (enemy.transform.position - enemy.player.position).normalized * meleeData.offsetDistance;
        enemy.agent.SetDestination(enemy.player.position + offset);

    }
}
