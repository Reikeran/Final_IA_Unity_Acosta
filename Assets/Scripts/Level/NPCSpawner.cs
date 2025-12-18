using UnityEngine;
using UnityEngine.AI;

public class NPCSpawner : MonoBehaviour
{
    [Header("NPC Prefab")]
    [SerializeField] private GameObject npcPrefab;

    [Header("NavMesh Sampling")]
    [SerializeField] private float sampleRadius = 2f;

    public void Spawn()
    {

        Vector3 spawnPos = transform.position;
        if (NavMesh.SamplePosition(spawnPos, out NavMeshHit hit, sampleRadius, NavMesh.AllAreas))
        {
            spawnPos = hit.position;
        }

        GameObject npc = Instantiate(npcPrefab, spawnPos, Quaternion.identity);
    }
}
