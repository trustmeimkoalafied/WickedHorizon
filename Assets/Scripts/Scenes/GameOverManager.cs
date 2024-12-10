using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // Add this to access UI components like buttons

public class GameOverManager : MonoBehaviour
{
    public Button restartButton;  // Drag the Restart Button here
    public Button mainMenuButton;  // Drag the Main Menu Button here

    private void Start()
    {
        // Add listener to buttons
        restartButton.onClick.AddListener(RestartGame);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    // Restart the game (loads the SampleScene)
    private void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");  // Replace with the name of your main game scene
    }

    // Go to the Main Menu scene
    private void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");  // Replace with the name of your Main Menu scene
    }
}
