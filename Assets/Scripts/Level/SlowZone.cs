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
            agent.speed *= slowMultiplier;
        }
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            player.moveSpeed = player.moveSpeed * slowMultiplier;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        NavMeshAgent agent = other.GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.speed /= slowMultiplier;
        }
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {

            player.moveSpeed = player.moveSpeed / slowMultiplier;
        }
    }
}
