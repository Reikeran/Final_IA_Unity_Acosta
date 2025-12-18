using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    private PlayerInputActions input;
    private Weapon weapon;

    void Awake()
    {
        input = new PlayerInputActions();
        weapon = GetComponentInChildren<Weapon>();
    }

    void OnEnable()
    {
        input.Enable();
        input.Player.Attack.performed += _ => weapon.Shoot();
        input.Player.Reload.performed += _ => weapon.Reload();
    }

    void OnDisable()
    {
        input.Disable();
    }
}
