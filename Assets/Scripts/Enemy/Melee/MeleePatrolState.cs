using UnityEngine;

public class MeleePatrolState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyBase enemy = animator.GetComponent<EnemyBase>();
        enemy.agent.isStopped = true;
    }
}
