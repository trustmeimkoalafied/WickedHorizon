using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
	// to make visual cue show up when player is w/i box collider
    [Header("Visual Cue")] // game object variable for visual cue
    [SerializeField] private GameObject visualCue; // so it shows up in inspector

    [Header("Emote Animator")]
    [SerializeField] private Animator emoteAnimator;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange; // to keep track of if player is in range

    private void Awake() 
    {
        playerInRange = false;
        visualCue.SetActive(false); // visual cue inactive at start of game, so hidden
    }

	// whether or not to show a visual cue
    private void Update() 
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying) 
        {
            visualCue.SetActive(true);
            if (InputManager.GetInstance().GetInteractPressed()) // check if player has pressed interact button
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON, emoteAnimator);
            }
        }
        else 
        {
            visualCue.SetActive(false);
        }
    }
	
	// to detect when another collider enters collider of game object
    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.tag == "Player") // check that its player and not something like the ground
        {
            playerInRange = true;
        }
    }

	// to detect when another collider exits collider of game object
    private void OnTriggerExit2D(Collider2D collider) 
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
