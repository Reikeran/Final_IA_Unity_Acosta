using UnityEngine;
using UnityEngine.AI;

public class SlowZone : MonoBehaviour
{
    public float slowMultiplier = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        NavMeshAgent agent = other.GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            Debug.Log("EnemySlowed");
            agent.speed *= slowMultiplier;
        }
        /*PlayerMovement player = other.GetComponent<PlayerMovement>();
        if (player != null)
        {
            player.ModifySpeed(slowMultiplier);
        }*/
    }

    private void OnTriggerExit(Collider other)
    {
        NavMeshAgent agent = other.GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.speed /= slowMultiplier;
        }
        /*PlayerMovement player = other.GetComponent<PlayerMovement>();
        if (player != null)
        {
        // Return Player speed
            player.ModifySpeed(slowMultiplier);
        }*/
    }
}
