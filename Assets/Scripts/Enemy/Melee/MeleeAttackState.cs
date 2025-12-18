using UnityEngine;

public class MeleeAttackState : StateMachineBehaviour
{
    [Range(0f, 1f)] public float hitStart = 0.3f;
    [Range(0f, 1f)] public float hitEnd = 0.6f;

    private EnemyBase enemy;
    private MeleeHitbox hitbox;
    private bool damageEnabled;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponentInParent<EnemyBase>();
        hitbox = animator.GetComponentInChildren<MeleeHitbox>();

        enemy.agent.isStopped = true;
        enemy.lastAttackTime = Time.time;

        hitbox.DisableDamage();
        damageEnabled = false;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float t = stateInfo.normalizedTime % 1f;

        if (!damageEnabled && t >= hitStart)
        {
            hitbox.EnableDamage();
            damageEnabled = true;
        }

        if (damageEnabled && t >= hitEnd)
        {
            hitbox.DisableDamage();
        }

        if (t >= 1f)
        {
            animator.SetBool("PlayerInAttackRange", false);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        hitbox.DisableDamage();
    }
}
