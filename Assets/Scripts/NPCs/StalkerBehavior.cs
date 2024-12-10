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
    [SerializeField] private GameObject[] restrictedDoors;

    private StalkerState currentState = StalkerState.Wandering;

    private Vector2 wanderDirection = Vector2.left; // Initial wander direction (to the right)
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
    // Move in the current direction
    MoveInDirection(wanderDirection, wanderSpeed);

    // Raycast to detect if there's an obstacle in front, but cast the ray slightly later
    float raycastDistance = 1f; // The distance of the raycast itself
    float offset = 0.3f;  // This offset ensures the raycast is closer to the Stalker, giving more time to react
    
    // Calculate the raycast origin slightly ahead in the movement direction
    Vector2 raycastOrigin = (Vector2)transform.position + wanderDirection.normalized * offset;

    // Perform the raycast to detect obstacles
    RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, wanderDirection, raycastDistance, LayerMask.GetMask("Obstacle"));
    
    if (hit.collider != null)
    {
        // Reverse direction only when an obstacle is detected
        wanderDirection = -wanderDirection;
    }
}


    private void MoveInDirection(Vector2 direction, float speed)
    {
        // Move the stalker in the given direction
        transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + direction, speed * Time.deltaTime);
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
    if (other.CompareTag("Door") && !IsRestrictedDoor(other.gameObject) && currentState != StalkerState.Chasing)
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
