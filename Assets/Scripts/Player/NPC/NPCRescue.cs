using System.Collections;
using UnityEngine;

public class NPCRescue : MonoBehaviour
{
    public int rewardPoints = 100;
    public int rewardAmmo = 40;
    private bool rescued = false;

    public void Rescue()
    {
        if (rescued) return;
        rescued = true;
        GameManager.Instance.AddScore(rewardPoints);

        GameManager.Instance.RespawnNPCAfterDelay(10f);

        GameManager.Instance.AddBullet(rewardAmmo);
        Destroy(gameObject);
    }
}
