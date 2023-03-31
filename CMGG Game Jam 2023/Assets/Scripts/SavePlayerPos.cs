using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerPos : MonoBehaviour
{
    //public GameObject player;
    static Vector3 loadedPosition;

    public static void LoadPosition()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = loadedPosition;
        Debug.Log("Loaded position");
    }
    public static void SavePosition()
    {
        GameObject player = GameObject.FindWithTag("Player");
        Vector3 playerPosition = player.transform.position;
        SavePlayerPos.loadedPosition = playerPosition;
        Debug.Log("Saved position");

    }

}
