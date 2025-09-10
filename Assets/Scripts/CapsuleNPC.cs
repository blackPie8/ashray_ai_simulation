using UnityEngine;

public class CapsuleNPC : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 8f;
    public float speed = 5f;
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

        switch (currentState)
        {
            case State.Patrol:
                Patrol();
                break;

            case State.Chase:
                Chase();
                break;
        }
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        Transform targetPoint = patrolPoints[currentPatrolIndex];
        MoveTowards(targetPoint.position);

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.2f) {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }

    void Chase()
    {
        MoveTowards(player.position);
    }
    void MoveTowards(Vector3 targetPos)
    {
        Vector3 direction = (targetPos - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
}
