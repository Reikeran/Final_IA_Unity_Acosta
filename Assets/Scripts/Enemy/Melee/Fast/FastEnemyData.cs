using UnityEngine;
using UnityEngine.AI;

public class FastEnemyData : MonoBehaviour, IMeleeData
{
    [Header("Movement")]
    public float offsetDistance = 1.2f;
    private NavMeshAgent agent;

    public float OffsetDistance => offsetDistance;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        int jumpArea = NavMesh.GetAreaFromName("Jump");
        agent.SetAreaCost(jumpArea, 1f);
    }
}