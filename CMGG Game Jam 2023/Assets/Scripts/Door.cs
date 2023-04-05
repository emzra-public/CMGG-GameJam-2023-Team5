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
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;

            if (sceneName == "Light Scene")
            {
                SceneManager.LoadScene("Dark Scene");
            }
            else if (sceneName == "Dark Scene" && Inventory.memories == 5)
            {
                SceneManager.LoadScene("End Screen");
            }
            else
            {
                Debug.Log("Has not collected enough memories to use portal.");
            }
        }
    }
}
