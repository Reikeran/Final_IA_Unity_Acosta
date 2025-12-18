using UnityEngine;

public class RangedAttackState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyBase enemy = animator.GetComponentInParent<EnemyBase>();

        enemy.agent.isStopped = true;

        enemy.lastAttackTime = Time.time;
        Debug.Log("Ranged shot!");

        // Forzamos volver a Chase
        animator.SetBool("PlayerInAttackRange", false);
    }
}
