using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    private PlayerNewInput controls;
    private Vector2 moveInput;
    public float speed = 15f;

    private void Awake()
    {
        controls = new PlayerNewInput();
        // Move input
        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        // Jump input
        controls.Player.Jump.performed += ctx => Jump();
    }
    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }

    void Update()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        transform.Translate(move * speed * Time.deltaTime);
    }

    void Jump()
    {
        Debug.Log("Jump!");
    }
}
