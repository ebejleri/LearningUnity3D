using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedObject : MonoBehaviour
{
    public GameObject gameObjectToUnlock;

    public bool setObjectToUnlockToActive = false;

    public bool oneTimeActivation = true;

    private bool used = false;

    [System.Serializable]
    public class KeyInfo
    {
        public string keyName = "";
    }

    public List<KeyInfo> neededKeys;

    private List<PlayerInventory.Item> keysToRemove = new List<PlayerInventory.Item>();
    
    private int passAmount = 0;

    private PlayerInventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!used)
        {
            if (other.TryGetComponent(out PlayerInventory playerInventory))
            {
                inventory = playerInventory;
                foreach (KeyInfo key in neededKeys)
                {
                    foreach (PlayerInventory.Item item in inventory.inventory)
                    {
                        if (key.keyName.ToLower().Equals(item.itemName.ToLower()))
                        {
                            passAmount++;
                            if (item.destroyOnUse)
                            {
                                keysToRemove.Add(item);
                            }
                            break;
                        }
                    }
                }

                if (passAmount == neededKeys.Count)
                {
                    Debug.Log("All keys acquired!");
                    gameObjectToUnlock.SetActive(setObjectToUnlockToActive);
                    foreach (var key in keysToRemove)
                    {
                        inventory.RemoveItemFromInventory(key);
                        keysToRemove = new List<PlayerInventory.Item>();
                    }

                    if (oneTimeActivation)
                    {
                        used = true;
                    }
                }
                else
                {
                    Debug.Log("All keys not acquired");
                }

                passAmount = 0;
            }
        }
    }

}
