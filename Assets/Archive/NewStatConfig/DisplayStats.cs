using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class DisplayStats : MonoBehaviour {

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

    private BaseCharacter newCharacter;
    ChaeliBaseCharacter chaeliBaseCharacter = new ChaeliBaseCharacter();


    private void Start()
    {
        characterName = transform.Find("PaperBackground").Find("CharacterNameContainer").Find("CharacterNameContainerText").GetComponent<Text>();
        characterName.text = chaeliBaseCharacter.characterName;
        healthPoints = transform.Find("PaperBackground").Find("CharacterHPContainer").Find("CharacterHPContainerText").GetComponent<Text>();
        healthPoints.text = "HP: " + chaeliBaseCharacter.healthPoints.ToString();
        zuliumPoints = transform.Find("PaperBackground").Find("CharacterZPContainer").Find("CharacterZPContainerText").GetComponent<Text>();
        zuliumPoints.text = "ZP: " + chaeliBaseCharacter.zuliumPoints.ToString();
        speed = transform.Find("PaperBackground").Find("CharacterSpeedContainer").Find("CharacterSpeedContainerText").GetComponent<Text>();
        speed.text = "Speed:" + chaeliBaseCharacter.speed.ToString();
        dodge = transform.Find("PaperBackground").Find("CharacterDodgeContainer").Find("CharacterDodgeContainerText").GetComponent<Text>();
        dodge.text = "Dodge:" + chaeliBaseCharacter.dodge.ToString();
        physAttack = transform.Find("PaperBackground").Find("CharacterPhysAttackContainer").Find("CharacterPhysAttackContainerText").GetComponent<Text>();
        physAttack.text = "Physical Attack: " + chaeliBaseCharacter.physAttack.ToString();
        physDefense = transform.Find("PaperBackground").Find("CharacterPhysDefenseContainer").Find("CharacterPhysDefenseContainerText").GetComponent<Text>();
        physDefense.text = "Physical Defense: " + chaeliBaseCharacter.physDefense.ToString();
        zuliumAttack = transform.Find("PaperBackground").Find("CharacterZulAttackContainer").Find("CharacterZulAttackContainerText").GetComponent<Text>();
        zuliumAttack.text = "Zulium Attack: " + chaeliBaseCharacter.zuliumAttack.ToString();
        zuliumDefense = transform.Find("PaperBackground").Find("CharacterZulDefenseContainer").Find("CharacterZulDefenseContainerText").GetComponent<Text>();
        zuliumDefense.text = "Zulium Defense: " + chaeliBaseCharacter.zuliumDefense.ToString();
        zuliumHeal = transform.Find("PaperBackground").Find("CharacterZulHealContainer").Find("CharacterZulHealContainerText").GetComponent<Text>();
        zuliumHeal.text = "Healing: " + chaeliBaseCharacter.zuliumHeal;
        resist = transform.Find("PaperBackground").Find("CharacterResistContainer").Find("CharacterResistContainerText").GetComponent<Text>();
        resist.text = "Resist: " + chaeliBaseCharacter.physDefense.ToString();
        energy = transform.Find("PaperBackground").Find("CharacterEnergyContainer").Find("CharacterEnergyContainerText").GetComponent<Text>();
        energy.text = "Energy: " + chaeliBaseCharacter.energy.ToString();
        luck = transform.Find("PaperBackground").Find("CharacterLuckContainer").Find("CharacterLuckContainerText").GetComponent<Text>();
        luck.text = "Luck: " + chaeliBaseCharacter.luck.ToString();
        characterLevel = transform.Find("PaperBackground").Find("CharacterLevelContainer").Find("CharacterLevelContainerText").GetComponent<Text>();
        characterLevel.text = "Level: " + chaeliBaseCharacter.characterLevel.ToString();
        characterSprite = transform.Find("PaperBackground").Find("CharacterSpriteContainer").GetComponent<Sprite>();
        intelligence = transform.Find("PaperBackground").Find("CharacterIntelligenceContainer").Find("CharacterIntelligenceContainerText").GetComponent<Text>();
        intelligence.text = "Intelligence: " + chaeliBaseCharacter.intelligence.ToString();
        experienceBar = transform.Find("PaperBackground").Find("ExperienceBar").GetComponent<Image>();
        experienceBar.fillAmount = (chaeliBaseCharacter.currentXP / chaeliBaseCharacter.requiredXP);
        currentXP = transform.Find("PaperBackground").Find("CharacterCurrentXPContainer").Find("CharacterCurrentXPContainerText").GetComponent<Text>();
        currentXP.text = "EXP: " + chaeliBaseCharacter.currentXP.ToString() + "/" + chaeliBaseCharacter.requiredXP.ToString();

    }

    void Update()
    {
        experienceBar.fillAmount = ((float)chaeliBaseCharacter.currentXP / chaeliBaseCharacter.requiredXP);
        Debug.Log((float)chaeliBaseCharacter.currentXP / chaeliBaseCharacter.requiredXP);
    }



}
