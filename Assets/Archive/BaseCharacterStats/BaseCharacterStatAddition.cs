using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterStatAddition : MonoBehaviour {

    public string raceName;
    public string raceDescription;
    public int baseCharacterHP;
    public int baseCharacterZP;
    public int baseCharacterSpeed;
    public int baseCharacterPhysAttack;
    public int baseCharacterPhysDefense;
    public int baseCharacterDodge;
    public int baseCharacterZuliumAttack;
    public int baseCharacterZuliumDefense;
    public int baseCharacterZuliumHeal;
    public int baseCharacterResist;
    public int baseCharacterEnergy;
    public int baseCharacterLuck;
    public int baseCharacterIntelligence;

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


    public void BaseCharacterFullStats()
    {
        baseCharacterHP = characterClassHP + characterRaceHP;
        baseCharacterZP = characterClassZP + characterRaceZP;
        baseCharacterSpeed = characterClassSpeed + characterRaceSpeed;
        baseCharacterPhysAttack = characterClassPhysAttack + characterRacePhysAttack;
        baseCharacterPhysDefense = characterClassPhysDefense + characterRacePhysDefense;
        baseCharacterDodge = characterClassDodge + characterRaceDodge;
        baseCharacterZuliumAttack = characterClassZuliumAttack + characterRaceZuliumAttack;
        baseCharacterZuliumDefense = characterClassZuliumDefense + characterRaceZuliumDefense;
        baseCharacterZuliumHeal = characterClassZuliumHeal + characterRaceZuliumHeal;
        baseCharacterResist = characterClassResist + characterRaceResist;
        baseCharacterEnergy = characterClassEnergy + characterRaceEnergy;
        baseCharacterLuck = characterClassLuck + characterRaceLuck;
        baseCharacterIntelligence = characterClassIntelligence + characterRaceIntelligence;

}

   
}


