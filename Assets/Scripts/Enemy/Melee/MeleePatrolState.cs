using UnityEngine;
using UnityEngine.AI;

public class MeleePatrolState : StateMachineBehaviour
{
    public float patrolRadius = 10f;
    public float repathTime = 3f;

    private EnemyBase enemy;
    private float timer;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<EnemyBase>();

        enemy.agent.isStopped = false;
        timer = repathTime;

        PickRandomDestination();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer -= Time.deltaTime;

        if (timer <= 0f || enemy.agent.remainingDistance < 0.5f)
        {
            PickRandomDestination();
            timer = repathTime;
        }
    }

    void PickRandomDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * patrolRadius;
        randomDirection += enemy.transform.position;

        if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, patrolRadius, NavMesh.AllAreas))
        {
            enemy.agent.SetDestination(hit.position);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.agent.ResetPath();
    }
}
