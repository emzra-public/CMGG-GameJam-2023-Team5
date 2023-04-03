using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Create a temporary reference to the current scene.
            Scene currentScene = SceneManager.GetActiveScene();

            // Retrieve the name of this scene.
            string sceneName = currentScene.name;

            if (sceneName == "Light Scene")
            {
                SceneManager.LoadScene("Dark Scene");
                Debug.Log("Light to dark scene");
            }
            else if (sceneName == "Dark Scene")
            {
                SceneManager.LoadScene("End Screen");
                Debug.Log("Load end scene");
            }
            
            //SceneManager.LoadSceneAsync("Cutscene 1", LoadSceneMode.Additive);
            //SceneManager.SetActiveScene(SceneManager.GetSceneByName("Cutscene 1"));
            //playerPosData.SavePosition();
        }
    }

}
