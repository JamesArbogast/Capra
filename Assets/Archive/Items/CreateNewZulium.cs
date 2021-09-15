/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewZulium : MonoBehaviour {

    private BaseZulium newZulium;
    private string[] itemStatus = new string[4] { "Common", "Uncommon", "Rare", "Legendary" };
    public string itemDescription;
    public string itemName;


    private void CreatZulium()
    {
        newZulium = new BaseZulium();
        newZulium.ItemName = itemStatus[Random.Range(0, 3)] + " Item";
        newZulium.ItemID = Random.Range(1, 101);
        ChooseItemType();
        newZulium.Attack = Random.Range(1, 10);
        newZulium.Defense = Random.Range(1, 10);
        newZulium.Resist = Random.Range(1, 10);
        newZulium.Zulium = Random.Range(1, 10);
        newZulium.Speed = Random.Range(1, 10);
        newZulium.Dodge = Random.Range(1, 10);
        newZulium.Energy = Random.Range(1, 10);
        newZulium.ItemDescription = itemDescription;
        newZulium.ItemName = itemName;
    }
    private void ChooseItemType()
    {
        int randomTemp = Random.Range(1, 8);
        if (randomTemp == 1)
        {
            newZulium.ZuliumType = BaseZulium.ZuliumTypes.DEFENSE;
        }
        else if (randomTemp == 2)
        {
            newZulium.ZuliumType = BaseZulium.ZuliumTypes.DODGE;
        }
        else if (randomTemp == 3)
        {
            newZulium.ZuliumType = BaseZulium.ZuliumTypes.ENERGY;
        }
        else if (randomTemp == 4)
        {
            newZulium.ZuliumType = BaseZulium.ZuliumTypes.HEALTH;
        }
        else if (randomTemp == 5)
        {
            newZulium.ZuliumType = BaseZulium.ZuliumTypes.HEALTH;
        }
        else if (randomTemp == 6)
        {
            newZulium.ZuliumType = BaseZulium.ZuliumTypes.RESIST;
        }
        else if (randomTemp == 7)
        {
            newZulium.ZuliumType = BaseZulium.ZuliumTypes.SPEED;
        }
        else if (randomTemp == 8)
        {
            newZulium.ZuliumType = BaseZulium.ZuliumTypes.STRENGTH;
        }
    }


}*/
