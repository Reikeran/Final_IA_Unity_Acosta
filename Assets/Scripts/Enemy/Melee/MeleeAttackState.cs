using UnityEngine;

public class MeleeAttackState : StateMachineBehaviour
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyBase enemy = animator.GetComponent<EnemyBase>();

        enemy.agent.isStopped = true;

        if (Time.time - enemy.lastAttackTime >= enemy.attackCooldown)
        {
            enemy.lastAttackTime = Time.time;
            Debug.Log("Melee attack!");
            // Acá después llamamos a PlayerHealth.TakeDamage()
        }
    }
}
