using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class EquipItemButton : MonoBehaviour {

    //currently equipped inventory
    public GameObject equippedPrimaryWeapon;
    public GameObject equippedArmor;
    public GameObject equippedAccessory;

    //iventory in chest
    public GameObject chestWeapon;
    public GameObject chestArmor;
    public GameObject chestAccessory;


    public List<GameObject> equippingItems = new List<GameObject>();
    public GameObject associatedItem;

    //game managers
    public ChestManager chestManager;
    public TeamInventoryManagement teamInventoryManager;


    public ItemTypes itemTypes;

    public enum ItemTypes
    {
        ACCESSORY,
        ARMOR,
        PRIMARYWEAPON,
        CONSUMABLE,
        NONCONSUMABLE
    }

    // Use this for initialization
    void Start () {

        chestManager = GameObject.Find("ChestInventoryHolder").GetComponent<ChestManager>();

        chestWeapon = chestManager.weaponsInChest[0];
        chestArmor = chestManager.armorInChest[0];
        chestAccessory = chestManager.accessoriesInChest[0];

        equippedPrimaryWeapon = GameObject.Find("TeamManagement").GetComponent<TeamManagement>().HeroTeam[0].GetComponent<HeroStateMachine>().equippedPrimaryWeapon;
        equippedArmor = GameObject.Find("TeamManagement").GetComponent<TeamManagement>().HeroTeam[0].GetComponent<HeroStateMachine>().equippedArmor;
        equippedAccessory = GameObject.Find("TeamManagement").GetComponent<TeamManagement>().HeroTeam[0].GetComponent<HeroStateMachine>().equippedAccessory;
        equippingItems = GameObject.Find("ChestInventoryHolder").GetComponent<ChestManager>().weaponsInChest;

        teamInventoryManager = GameObject.Find("TeamInventoryManagement").GetComponent<TeamInventoryManagement>();     
    }
	
	// Update is called once per frame
	void Update ()
    {

	}


    public void EquipWeapon()
    {
        teamInventoryManager.chaeliWeapons[0] = chestWeapon;
        Destroy(GameObject.Find("ChestWeaponItemHolder(Clone)"));
        chestManager.weaponsInChest[0] = chestManager.NoneItemWeapon;
        chestManager.ChestWeaponPanels();
    }

    public void EquipArmor()
    {
        teamInventoryManager.chaeliArmors[0] = chestArmor;
        Destroy(GameObject.Find("ChestArmorItemHolder(Clone)"));
        chestManager.armorInChest[0] = chestManager.NoneItemArmor;
        chestManager.ChestArmorPanels();
    }

    public void EquipAccessory()
    {
        teamInventoryManager.chaeliAccessories[0] = chestAccessory;
        Destroy(GameObject.Find("ChestAccessoryItemHolder(Clone)"));
        chestManager.accessoriesInChest[0] = chestManager.NoneItemAccessory;
        chestManager.ChestAccessoryPanels();
    }

    public void StoreWeapon()
    {
        teamInventoryManager.chaeliWeapons.Add(chestWeapon);
        Destroy(GameObject.Find("ChestWeaponItemHolder(Clone)"));
        chestManager.weaponsInChest[0] = chestManager.NoneItemWeapon;
        chestManager.ChestWeaponPanels();
    }

    public void StoreArmor()
    {
        teamInventoryManager.chaeliArmors.Add(chestArmor);
        Destroy(GameObject.Find("ChestArmorItemHolder(Clone)"));
        chestManager.armorInChest[0] = chestManager.NoneItemArmor;
        chestManager.ChestArmorPanels();
    }

    public void StoreAccessory()
    {
        teamInventoryManager.chaeliAccessories.Add(chestAccessory);
        Destroy(GameObject.Find("ChestAccessoryItemHolder(Clone)"));
        chestManager.accessoriesInChest[0] = chestManager.NoneItemAccessory;
        chestManager.ChestAccessoryPanels();
    }

    public void ShowExpOnItemHover()
    {
        BaseItem chestWeaponStats = chestManager.weaponsInChest[0].GetComponent<BaseItem>();
        HeroStateMachine activeHero = GameObject.Find("TeamManagement").GetComponent<TeamManagement>().HeroTeam[0].GetComponent<HeroStateMachine>();
        activeHero.hero.speed += chestWeaponStats.speedStat;
        activeHero.hero.physAttack += chestWeaponStats.physAttackStat;
        //PhysAttackColor
        Text physAttackTextColor = GameObject.Find("PhysicalAttackNumber").GetComponent<Text>();
        physAttackTextColor.color = new Color(92, 190, 49, 255);
    }

    public void HideExpOnLeaveHover()
    {
        BaseItem chestWeaponStats = chestManager.weaponsInChest[0].GetComponent<BaseItem>();
        HeroStateMachine activeHero = GameObject.Find("TeamManagement").GetComponent<TeamManagement>().HeroTeam[0].GetComponent<HeroStateMachine>();

        activeHero.hero.physAttack -= chestWeaponStats.physAttackStat;

        Text physAttackTextColor = GameObject.Find("PhysicalAttackNumber").GetComponent<Text>();
        physAttackTextColor.color = new Color(155, 207, 251, 255);
    }
}
