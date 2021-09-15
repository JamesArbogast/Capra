using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AeganShieldItem : BaseItem {

    public AeganShieldItem()
    {
        itemName = "Aegan Shield";
        itemDescription = "Greatly increases users defense, but can also be used to attack. Increases Zulium intake.";
        itemID = 1;
        itemType = ItemTypes.PRIMARYWEAPON;
        primaryWeaponType = PrimaryWeaponTypes.SHIELD;
        statusEffect = true;
        speedStat = -1;
        physAttackStat = 2;
        physDefenseStat = 3;
        dodgeStat = -2;
        zuliumAttackStat = 1;
        zuliumDefenseStat = 4;
        zuliumHealStat = 0;
        resistStat = 1;
        energyStat = -1;
        luckStat = 1;
        intelligenceStat = 0;
    }

}
