using UnityEngine;

public class CapsuleNPC : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 5f;
    public float speed = 3f;
    public Transform[] patrolPoints;
    private int currentPatrolIndex = 0;

    private enum State { Patrol, Chase };
    private State currentState = State.Patrol;
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance < detectionRange)
        {
            currentState = State.Chase;
        }
        else
        {
            currentState = State.Patrol;
        }


        // switch (currentState)
        // {
        //     case State.Patrol:

        // }
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0) return;
    }
}
