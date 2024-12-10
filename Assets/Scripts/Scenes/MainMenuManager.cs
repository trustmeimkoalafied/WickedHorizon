using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // Add this to access UI components like buttons

public class MainMenuManager : MonoBehaviour
{
    public Button playButton;  // Drag the play Button here
    public Button quitButton;  // Drag the Main Menu Button here

    private void Start()
    {
        // Add listener to buttons
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    // Restart the game (loads the SampleScene)
    private void PlayGame()
    {
        SceneManager.LoadScene("Rules");  // Replace with the name of your rules scene
    }

    // quit game
    private void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}