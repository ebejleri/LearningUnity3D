using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [System.Serializable]
    public class Item
    {
        public string itemName;
        public bool destroyOnUse;

        public Item(string itemName, bool destroyOnUse)
        {
            this.itemName = itemName;
            this.destroyOnUse = destroyOnUse;
        }
    }

    public List<Item> inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new List<Item>();
    }

    public void AddItemToInventory(Item newItem)
    {
        inventory.Add(newItem);
        Debug.Log("Item added to inventory: "+newItem.itemName);
    }

    public void RemoveItemFromInventory(Item newItem)
    {
        if (inventory.Contains(newItem))
        {
            inventory.Remove(newItem);
        }
    }
}
