using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public static Inventory instance;

    public List<InventoryItem> inventoryList = new List<InventoryItem>();

    public int maxAmount = 99;

    [System.Serializable]
    public class InventoryItem
    {
        public Item item;
        public int currentAmount;
    }

    void Awake()
    {
        instance = this;  
    }

    public void AddItem(Item itemToAdd)
    {
        InventoryItem inventItem = new InventoryItem();
        inventItem.item = itemToAdd;
        bool fullStack = false;

        for (int i = 0; i < inventoryList.Count; i++)
        {
            if(inventoryList[i].item == itemToAdd && inventoryList[i].currentAmount < maxAmount)
            {
                inventoryList[i].currentAmount++;
                return;
            }
            else
            {
                fullStack = true;
            }
        }

        if (!fullStack)
        {
            inventItem.currentAmount++;
            inventoryList.Add(inventItem);
        }
    }

    public void RemoveItem(Item itemToRemove)
    {
        for (int i = 0; i < inventoryList.Count; i++)
        {
            if (inventoryList[i].item == itemToRemove && inventoryList[i].currentAmount > maxAmount)
            {
                inventoryList[i].currentAmount--;

                if (inventoryList[i].currentAmount <= 0)
                {
                    inventoryList.Remove(inventoryList[i]);
                    return;
                }

            }
        }

            
    }

    public void SwapItems(int item1, int item2)
    {
        InventoryItem tempItem = inventoryList[item1];
        inventoryList[item1] = inventoryList[item2];
        inventoryList[item2] = tempItem;
        InventoryUI.instance.RecreateList();

    }

}
