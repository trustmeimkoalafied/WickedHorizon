using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip backgroundMusic;  // Drag your background music clip here in the Inspector
    public AudioClip stalkerAudio;     // Drag the stalker audio clip here in the Inspector
    private AudioSource audioSource;    // The AudioSource component to play the clips
    private DialogueManager dialogueManager;  // Reference to the DialogueManager
    private StalkerBehavior stalkerBehavior;  // Reference to the StalkerBehavior script
    public Transform player;  // Drag the player object here in the Inspector

    [SerializeField] private float sameFloorThreshold = 20f;  // The threshold for considering the same floor

    private void Start()
    {
        // Add an AudioSource component to the GameObject if it doesn't already exist
        audioSource = gameObject.AddComponent<AudioSource>();

        // Set the background music clip to the AudioSource
        audioSource.clip = backgroundMusic;

        // Set loop to true if you want the music to loop
        audioSource.loop = true;

        // Play the background music
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }

        // Find the DialogueManager and StalkerBehavior in the scene
        dialogueManager = FindObjectOfType<DialogueManager>();
        stalkerBehavior = FindObjectOfType<StalkerBehavior>();
    }

    private void Update()
    {
        // Check if the Stalker is on the same floor as the player using the threshold
        if (stalkerBehavior != null && IsStalkerOnSameFloor())
        {
            // Stop the background music and play the stalker audio
            if (audioSource.clip != stalkerAudio)
            {
                audioSource.Stop();
                audioSource.clip = stalkerAudio;
                audioSource.Play();
            }
        }
        else
        {
            // If Stalker is not on the same floor, play background music
            if (audioSource.clip != backgroundMusic)
            {
                audioSource.Stop();
                audioSource.clip = backgroundMusic;
                audioSource.Play();
            }
        }

        // Adjust volume based on whether dialogue is playing
        if (dialogueManager != null && dialogueManager.dialogueIsPlaying)
        {
            audioSource.volume = 0.2f;  // Lower volume during dialogue
        }
        else
        {
            audioSource.volume = 1f;  // Restore volume after dialogue ends
        }
    }

    // Function to check if the Stalker is on the same floor as the player (based on Y position with a threshold)
    private bool IsStalkerOnSameFloor()
    {
        // Compare the absolute difference between Y positions with a threshold
        if (stalkerBehavior != null && player != null &&
            Mathf.Abs(stalkerBehavior.transform.position.y - player.position.y) <= sameFloorThreshold)
        {
            return true;
        }
        return false;
    }
}