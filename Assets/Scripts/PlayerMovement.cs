using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 15f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // returns value 1 and -1
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0f, moveZ);

        // it will move through wall
        // rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        Vector3 targetPos = rb.position + movement * speed * Time.fixedDeltaTime;

        // ray-casting so that player dosen't pass through walls
        if (!Physics.Raycast(rb.position, movement, 0.6f))
        {
            // rigidbody movement
            rb.MovePosition(targetPos);
        }

    }
}
