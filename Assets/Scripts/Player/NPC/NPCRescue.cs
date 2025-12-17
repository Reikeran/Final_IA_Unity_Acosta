using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCRescue : MonoBehaviour
{
    public int rewardPoints = 100;
    private bool rescued = false;

    public void Rescue()
    {
        if (rescued) return;

        rescued = true;
        Debug.Log("NPC rescued!");

        //ScoreManager.Instance.AddPoints(rewardPoints);
        Destroy(gameObject);
    }
}
