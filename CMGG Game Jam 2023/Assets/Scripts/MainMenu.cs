using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Light Scene");
        Debug.Log("Play the game.");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        SceneManager.LoadScene("Quit");
    }
}