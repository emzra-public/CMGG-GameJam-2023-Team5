using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryItem : MonoBehaviour
{
    public ItemData itemData;
    [SerializeField] Inventory inventory = null;
    SavePlayerPos playerPosData;

    void Start()
    {
        playerPosData = FindObjectOfType<SavePlayerPos>();
    }   
    
    public InventoryItem(ItemData item)
    {
        itemData = item;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Inventory.UpdateMemories();
            Debug.Log("Memory Collected: " + Inventory.memories);
            //SceneManager.LoadSceneAsync("Cutscene 1", LoadSceneMode.Additive);
            //SceneManager.SetActiveScene(SceneManager.GetSceneByName("Cutscene 1"));
            SavePlayerPos.SavePosition();
        }
    }

}