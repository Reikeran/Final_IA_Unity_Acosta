using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private Animator animator;
    [SerializeField] private Transform aimPivot;
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
        
        Vector3 worldMove = new Vector3(moveInput.x, 0f, moveInput.y);

        if (worldMove.sqrMagnitude > 1f)
            worldMove.Normalize();

        ApplyGravity();

        Vector3 finalMove =
            worldMove * moveSpeed +
            Vector3.up * verticalVelocity;

        controller.Move(finalMove * Time.deltaTime);

        
        UpdateAnimation(worldMove);
    }
    void ApplyGravity()
    {
        if (controller.isGrounded && verticalVelocity < 0f)
            verticalVelocity = groundedForce;

        verticalVelocity += gravity * Time.deltaTime;
    }
    void UpdateAnimation(Vector3 worldMove)
    {
        bool moving = worldMove.sqrMagnitude > 0.01f;
        animator.SetBool("Moving", moving);

        if (!moving)
        {
            animator.SetFloat("XSpeed", 0f);
            animator.SetFloat("YSpeed", 0f);
            return;
        }

        Vector3 localMove = aimPivot.InverseTransformDirection(worldMove);

        animator.SetFloat("XSpeed", Mathf.Clamp(localMove.z, -1f, 1f));
        animator.SetFloat("YSpeed", Mathf.Clamp(localMove.x, -1f, 1f));
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("NPC") && Input.GetKeyDown(KeyCode.E))
        {
            NPCRescue rescue = other.GetComponent<NPCRescue>();
            rescue?.Rescue();
        }
    }
}

