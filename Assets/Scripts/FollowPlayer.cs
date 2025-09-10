using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    void LateUpdate()
    {
        Vector3 desiredPos = playerTransform.position + offset;
        transform.position = desiredPos;

        // transform.LookAt(playerTransform);
    }
}
