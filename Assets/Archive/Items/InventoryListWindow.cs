using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryListWindow : MonoBehaviour {

    public GameObject itemSlotPrefab;
    public ToggleGroup itemSlotToggleGroup;
    public GameObject content;

    private int xPos = 0;
    private int yPos = 0;
    private GameObject itemSlot;

    // Use this for initialization
    void Start ()
    {
        CreateInventorySlotsInWindow();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void CreateInventorySlotsInWindow()
    {      

        for (int i = 0; i < 10; i++) //gameobject find and look for the player's inventory and get the count of the inventory
        {
            itemSlot = (GameObject)Instantiate(itemSlotPrefab);
            itemSlot.name = i.ToString();
            itemSlot.GetComponent<Toggle>().group = itemSlotToggleGroup;
            itemSlot.transform.SetParent(content.transform);
            itemSlot.GetComponent<RectTransform>().localPosition = new Vector3(xPos, yPos, 0);
            yPos -= (int)itemSlot.GetComponent<RectTransform>().rect.height;

         
        }
    }
}
