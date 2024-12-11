using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    
    public void Playgame()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void StopGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
}
