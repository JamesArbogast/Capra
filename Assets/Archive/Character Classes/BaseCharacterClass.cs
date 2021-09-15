using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterClass {

    
    public string characterClassName;
    public string characterClassDescription;
    //Stats
    /*private int speed = 12;
    private int attack = 10;
    private int defense = 10;
    private int dodge = 10;
    private int zulium = 10;
    private int resist = 10;
    private int energy = 10;
    private int agility = 10;*/

    public int characterClassHP = 50;
    public int characterClassZP = 10;
    public int characterClassSpeed = 10;
    public int characterClassPhysAttack = 10;
    public int characterClassPhysDefense = 5;
    public int characterClassDodge = 2;
    public int characterClassZuliumAttack = 10;
    public int characterClassZuliumDefense = 5;
    public int characterClassZuliumHeal = 15;
    public int characterClassResist = 5;
    public int characterClassEnergy = 2;
    public int characterClassLuck = 40;
    public int characterClassIntelligence = 2;
    

    public enum CharacterClasses
    {
        WARRIOR,
        GEOL,
        HUNTER,
        SCHOLAR,
        ZULGYMIST,
        MEDIC,
        PROTECTOR,
    }

    public string CharacterClassName
    {
        get { return characterClassName; }
        set { characterClassName = value; }
    }
    public string CharacterClassDescription
    {
        get { return characterClassDescription; }
        set { characterClassDescription = value; }
    }

    public int CharacterClassHP
    {
        get { return characterClassHP; }
        set { characterClassHP = value; }
    }
    public int CharacterClassZP
    {
        get { return characterClassZP; }
        set { characterClassZP = value; }
    }
    public int CharacterClassSpeed
    {
        get { return characterClassSpeed; }
        set { characterClassSpeed = value; }
    }
    public int CharacterClassPhysAttack
    {
        get { return characterClassPhysAttack; }
        set { characterClassPhysAttack = value; }
    }
    public int CharacterClassPhysDefense
    {
        get { return characterClassPhysDefense; }
        set { characterClassPhysDefense = value; }
    }
    public int CharacterClassDodge
    {
        get { return characterClassDodge; }
        set { characterClassDodge = value; }
    }
    public int CharacterClassZuliumAttack
    {
        get { return characterClassZuliumAttack; }
        set { characterClassZuliumAttack = value; }
    }
    public int CharacterRaceZuliumDefense
    {
        get { return characterClassZuliumDefense; }
        set { characterClassZuliumDefense = value; }
    }
    public int CharacterClassZuliumHeal
    {
        get { return characterClassZuliumHeal; }
        set { characterClassZuliumHeal = value; }
    }
    public int CharacterClassResist
    {
        get { return characterClassResist; }
        set { characterClassResist = value; }
    }
    public int CharacterClassEnergy
    {
        get { return characterClassEnergy; }
        set { characterClassEnergy = value; }
    }
    public int CharacterClassLuck
    {
        get { return characterClassLuck; }
        set { characterClassLuck = value; }
    }
    public int CharacterClassIntelligence
    {
        get { return characterClassIntelligence; }
        set { characterClassIntelligence = value; }
    }

    public List<BaseAbility> playersAbilities = new List<BaseAbility>();



    //public MainStatBonuses MainStat { get; set; }
    //public SecondStatBonuses SecondMainStat { get; set; }
    //public BonusStatBonuses BonusStat { get; set; }
    
    /*public int Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    public int Attack
    {
        get { return attack; }
        set { attack = value; }
    }
    public int Defense
    {
        get { return defense; }
        set { defense = value; }
    }
    public int Dodge
    {
        get { return dodge; }
        set { dodge = value; }
    }
    public int Zulium
    {
        get { return zulium; }
        set { zulium = value; }
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
    public int Agility
    {
        get { return agility; }
        set { agility = value; }
    }

    public enum MainStatBonuses
    {
        ATTACK,
        DEFENSE,
        SPEED,
        ZULIUMATTACK,
        ZULIUMDEFENSE,
        ZULIUMHEAL
    }

    public enum SecondStatBonuses
    {
        ATTACK,
        DEFENSE,
        SPEED,
        ZULIUMATTACK,
        ZULIUMDEFENSE,
        ZULIUMHEAL
    }

    public enum BonusStatBonuses
    {
        INTELLIGENCE,
        LUCK,
        RESIST,
        DODGE
    }*/
}



