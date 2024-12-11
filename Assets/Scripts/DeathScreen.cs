using UnityEngine;

// Manages the death screen UI when the player dies.
public class DeathScreen : MonoBehaviour
{

    public GameObject deathScreenUI;

    void Start()
    {
        if (deathScreenUI != null)
        {
            deathScreenUI.SetActive(false); //Ensure the death screen is initially hidden
        }
    }

    //Activates the death screen UI.
    public void ShowDeathScreen()
    {
        if (deathScreenUI != null)
        {
            deathScreenUI.SetActive(true);
            Debug.Log("Death screen activated.");
        }
        else
        {
            Debug.LogWarning("DeathScreenUI is not assigned in the Inspector.");
        }
    }
}
