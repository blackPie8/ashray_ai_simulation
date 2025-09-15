using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerMovement : MonoBehaviour
{
    public PlayerNewInput controls;
    private Vector2 moveInput;
    public float speed = 15f;

    private void Awake()
    {
        // instance of PlayerNewInput class
        controls = new PlayerNewInput();
    }


    private void OnEnable()
    {
        controls.Player.Enable();

        // subscribing to events via callbacks
        controls.Player.Move.performed += OnMovePerformed;
        controls.Player.Move.canceled += OnMoveCanceled;
        controls.Player.Jump.performed += OnJumpPerformed;
    }

    private void OnDisable()
    {
        // unsubscribing
        controls.Player.Move.performed -= OnMovePerformed;
        controls.Player.Move.canceled -= OnMoveCanceled;
        controls.Player.Jump.performed -= OnJumpPerformed;

        controls.Player.Disable();
    }

    void Update()
    {
        // Player movement
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        transform.Translate(move * speed * Time.deltaTime);
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        // read the value from context in Vector2
        moveInput = context.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        // movement equals zero
        moveInput = Vector2.zero;
    }
    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("Jump!");
    }
}
