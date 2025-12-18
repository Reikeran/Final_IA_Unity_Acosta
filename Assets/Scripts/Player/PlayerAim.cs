using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour
{
    private PlayerInputActions input;
    private Camera mainCamera;

    [SerializeField] private LayerMask groundMask;

    void Awake()
    {
        input = new PlayerInputActions();
        mainCamera = Camera.main;
    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }

    void Update()
    {
        var (success, position) = GetMousePosition();
        if (success)
        {
            var direction = position - transform.position;

            direction.y = 0;

            transform.forward = direction;
        }
    }
    private (bool success, Vector3 position) GetMousePosition()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            return (success: true, position: hitInfo.point);
        }
        else
        {
            return (success: false, position: Vector3.zero);
        }
    }

}
