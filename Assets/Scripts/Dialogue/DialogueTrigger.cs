using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // to make visual cue show up when player is w/i box collider
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Emote Animator")]
    [SerializeField] private Animator emoteAnimator;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange; // to keep track of if player is in range
    private GameObject npcGameObject;

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

            if (InputManager.GetInstance().GetInteractPressed())
            {
                // Enter dialogue mode
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON, emoteAnimator, gameObject);

                // After the dialogue starts, check if the NPC is interacted with
                CheckNPCInteraction();
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }

    private void CheckNPCInteraction()
    {
        // Access the dialogue variables
        DialogueVariables dialogueVariables = DialogueManager.GetInstance().GetDialogueVariables();

        // Check if the variable exists in the dictionary for each NPC
        if (dialogueVariables != null)
        {
            // Check for Alex's interaction
            if (dialogueVariables.variables.ContainsKey("alexInteracted"))
            {
                var alexInteractedVariable = dialogueVariables.variables["alexInteracted"];
                if (alexInteractedVariable is Ink.Runtime.IntValue alexInteracted)
                {
                    if (alexInteracted.value == 1)
                    {
                        // Alex has been interacted with, disable the NPC
                        DisableNPC("Alex");
                    }
                }
            }

            // Check for Liam's interaction
            if (dialogueVariables.variables.ContainsKey("liamInteracted"))
            {
                var liamInteractedVariable = dialogueVariables.variables["liamInteracted"];
                if (liamInteractedVariable is Ink.Runtime.IntValue liamInteracted)
                {
                    if (liamInteracted.value == 1)
                    {
                        // Liam has been interacted with, disable the NPC
                        DisableNPC("Liam");
                    }
                }
            }

            // Check for Jade's interaction
            if (dialogueVariables.variables.ContainsKey("jadeInteracted"))
            {
                var jadeInteractedVariable = dialogueVariables.variables["jadeInteracted"];
                if (jadeInteractedVariable is Ink.Runtime.IntValue jadeInteracted)
                {
                    if (jadeInteracted.value == 1)
                    {
                        // Jade has been interacted with, disable the NPC
                        DisableNPC("Jade");
                    }
                }
            }
        }
    }

    public void SetNpcGameObject(GameObject npcObject)
    {
        // Store the NPC object or perform any necessary actions with it
        npcGameObject = npcObject;
    }

    public void DisableNPC(string npcName)
    {
        GameObject npc = GameObject.Find(npcName);
        if (npc != null)
        {
            npc.SetActive(false); // or Destroy(npc);
            Debug.Log($"{npcName} has been disabled.");
        }
        else
        {
            Debug.LogWarning($"{npcName} not found!");
        }
    }

    // This method should be triggered when the dialogue finishes
    private void OnDialogueFinished()
    {
        // After the dialogue ends, disable the NPCs
        CheckNPCInteraction();
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

    // Add this method to trigger when dialogue finishes in DialogueManager
    public void TriggerOnDialogueFinished()
    {
        OnDialogueFinished();
    }
}
