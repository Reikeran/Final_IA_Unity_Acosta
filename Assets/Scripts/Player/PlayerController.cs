using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6f;

    private CharacterController controller;
    private PlayerInputActions input;
    private Vector2 moveInput;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        input = new PlayerInputActions();
    }

    void OnEnable()
    {
        input.Enable();
        input.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        input.Player.Move.canceled += _ => moveInput = Vector2.zero;
    }

    void OnDisable()
    {
        input.Disable();
    }

    void Update()
    {
        Vector3 move =
            new Vector3(moveInput.x, 0f, moveInput.y);

        controller.Move(move * moveSpeed * Time.deltaTime);
    }
/*private void OnTriggerStay(Collider other)
{
    if (other.CompareTag("NPC") && Input.GetKeyDown(KeyCode.E))
    {
        NPCRescue rescue = other.GetComponent<NPCRescue>();
        rescue?.Rescue();
    }
}*/
}

