using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class BaseItem : MonoBehaviour {

    [Header("ITEM INFO")]
    public string itemName;
    public Sprite itemImage;
    public string itemDescription;
    public int itemID;
    public ItemTypes itemType;
    public PrimaryWeaponTypes primaryWeaponType;
    public ArmorTypes armorTypes;
    public Consumables consumables;
    public bool statusEffect;
    [Header("ITEM STATS")]
    public float speedStat;
    public int physAttackStat;
    public int physDefenseStat;
    public int dodgeStat;
    public int zuliumAttackStat;
    public int zuliumDefenseStat;
    public int zuliumHealStat;
    public int resistStat;
    public int energyStat;
    public int luckStat;
    public int intelligenceStat;

    public enum ItemTypes
    {
        ACCESSORY,
        ARMOR,
        PRIMARYWEAPON,
        CONSUMABLE,
        NONCONSUMABLE
    }

    public enum PrimaryWeaponTypes
    {
        NULL,
        SHIELD,
        SWORD,
        SPEAR,
        ZULCANE,
        ZULGUN,
        ZULBLADE,
        CROSSBOW,
        HORNBLADE
    }

    public enum ArmorTypes
    {
        NULL,
        AEGAN,
        FERAL,
        IBEXIAN,
        CAPRAN,
        HUMAN
    }

    public enum Consumables
    {
        NULL,
        ZULIUMKIT,
        ZULPACK,
        ADRENALINE,
        SUNWEED
    }
   
}
