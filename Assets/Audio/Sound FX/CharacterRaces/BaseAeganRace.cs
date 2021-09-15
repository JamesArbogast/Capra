using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAeganRace : BaseCharacterStatAddition {

    public BaseCharacterStatAddition chracterStatAdditionScript;

    public int baseAeganHP;

    public BaseAeganRace()
    {

        
        raceName = "Aegan";
        raceDescription = "Is an Aegan.";
        baseAeganHP = characterRaceHP + 1;
        characterRaceZP = 60;
        characterRaceSpeed = 54;
        characterRacePhysAttack = 53;
        characterRacePhysDefense = 57;
        characterRaceDodge = 52;
        characterRaceZuliumAttack = 55;
        characterRaceZuliumDefense = 58;
        characterRaceZuliumHeal = 51;
        characterRaceResist = 54;
        characterRaceEnergy = 50;
        characterRaceLuck = 50;
        characterRaceIntelligence = 53;
    }
}