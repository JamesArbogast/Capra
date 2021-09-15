using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

    new public string name;
    public int itemID = 0;
	public string description;
    public Sprite icon = null;

    public enum Types
    {
        CONSUMABLE,
        NONCONSUMABLE,
        WEAPON,
        ARMOR,
        ACCESSORY
    }

    public Types type;

    public enum UsableBy
    {
        ALL,
        NONE,
        CHAELI,
        LON,
        PIYRYL,
        ALX,
        TEERA,
        MUUI
    }

    public UsableBy usableBy;

    public virtual void UseItem()
    {

    }
}
