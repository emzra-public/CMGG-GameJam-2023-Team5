using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndSceneLoad : MonoBehaviour
{
    public GameObject dialoguePanel; // assign the dialogue panel in the inspector

    void OnCollisionEnter(Collision collision)
    {
        if (Inventory.memories == 5)
        {
            // Show the dialogue panel
            dialoguePanel.SetActive(true);
        }
    }

/*    public void LoadEndScene()
    {

        SceneManager.LoadScene("End Scene");
    }*/
}
