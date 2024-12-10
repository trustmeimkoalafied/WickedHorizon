using UnityEngine;
using System.Collections;

public class StalkerBehavior : MonoBehaviour
{
    private enum StalkerState
    {
        Wandering,
        Chasing,
        Idle
    }

    [SerializeField] private Transform player;
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private float wanderSpeed = 2f;
    [SerializeField] private float chaseSpeed = 4f;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private GameObject[] restrictedDoors;

    private int currentWaypointIndex = 0;
    private StalkerState currentState = StalkerState.Wandering;

    private DialogueManager dialogueManager;  // Reference to the DialogueManager

    private void Start()
    {
        dialogueManager = DialogueManager.GetInstance(); // Get the DialogueManager instance
    }

    private void Update()
    {
        // If dialogue is playing, set the state to Idle
        if (dialogueManager.dialogueIsPlaying)
        {
            currentState = StalkerState.Idle;
        }
        else
        {
            // Handle regular behavior based on current state
            switch (currentState)
            {
                case StalkerState.Wandering:
                    Wander();
                    CheckForPlayer();
                    break;

                case StalkerState.Chasing:
                    ChasePlayer();
                    break;

                case StalkerState.Idle:
                    // Idle behavior (can add animations or other logic here)
                    break;
            }
        }
    }

    private void Wander()
    {
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        MoveTowards(targetWaypoint.position, wanderSpeed);

        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.2f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    private void CheckForPlayer()
    {
        if (Vector2.Distance(transform.position, player.position) <= detectionRange)
        {
            Vector2 directionToPlayer = (player.position - transform.position).normalized;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, detectionRange, LayerMask.GetMask("Obstacle"));

            if (hit.collider == null)
            {
                currentState = StalkerState.Chasing;
            }
        }
    }

    private void ChasePlayer()
    {
        MoveTowards(player.position, chaseSpeed);

        if (Vector2.Distance(transform.position, player.position) > detectionRange * 1.5f)
        {
            currentState = StalkerState.Wandering;
        }
    }

    private void MoveTowards(Vector2 target, float speed)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Door") && !IsRestrictedDoor(other.gameObject))
        {
            if (Random.Range(0f, 1f) > 0.5f)
            {
                Door doorScript = other.GetComponent<Door>();
                if (doorScript != null && !doorScript.IsLocked())
                {
                    StartCoroutine(TeleportWithCooldown(doorScript));
                }
            }
        }
    }

    private IEnumerator TeleportWithCooldown(Door door)
    {
        Vector3 targetPosition = door.targetDoor.position;
        transform.position = targetPosition;
        yield return new WaitForSeconds(0.5f);
    }

    private bool IsRestrictedDoor(GameObject door)
    {
        foreach (GameObject restrictedDoor in restrictedDoors)
        {
            if (door == restrictedDoor) return true;
        }
        return false;
    }

    // New method to be called when dialogue ends
    public void OnDialogueEnded()
    {
        currentState = StalkerState.Wandering;  // Return to wandering state after dialogue
    }
}
