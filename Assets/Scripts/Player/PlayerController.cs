using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6f;

    private CharacterController controller;
    private PlayerInputActions input;
    private Vector2 moveInput;

    public float gravity = -20f;
    public float groundedForce = -2f;

    private float verticalVelocity;

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
        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);
        controller.Move(move * moveSpeed * Time.deltaTime);

        ApplyGravity();
    }
    void ApplyGravity()
    {
        if (controller.isGrounded && verticalVelocity < 0)
            verticalVelocity = groundedForce;

        verticalVelocity += gravity * Time.deltaTime;
        controller.Move(Vector3.up * verticalVelocity * Time.deltaTime);
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

