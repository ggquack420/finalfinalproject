using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject deathScreenUI; //Reference to the Death Screen UI

    void Start()
    {
        //Ensure the Death Screen is hidden at the start
        if (deathScreenUI != null)
        {
            deathScreenUI.SetActive(false);
        }
    }


    //Activates the Death Screen UI.
    public void ShowDeathScreen()
    {
        if (deathScreenUI != null)
        {
            deathScreenUI.SetActive(true);
            Time.timeScale = 0f; //Pause the game
        }
        else
        {
            Debug.LogWarning("Death Screen UI is not assigned in the Inspector!");
        }
    }

    //Respawns the player by reloading the current scene.
    public void Respawn()
    {
        Time.timeScale = 1f; //Unpause the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Reload the current scene
    }

    //Returns the player to the main menu.
    public void GoToMainMenu()
    {
        Time.timeScale = 1f; //Unpause the game
        SceneManager.LoadScene("MainMenu"); //Load the Main Menu scene
    }
}