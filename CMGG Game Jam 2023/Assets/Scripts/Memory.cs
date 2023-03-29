using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : MonoBehaviour
{
    public int itemId;
    public int memories;

    private void Start()
    {
        memories = Inventory.memories;
        itemId = memories;

    }
}