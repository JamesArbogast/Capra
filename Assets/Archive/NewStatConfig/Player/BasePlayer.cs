using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour {

    private List<BaseStat> playerStats = new List<BaseStat>();
    private List<BaseItem> inventory = new List<BaseItem>();

    // Use this for initialization
    void Start ()
    {
        for (int i = 0; i < 10; i++)
        {
            
           // inventory.Add(item);
           // Debug.Log(inventory[i].ItemName);
           // Debug.Log(inventory[i].ItemDescription);
           // Debug.Log(inventory[i].ItemType);
        }
        Debug.Log(inventory.Count); //we have 10 items(or i items) in inventory

    }

	// Update is called once per frame
	void Update () {
		
	}

    public List<BaseItem> ReturnPlayerInventory()
    {
        return inventory;
    }
}
