using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;
    void LateUpdate()
    {
        // added a offset to set camera below the player
        Vector3 desiredPos = playerTransform.position + offset;
        transform.position = desiredPos;

        // transform.LookAt(playerTransform);
    }
}
