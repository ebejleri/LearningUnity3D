using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    // Start is called before the first frame update
    public string itemName = "Item";
    public bool destroyOnUse = false;
    public bool destroyOnPickup = true;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out PlayerInventory inventory))
        {
            inventory.AddItemToInventory(new PlayerInventory.Item(itemName, destroyOnUse));
            if (destroyOnPickup)
            {
                 Destroy(gameObject);
            }
        }
    }


}
