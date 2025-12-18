using UnityEngine;

public class RangedPatrolState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponentInParent<EnemyBase>().agent.isStopped = true;
    }
}
