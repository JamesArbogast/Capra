using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour {

    

    public string characterName;
    public int characterLevel = 1;
    public BaseCharacterClass characterClass;
    public BaseCharacterRaces characterRace;
    public int healthPoints;
    public int zuliumPoints;
    public int speed; //order of battle
    public int physAttack; //physical damage base
    public int physDefense; //damage reduction
    public int dodge; //ability to avoid attacks
    public int zuliumAttack; //capacity for using Zulium (magic) bar
    public int zuliumDefense; // defense against Zulium related attacks
    public int zuliumHeal; //ability to heal using Zulium moves
    public int resist; //percentage chance of surviving lethal hit
    public int energy; //health modifier
    public int intelligence;
    public int luck; // hit percentage modifier

    private int quol; //in game currency

    private int currentXP;
    private int requiredXP;
    private int statPointsToAllocate;


    public int StatPointsToAllocate { get; set; }

    public string CharacterName
    {
        get { return characterName; }
        set { characterName = value; }
    }

    public int CurrentXP { get; set; }
    public int RequiredXP { get; set; }

    public int CharacterLevel
    {
        get { return characterLevel; }
        set { characterLevel = value; }
    }

    public BaseCharacterClass CharacterClass
    {
        get { return characterClass; }
        set { characterClass = value; }
    }
    public int HealthPoints
    {
        get { return healthPoints; }
        set { healthPoints = value; }
    }
    public int ZuliumPoints
    {
        get { return zuliumPoints; }
        set { zuliumPoints = value; }
    }
    public int Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    public int PhysAttack
    {
        get { return physAttack; }
        set { physAttack = value; }
    }
    public int PhysDefense
    {
        get { return physDefense; }
        set { physDefense = value; }
    }
    public int Dodge
    {
        get { return dodge; }
        set { dodge = value; }
    }
    public int ZuliumAttack
    {
        get { return zuliumAttack; }
        set { zuliumAttack = value; }
    }
    public int ZuliumDefense
    {
        get { return zuliumDefense; }
        set { zuliumDefense = value; }
    }
    public int ZuliumHeal
    {
        get { return zuliumHeal; }
        set { zuliumHeal = value; }
    }
    public int Resist
    {
        get { return resist; }
        set { resist = value; }
    }
    public int Energy
    {
        get { return energy; }
        set { energy = value; }
    }
    public int Luck
    {
        get { return luck; }
        set { luck = value; }
    }
    public int Intelligence
    {
        get { return intelligence; }
        set { intelligence = value; }
    }
    public int Quol
    {
        get { return quol; }
        set { quol = value; }
    }
}