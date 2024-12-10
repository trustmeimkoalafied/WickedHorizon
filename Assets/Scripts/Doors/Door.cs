using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    public Transform targetDoor; // Reference to the door to teleport to
    private AudioSource audioSource; // Reference to the AudioSource component
    private static bool isTeleporting = false; // Shared flag to prevent back-and-forth teleportation

    [Header("Door Lock Settings")]
    [SerializeField] private bool isLocked = true;  // Initially locked
    [SerializeField] private AudioClip unlockSound;  // Sound to play when the door is unlocked
    [SerializeField] private bool isSpecialDoor = true;  // Flag to identify if this door is the special locked door

    [Header("Visual Cue")]
    [SerializeField] private Sprite visualCueSprite; // Reference to a Sprite asset for the visual cue
    private GameObject instantiatedCue; // To store the instantiated visual cue

    [Header("Objects to Destroy")]
    [SerializeField] private GameObject[] objectsToDestroy;  // Array of game objects to destroy upon triggering the special door

    [Header("Dialogue Scene")]
    [SerializeField] private TextAsset endDialogueFile;  // Reference to the Ink JSON file for the end scene

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        CreateVisualCue(); // Dynamically create the visual cue
        UpdateDoorState();  // Update the door state at the start
    }

    private void Update()
    {
        if (isSpecialDoor && isLocked)
        {
            TryUnlockDoor();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isTeleporting)
        {
            if (!isLocked)
            {
                if (isSpecialDoor)
                {
                    // Special door behavior: Destroy objects and trigger dialogue
                    TriggerEndScene();
                }
                else
                {
                    // Regular door behavior: Teleport player
                    StartCoroutine(TeleportWithCooldown(collision));
                }
            }
            else
            {
                Debug.Log("The door is locked. Interact with all NPCs first.");
            }
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
        yield return new WaitForSeconds(0.5f);

        isTeleporting = false; // Re-enable teleportation
    }

    private void CreateVisualCue()
    {
        if (visualCueSprite != null)
        {
            instantiatedCue = new GameObject("VisualCue");
            instantiatedCue.transform.position = transform.position;
            instantiatedCue.transform.SetParent(transform);

            SpriteRenderer spriteRenderer = instantiatedCue.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = visualCueSprite;

            // Set the sorting layer to "Objects"
            spriteRenderer.sortingLayerName = "Objects";

            instantiatedCue.transform.localPosition = new Vector3(0, 2.22f, 0); // Adjusted position
        }
    }

    private void UpdateDoorState()
    {
        if (instantiatedCue != null)
        {
            instantiatedCue.SetActive(isLocked); // Show or hide the visual cue based on lock state
        }
    }

    private void TryUnlockDoor()
    {
        if (HasTalkedToAllNPCs())
        {
            UnlockDoor();
        }
    }

    private bool HasTalkedToAllNPCs()
    {
        DialogueVariables dialogueVariables = DialogueManager.GetInstance().GetDialogueVariables();

        if (dialogueVariables != null)
        {
            bool alexInteracted = false;
            bool liamInteracted = false;
            bool jadeInteracted = false;

            if (dialogueVariables.variables.TryGetValue("alexInteracted", out var alexVar) &&
                alexVar is Ink.Runtime.IntValue alexValue)
            {
                alexInteracted = alexValue.value == 1;
            }

            if (dialogueVariables.variables.TryGetValue("liamInteracted", out var liamVar) &&
                liamVar is Ink.Runtime.IntValue liamValue)
            {
                liamInteracted = liamValue.value == 1;
            }

            if (dialogueVariables.variables.TryGetValue("jadeInteracted", out var jadeVar) &&
                jadeVar is Ink.Runtime.IntValue jadeValue)
            {
                jadeInteracted = jadeValue.value == 1;
            }

            return alexInteracted && liamInteracted && jadeInteracted;
        }

        return false;
    }

    private void UnlockDoor()
    {
        isLocked = false;

        if (unlockSound != null)
        {
            audioSource.PlayOneShot(unlockSound);
        }

        UpdateDoorState();
        Debug.Log("The door has been unlocked!");
    }

    private void TriggerEndScene()
    {
        // Destroy specified objects
        foreach (GameObject obj in objectsToDestroy)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }

        Debug.Log("Triggering the end scene!");

        // Trigger the end dialogue using the EnterDialogueMode method
        if (endDialogueFile != null)
        {
            // Call EnterDialogueMode to start the dialogue
            DialogueManager.GetInstance().EnterDialogueMode(endDialogueFile, null, null); // Pass null for emoteAnimator and npcGameObject if not used
        }
        else
        {
            Debug.LogWarning("End dialogue file not set.");
        }
    }

    private void OnDestroy()
    {
        if (instantiatedCue != null)
        {
            Destroy(instantiatedCue);
        }
    }
}
