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
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0f, moveZ);

        // it will move through wall
        // rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        Vector3 targetPos = rb.position + movement * speed * Time.fixedDeltaTime;

        if (!Physics.Raycast(rb.position, movement, 0.6f))
        {
            rb.MovePosition(targetPos);
        }

    }
}
