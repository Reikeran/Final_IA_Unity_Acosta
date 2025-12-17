using UnityEngine;

public class MeleeChaseState : StateMachineBehaviour
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyBase enemy = animator.GetComponent<EnemyBase>();
        enemy.agent.isStopped = false;
        enemy.agent.SetDestination(enemy.player.position);
    }
}
