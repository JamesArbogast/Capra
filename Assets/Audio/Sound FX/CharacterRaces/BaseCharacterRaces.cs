using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//Initializing character race bonuses

public class BaseCharacterRaces {


    //basic stat variables for the races of characters
    
    public int characterRaceHP = 50;
    public int characterRaceZP = 10;
    public int characterRaceSpeed = 10;
    public int characterRacePhysAttack = 10;
    public int characterRacePhysDefense = 5;
    public int characterRaceDodge = 2;
    public int characterRaceZuliumAttack = 10;
    public int characterRaceZuliumDefense = 5;
    public int characterRaceZuliumHeal = 15;
    public int characterRaceResist = 5;
    public int characterRaceEnergy = 2;
    public int characterRaceLuck = 40;
    public int characterRaceIntelligence = 2;

    public string raceName = "Needs a Name";
    public string raceDescription = "Needs a Description";

    public enum CharacterRaces
    {
        AEGAN,
        HUMAN,
        CAPRAN,
        IBEXIAN,
        FERAL,
        HIRU,
        ZYER,
    }

    public string RaceName
    {
        get { return raceName; }
        set { raceName = value; }
    }
    public string RaceDescription
    {
        get { return raceDescription; }
        set { raceDescription = value; }
    }
    public int CharacterRaceHP 
    {
        get { return characterRaceHP; }
        set { characterRaceHP = value; }
    }
    public int CharacterRaceZP
    {
        get { return characterRaceZP; }
        set { characterRaceZP = value; }
    }
    public int CharacterRaceSpeed
    {
        get { return characterRaceSpeed; }
        set { characterRaceSpeed = value; }
    }
    public int CharacterRacePhysAttack
    {
        get { return characterRacePhysAttack; }
        set { characterRacePhysAttack = value; }
    }
    public int CharacterRacePhysDefense
    {
        get { return characterRacePhysDefense; }
        set { characterRacePhysDefense = value; }
    }
    public int CharacterRaceDodge
    {
        get { return characterRaceDodge; }
        set { characterRaceDodge = value; }
    }
    public int CharacterRaceZuliumAttack
    {
        get { return characterRaceZuliumAttack; }
        set { characterRaceZuliumAttack = value; }
    }
    public int CharacterRaceZuliumDefense
    {
        get { return characterRaceZuliumDefense; }
        set { characterRaceZuliumDefense = value; }
    }
    public int CharacterRaceZuliumHeal
    {
        get { return characterRaceZuliumHeal; }
        set { characterRaceZuliumHeal = value; }
    }
    public int CharacterRaceResist
    {
        get { return characterRaceResist; }
        set { characterRaceResist = value; }
    }
    public int CharacterRaceEnergy
    {
        get { return characterRaceEnergy; }
        set { characterRaceEnergy = value; }
    }
    public int CharacterRaceLuck
    {
        get { return characterRaceLuck; }
        set { characterRaceLuck = value; }
    }
    public int CharacterRaceIntelligence
    {
        get { return characterRaceIntelligence; }
        set { characterRaceIntelligence = value; }
    }

}

