/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewWeapon : MonoBehaviour {

    private BaseMelee newMelee;
    public string weaponDescription;
    public string weaponName;


    public void CreateMelee()
    {
        newMelee.ItemName = weaponName;
        newMelee.ItemDescription = weaponDescription;
        newMelee = new BaseMelee();
        //weapon id
        newMelee.ItemID = Random.Range(1, 101);
        //stats
        newMelee.Attack = Random.Range(1, 10);
        newMelee.Defense = Random.Range(1, 10);
        newMelee.Resist = Random.Range(1, 10);
        newMelee.Zulium = Random.Range(1, 10);
        newMelee.Speed = Random.Range(1, 10);
        newMelee.Dodge = Random.Range(1, 10);
        newMelee.Energy = Random.Range(1, 10);

        //choose type of weapon
        //spell effect id
        newMelee.ZulEffectID = Random.Range(1,101);
    }

    //random weapons selection
    private void ChooseMeleeType()
    {
        System.Array weapons = System.Enum.GetValues(typeof(BaseMelee.MeleeTypes));
        newMelee.MeleeType = (BaseMelee.MeleeTypes)weapons.GetValue(Random.Range(0, weapons.Length));
    }
}*/
