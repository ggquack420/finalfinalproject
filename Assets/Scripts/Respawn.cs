using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour


{
    public void respawn()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void main()
    {
        SceneManager.LoadScene("Main menu");
    }
    public void controls()
    {
        SceneManager.LoadScene("Controls");
    }
}
