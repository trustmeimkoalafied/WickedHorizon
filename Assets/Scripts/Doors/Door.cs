using UnityEngine;
using System.Collections; // Import this namespace for IEnumerator

public class Door : MonoBehaviour
{
    public Transform targetDoor; // Reference to the door to teleport to
    private AudioSource audioSource; // Reference to the AudioSource component
    private static bool isTeleporting = false; // Shared flag to prevent back-and-forth teleportation

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isTeleporting)
        {
            StartCoroutine(TeleportWithCooldown(collision));
        }
    }

    private IEnumerator TeleportWithCooldown(Collider2D collision)
    {
        isTeleporting = true; // Prevent additional triggers

        // Play the door sound
        if (audioSource != null)
        {
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length); // Wait for the sound to finish
        }

        // Teleport the player
        collision.transform.position = targetDoor.position;

        // Wait briefly to avoid retriggering the destination door
        yield return new WaitForSeconds(0.5f); // Adjust as necessary

        isTeleporting = false; // Re-enable teleportation
    }
}
