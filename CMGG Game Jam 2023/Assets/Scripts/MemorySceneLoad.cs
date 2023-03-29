using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MemorySceneLoad : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (Inventory.memories == null)
        {
            Debug.Log("This object does not have the proper scene assigned.");
            return;
        }

        Debug.Log("Finding scene...");

        switch (Inventory.memories)
        {
            case 1:
                SceneManager.LoadScene("Cutscene 1");
                Debug.Log("Scene Found");
                break;
            case 2:
                SceneManager.LoadScene("Cutscene 2");
                Debug.Log("Scene Found");
                break;
            case 3:
                SceneManager.LoadScene("Cutscene 3");
                Debug.Log("Scene Found");
                break;
            case 4:
                SceneManager.LoadScene("Cutscene 4");
                Debug.Log("Scene Found");
                break;
            case 5:
                SceneManager.LoadScene("Cutscene 5");
                Debug.Log("Scene Found");
                break;
            default:
                Debug.Log("This object does not have the proper scene assigned.");
                Debug.Log("Memory ID" + Inventory.memories);
                break;
        }
    }
}