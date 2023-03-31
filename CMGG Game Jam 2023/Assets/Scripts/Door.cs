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
            SceneManager.LoadScene("End Screen");
            //SceneManager.LoadSceneAsync("Cutscene 1", LoadSceneMode.Additive);
            //SceneManager.SetActiveScene(SceneManager.GetSceneByName("Cutscene 1"));
            //playerPosData.SavePosition();
            Debug.Log("Load end scene");
        }
    }

}
