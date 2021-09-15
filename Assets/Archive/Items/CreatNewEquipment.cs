/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatNewEquipment : MonoBehaviour {


    private BaseEquipment newEquipment;
    private string[] itemStatus = new string[4] { "Common", "Uncommon", "Rare", "Legendary" };
    public string itemDescription;
    public string itemName;


	// Use this for initialization
	void Start () {
		
	}

    private void CreatEquipment()
    {
        newEquipment = new BaseEquipment();
        newEquipment.ItemName = itemStatus[Random.Range(0, 3)] + " Item";
        newEquipment.ItemID = Random.Range(1, 101);
        ChooseItemType();
        newEquipment.Attack = Random.Range(1, 10);
        newEquipment.Defense = Random.Range(1, 10);
        newEquipment.Resist = Random.Range(1, 10);
        newEquipment.Zulium = Random.Range(1, 10);
        newEquipment.Speed = Random.Range(1, 10);
        newEquipment.Dodge = Random.Range(1, 10);
        newEquipment.Energy = Random.Range(1, 10);
        newEquipment.ItemDescription = itemDescription;
        newEquipment.ItemName = itemName;
    }
    private void ChooseItemType()
    {
        int randomTemp = Random.Range(1, 8);
        if (randomTemp == 1)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.HEAD;
        }
        else if (randomTemp == 2)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.CHEST;
        }
        else if (randomTemp == 3)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.EARS;
        }
        else if (randomTemp == 4)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.FEET;
        }
        else if (randomTemp == 5)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.HANDS;
        }
        else if (randomTemp == 6)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.LEGS;
        }
        else if (randomTemp == 7)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.NECK;
        }
        else if (randomTemp == 8)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.SHOULDERS;
        }
    }
        

        // Update is called once per frame
        void Update () {
		
	}
}
*/