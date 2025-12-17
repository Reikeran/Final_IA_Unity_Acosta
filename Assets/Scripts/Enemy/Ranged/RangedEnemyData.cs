using UnityEngine;
using UnityEngine.AI;

public class RangedEnemyData : MonoBehaviour
{
    public float idealDistance = 6f;
    public float minDistance = 3f;
    private NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        int jumpArea = NavMesh.GetAreaFromName("Jump");
        agent.SetAreaCost(jumpArea, 100f);

    }
}
