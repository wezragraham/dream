using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<string> items = new List<string>();


    public void AddItem(string name)
    {
        items.Add(name);
      
    }
}
