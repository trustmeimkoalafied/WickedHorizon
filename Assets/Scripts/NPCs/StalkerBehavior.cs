using UnityEngine;

public class StalkerBehavior : MonoBehaviour
{
    // Define the StalkerState enum at the beginning of the script
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
    [SerializeField] private GameObject[] restrictedDoors;  // Array of GameObjects for restricted doors

    private int currentWaypointIndex = 0;
    private StalkerState currentState = StalkerState.Wandering;

    private void Update()
    {
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
                // Could implement idle behavior here
                break;
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
            currentState = StalkerState.Chasing;
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
            // Use the door (implement door logic here)
        }
    }

    private bool IsRestrictedDoor(GameObject door)
    {
        foreach (GameObject restrictedDoor in restrictedDoors)
        {
            if (door == restrictedDoor) return true;
        }
        return false;
    }
}
