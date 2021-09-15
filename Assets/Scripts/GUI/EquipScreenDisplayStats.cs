using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipScreenDisplayStats : MonoBehaviour {

    public TeamManagement teamManagement;

    //character info and stats
    public Text characterName;
    public Text characterLevel;
    public Text healthPoints;
    public Text zuliumPoints;
    public Text speed; //order of battle
    public Text physAttack; //physical damage base
    public Text physDefense; //damage reduction
    public Text dodge; //ability to avoid attacks
    public Text zuliumAttack; //capacity for using Zulium (magic) bar
    public Text zuliumDefense; // defense against Zulium related attacks
    public Text zuliumHeal; //ability to heal using Zulium moves
    public Text resist; //percentage chance of surviving lethal hit
    public Text energy; //health modifier
    public Text intelligence;
    public Text luck; // hit percentage modifier
    public Sprite characterSprite;
    public Image experienceBar;
    public Text quol; //in game currency
    public Text currentXP;
    public Text requiredXP;

    //character items display
    public Text primaryWeaponItemName;
    public Image primaryWeaponItemImage;
    public Text armorItemName;
    public Image armorItemImage;
    public Text accessoryItemName;
    public Image accessoryItemImage;


    //public GameObject teamManagement;
    public GameObject heroStats;

    // Use this for initialization
    void Start () {  

        heroStats = GameObject.Find("TeamManagement").GetComponent<TeamManagement>().HeroTeam[0];

        //stats display
        characterName = GameObject.Find("CharacterName").GetComponent<Text>();
        characterName.text = heroStats.name;
        characterLevel = GameObject.Find("CharacterLevel").GetComponent<Text>();
        characterLevel.text = "Level: " + heroStats.GetComponent<HeroStateMachine>().hero.currentLevel.ToString();
        currentXP = GameObject.Find("ExperienceText").GetComponent<Text>();
        currentXP.text = "EXP: " + heroStats.GetComponent<HeroStateMachine>().hero.currentXP + "/" + heroStats.GetComponent<HeroStateMachine>().hero.requiredXP;
        speed = GameObject.Find("SpeedNumber").GetComponent<Text>();
        speed.text = (heroStats.GetComponent<HeroStateMachine>().hero.speed * 10).ToString();
        physAttack = GameObject.Find("PhysicalAttackNumber").GetComponent<Text>();
        physAttack.text = heroStats.GetComponent<HeroStateMachine>().hero.physAttack.ToString();
        physDefense = GameObject.Find("PhysicalDefenseNumber").GetComponent<Text>();
        physDefense.text = heroStats.GetComponent<HeroStateMachine>().hero.physDefense.ToString();
        dodge = GameObject.Find("DodgeNumber").GetComponent<Text>();
        dodge.text = heroStats.GetComponent<HeroStateMachine>().hero.dodge.ToString();
        zuliumAttack = GameObject.Find("ZuliumAttackNumber").GetComponent<Text>();
        zuliumAttack.text = heroStats.GetComponent<HeroStateMachine>().hero.zuliumAttack.ToString();
        zuliumDefense = GameObject.Find("ZuliumDefenseNumber").GetComponent<Text>();
        zuliumDefense.text = heroStats.GetComponent<HeroStateMachine>().hero.zuliumDefense.ToString();
        zuliumHeal = GameObject.Find("ZuliumHealNumber").GetComponent<Text>();
        zuliumHeal.text = heroStats.GetComponent<HeroStateMachine>().hero.zuliumHeal.ToString();
        resist = GameObject.Find("ResistNumber").GetComponent<Text>();
        resist.text = heroStats.GetComponent<HeroStateMachine>().hero.resist.ToString();
        energy = GameObject.Find("EnergyNumber").GetComponent<Text>();
        energy.text = heroStats.GetComponent<HeroStateMachine>().hero.energy.ToString();
        luck = GameObject.Find("LuckNumber").GetComponent<Text>();
        luck.text = heroStats.GetComponent<HeroStateMachine>().hero.luck.ToString();
        intelligence = GameObject.Find("IntelligenceNumber").GetComponent<Text>();
        intelligence.text = heroStats.GetComponent<HeroStateMachine>().hero.intelligence.ToString();

       /* //equipped items display
        primaryWeaponItemName = GameObject.Find("EquippedWeaponItemNameText").GetComponent<Text>();
        primaryWeaponItemName.text = GameObject.Find("TeamManagement").GetComponent<TeamManagement>().HeroTeam[0].GetComponent<HeroStateMachine>().equippedPrimaryWeapon.GetComponent<BaseItem>().itemName;
        primaryWeaponItemImage = GameObject.Find("EquippedWeaponImage").GetComponent<Image>();
        primaryWeaponItemImage.sprite = GameObject.Find("TeamManagement").GetComponent<TeamManagement>().HeroTeam[0].GetComponent<HeroStateMachine>().equippedPrimaryWeapon.GetComponent<BaseItem>().itemImage;
        armorItemName = GameObject.Find("EquippedArmorItemNameText").GetComponent<Text>();
        armorItemName.text = GameObject.Find("TeamManagement").GetComponent<TeamManagement>().HeroTeam[0].GetComponent<HeroStateMachine>().equippedArmor.GetComponent<BaseItem>().itemName;
        armorItemImage = GameObject.Find("EquippedArmorImage").GetComponent<Image>();
        armorItemImage.sprite = GameObject.Find("TeamManagement").GetComponent<TeamManagement>().HeroTeam[0].GetComponent<HeroStateMachine>().equippedArmor.GetComponent<BaseItem>().itemImage;
        accessoryItemName = GameObject.Find("EquippedAccessoryItemNameText").GetComponent<Text>();
        accessoryItemName.text = GameObject.Find("TeamManagement").GetComponent<TeamManagement>().HeroTeam[0].GetComponent<HeroStateMachine>().equippedAccessory.GetComponent<BaseItem>().itemName;
        accessoryItemImage = GameObject.Find("EquippedAccessoryImage").GetComponent<Image>();
        accessoryItemImage.sprite = GameObject.Find("TeamManagement").GetComponent<TeamManagement>().HeroTeam[0].GetComponent<HeroStateMachine>().equippedAccessory.GetComponent<BaseItem>().itemImage;*/

    }
	
	// Update is called once per frame
	void Update () {

        heroStats = GameObject.Find("TeamManagement").GetComponent<TeamManagement>().HeroTeam[0];

        //stats display
        characterName = GameObject.Find("CharacterName").GetComponent<Text>();
        characterName.text = heroStats.name;
        characterLevel = GameObject.Find("CharacterLevel").GetComponent<Text>();
        characterLevel.text = "Level: " + heroStats.GetComponent<HeroStateMachine>().hero.currentLevel.ToString();
        currentXP = GameObject.Find("ExperienceText").GetComponent<Text>();
        currentXP.text = "EXP: " + heroStats.GetComponent<HeroStateMachine>().hero.currentXP + "/" + heroStats.GetComponent<HeroStateMachine>().hero.requiredXP;
        speed = GameObject.Find("SpeedNumber").GetComponent<Text>();
        speed.text = (heroStats.GetComponent<HeroStateMachine>().hero.speed * 10).ToString();
        physAttack = GameObject.Find("PhysicalAttackNumber").GetComponent<Text>();
        physAttack.text = heroStats.GetComponent<HeroStateMachine>().hero.physAttack.ToString();
        physDefense = GameObject.Find("PhysicalDefenseNumber").GetComponent<Text>();
        physDefense.text = heroStats.GetComponent<HeroStateMachine>().hero.physDefense.ToString();
        dodge = GameObject.Find("DodgeNumber").GetComponent<Text>();
        dodge.text = heroStats.GetComponent<HeroStateMachine>().hero.dodge.ToString();
        zuliumAttack = GameObject.Find("ZuliumAttackNumber").GetComponent<Text>();
        zuliumAttack.text = heroStats.GetComponent<HeroStateMachine>().hero.zuliumAttack.ToString();
        zuliumDefense = GameObject.Find("ZuliumDefenseNumber").GetComponent<Text>();
        zuliumDefense.text = heroStats.GetComponent<HeroStateMachine>().hero.zuliumDefense.ToString();
        zuliumHeal = GameObject.Find("ZuliumHealNumber").GetComponent<Text>();
        zuliumHeal.text = heroStats.GetComponent<HeroStateMachine>().hero.zuliumHeal.ToString();
        resist = GameObject.Find("ResistNumber").GetComponent<Text>();
        resist.text = heroStats.GetComponent<HeroStateMachine>().hero.resist.ToString();
        energy = GameObject.Find("EnergyNumber").GetComponent<Text>();
        energy.text = heroStats.GetComponent<HeroStateMachine>().hero.energy.ToString();
        luck = GameObject.Find("LuckNumber").GetComponent<Text>();
        luck.text = heroStats.GetComponent<HeroStateMachine>().hero.luck.ToString();
        intelligence = GameObject.Find("IntelligenceNumber").GetComponent<Text>();
        intelligence.text = heroStats.GetComponent<HeroStateMachine>().hero.intelligence.ToString();

        //equipped items display
        primaryWeaponItemName = GameObject.Find("EquippedWeaponItemNameText").GetComponent<Text>();
        primaryWeaponItemName.text = GameObject.Find("TeamInventoryManagement").GetComponent<TeamInventoryManagement>().chaeliWeapons[0].GetComponent<BaseItem>().itemName;
        primaryWeaponItemImage = GameObject.Find("EquippedWeaponImage").GetComponent<Image>();
        primaryWeaponItemImage.sprite = GameObject.Find("TeamInventoryManagement").GetComponent<TeamInventoryManagement>().chaeliWeapons[0].GetComponent<BaseItem>().itemImage;
        armorItemName = GameObject.Find("EquippedArmorItemNameText").GetComponent<Text>();
        armorItemName.text = GameObject.Find("TeamInventoryManagement").GetComponent<TeamInventoryManagement>().chaeliArmors[0].GetComponent<BaseItem>().itemName;
        armorItemImage = GameObject.Find("EquippedArmorImage").GetComponent<Image>();
        armorItemImage.sprite = GameObject.Find("TeamInventoryManagement").GetComponent<TeamInventoryManagement>().chaeliArmors[0].GetComponent<BaseItem>().itemImage;
        accessoryItemName = GameObject.Find("EquippedAccessoryItemNameText").GetComponent<Text>();
        accessoryItemName.text = GameObject.Find("TeamInventoryManagement").GetComponent<TeamInventoryManagement>().chaeliAccessories[0].GetComponent<BaseItem>().itemName;
        accessoryItemImage = GameObject.Find("EquippedAccessoryImage").GetComponent<Image>();
        accessoryItemImage.sprite = GameObject.Find("TeamInventoryManagement").GetComponent<TeamInventoryManagement>().chaeliAccessories[0].GetComponent<BaseItem>().itemImage;

    }
}
