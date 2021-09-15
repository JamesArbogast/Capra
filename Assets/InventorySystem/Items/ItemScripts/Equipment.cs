using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Equipment")]
public class Equipment : Item {

    public int damage;
    public int armor;

    public override void UseItem()
    {
        base.UseItem();

        //equip the item

        //remove the item from the inventory temporarily
    }

}
