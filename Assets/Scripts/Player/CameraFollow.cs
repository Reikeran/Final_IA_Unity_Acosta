using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 10f, -6f);
    public float followSpeed = 10f;

    private Quaternion fixedRotation;

    void Awake()
    {
        fixedRotation = transform.rotation;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            followSpeed * Time.deltaTime
        );

        transform.rotation = fixedRotation;
    }
}
