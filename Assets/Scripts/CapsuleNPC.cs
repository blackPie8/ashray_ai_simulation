using UnityEngine;

public class CapsuleNPC : MonoBehaviour
{
    Rigidbody rb;
    public Transform player;
    public float detectionRange = 8f;
    public float speed = 10f;

    private float targetProximity = 0.2f;
    public Transform[] patrolPoints;
    private int currentPatrolIndex = 0;

    // enum for State Management
    private enum State { Patrol, Chase };
    private State currentState = State.Patrol;
    private Renderer npcRenderer;

    public Color patrolColor = Color.green;
    public Color chaseColor = Color.red;


    void Start()
    {
        // get rigidbody and renderer
        rb = GetComponent<Rigidbody>();
        npcRenderer = GetComponent<Renderer>();

        npcRenderer.material.color = patrolColor;
    }
    void FixedUpdate()
    {
        // calc the distance b/w player and npc
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
        npcRenderer.material.color = patrolColor;
        if (patrolPoints.Length == 0) return;

        // get patrolPoint co-ordinates and move there
        Transform targetPoint = patrolPoints[currentPatrolIndex];
        MoveTowards(targetPoint.position);

        // Check if the curr distance from the target is less than targetProximity
        if (Vector3.Distance(transform.position, targetPoint.position) < targetProximity)
        {
            // loop over Patrol Points
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }

    void Chase()
    {
        npcRenderer.material.color = chaseColor;
        MoveTowards(player.position);
    }
    void MoveTowards(Vector3 targetPos)
    {
        Vector3 direction = (targetPos - transform.position).normalized;
        // transform.position += direction * speed * Time.deltaTime;   // NPCs can move through walls

        Vector3 newPos = rb.position + direction * speed * Time.fixedDeltaTime;
        rb.MovePosition(newPos);
    }
}