using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

    public static InventoryUI instance;

    Inventory inventory;

    public List<GameObject> itemHolderList = new List<GameObject>();
    public GameObject itemHolderPrefab;
    public Transform itemSpacer;

    public Text descriptionTextField;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        inventory = Inventory.instance;
        FillList();
    }

    void FillList()
    {
        for (int i = 0; i < inventory.inventoryList.Count; i++)
        {
            GameObject newItemHolder = Instantiate(itemHolderPrefab, itemSpacer, false);
            ItemHolder holderScript = newItemHolder.GetComponent<ItemHolder>();

            //infor being passed to UI in inventory holder
            holderScript.amountText.text = inventory.inventoryList[i].currentAmount.ToString();
            holderScript.nameOfItemText.text = inventory.inventoryList[i].item.name;
            holderScript.typeImage.sprite = inventory.inventoryList[i].item.icon;
            holderScript.typeText.text = inventory.inventoryList[i].item.type.ToString();

            itemHolderList.Add(newItemHolder);
        }
    }

    public void RecreateList()
    {
        foreach (GameObject itemHolder in itemHolderList)
        {
            Destroy(itemHolder);
        }
        itemHolderList.Clear();

        FillList();

    }
}
