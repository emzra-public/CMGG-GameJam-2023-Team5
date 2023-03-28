using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public ItemData itemData;
    [SerializeField] Inventory inventory = null;

    public InventoryItem(ItemData item)
    {
        itemData = item;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Inventory.UpdateMemories();
            Destroy(this.gameObject);
            Debug.Log("Memory Collected: " + Inventory.memories);
            GameManager.Instance.StartCutscene();
        }
    }
}