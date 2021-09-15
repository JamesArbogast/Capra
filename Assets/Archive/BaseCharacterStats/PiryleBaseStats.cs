using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PiryleBaseStats : BaseCharacterClass {

    private BaseCharacter newCharacter;

    // Use this for initialization
    void Start () 
    {
        newCharacter = new BaseCharacter();
    }

    public PiryleBaseStats()
    {
        CharacterClassName = "Juni";
        CharacterClassDescription = "Juni is the the princess of the Huidain Kingdom, she is an Aegan";
        
    }
}
