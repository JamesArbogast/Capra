using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedItem : MonoBehaviour {


    private Text selectedItemText;
    private List<BaseItem> playerInventory; 


    // Use this for initialization
	void Start () {
        selectedItemText = GameObject.Find("SelectedItemText").GetComponent<Text>();
        BasePlayer basePlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BasePlayer>();
        playerInventory = basePlayerScript.ReturnPlayerInventory();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowSelectedItemText()
    {
        //is the item selected?
        if (this.gameObject.GetComponent<Toggle>().isOn)
        {
            //is the slot empty? Is so, say so
            if (this.gameObject.name == "Empty")
            {
                selectedItemText.text = "This slot is empty.";
            }
            else
            {
                //selectedItemText.text = playerInventory[System.Int32.Parse(this.gameObject.name)].ItemName + " " + playerInventory[System.Int32.Parse(this.gameObject.name)].ItemDescription;
            }
        }
        //playerInventory[1]
    }
}
