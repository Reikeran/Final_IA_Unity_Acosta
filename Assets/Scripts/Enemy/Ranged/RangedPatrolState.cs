using UnityEngine;

public class RangedPatrolState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<EnemyBase>().agent.isStopped = true;
    }
}
