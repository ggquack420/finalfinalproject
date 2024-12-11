using UnityEngine;
using UnityEngine.UI;

//Tracks and displays the player's kill count
public class KillCounter : MonoBehaviour
{
    [Header("UI Components")]
    public Text killCounterText; //Reference to the UI text displaying the kill count

    private int killCount = 0;   //Tracks the total number of kills

    void Start()
    {
        UpdateKillCounter();
    }

    //Increments the kill count and updates the UI
    public void AddKill()
    {
        killCount++;
        UpdateKillCounter();
    }

    //Updates the kill counter UI text
    void UpdateKillCounter()
    {
        if (killCounterText != null)
        {
            killCounterText.text = $" {killCount}";
        }
        else
        {
            Debug.LogWarning("KillCounterText is not assigned.");
        }
    }
}
