using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaeliBaseStats : BaseCharacterStatAddition {


    public string characterClassName;
    public string characterClassDescription;
    private BaseCharacterStatAddition newCharacter;
    private BaseWarriorClass characterRaceStatAdditions;

    // Use this for initialization
	void Start () 
    {
        newCharacter = new BaseCharacterStatAddition();
        characterRaceStatAdditions = new BaseWarriorClass();
        newCharacter.BaseCharacterFullStats();

    }

    public ChaeliBaseStats()
    {
        characterClassName = "Chaeli";
        characterClassDescription = "Chaeli is the the princess of the Huidain Kingdom, she is an Aegan";
        baseCharacterHP = newCharacter.baseCharacterHP;
    }
}
