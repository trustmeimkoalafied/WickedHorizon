using UnityEngine;

public class SpecialDoorTrigger : MonoBehaviour
{
    [SerializeField] private TextAsset endingDialogueJSON;
    [SerializeField] private GameObject[] objectsToDestroy;
    [SerializeField] private string sceneToLoad; // Scene name for switching

    private bool hasTriggeredDialogue = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!hasTriggeredDialogue)
            {
                hasTriggeredDialogue = true;

                // Start the dialogue
                DialogueManager.GetInstance().EnterDialogueMode(endingDialogueJSON, null, null);

                // Destroy objects after starting dialogue
                foreach (GameObject obj in objectsToDestroy)
                {
                    if (obj != null && obj != this.gameObject) // Avoid destroying the door itself
                    {
                        Destroy(obj);
                    }
                }
            }
            else if (DialogueManager.GetInstance().dialogueIsPlaying == false)
            {
                // Once dialogue ends, switch scenes
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
}
