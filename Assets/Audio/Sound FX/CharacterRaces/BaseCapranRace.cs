using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCapranRace : BaseCharacterRaces
{

    public BaseCapranRace()
    {
        new BaseCharacterRaces();
        RaceName = "Capran";
        RaceDescription = "Is a Capran.";
        characterRaceHP = 60;
        characterRaceZP = 50;
        characterRaceSpeed = 57;
        characterRacePhysAttack = 58;
        characterRacePhysDefense = 50;
        characterRaceDodge = 54;
        characterRaceZuliumAttack = 51;
        characterRaceZuliumDefense = 58;
        characterRaceZuliumHeal = 51;
        characterRaceResist = 54;
        characterRaceEnergy = 50;
        characterRaceLuck = 50;
        characterRaceIntelligence = 53;

    }
}
