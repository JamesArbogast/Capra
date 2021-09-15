using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWarriorClass : BaseCharacterClass {

    public BaseCharacterClass baseCharacterClassScript = new BaseCharacterClass();

	public BaseWarriorClass()
    {
        baseCharacterClassScript.CharacterClassName = "Capran";
        baseCharacterClassScript.CharacterClassDescription = "Strong and durable warriors. They use horns and shields to battle. They cannot be equipped with other types of weapons, only armor, shields, zulium items, and special items.";
        baseCharacterClassScript.characterClassHP += 1;
        baseCharacterClassScript.characterClassZP = 2;
        baseCharacterClassScript.characterClassSpeed = 1;
        baseCharacterClassScript.characterClassPhysAttack = 0;
        baseCharacterClassScript.characterClassPhysDefense = 0;
        baseCharacterClassScript.characterClassDodge = 0;
        baseCharacterClassScript.characterClassZuliumAttack = 2;
        baseCharacterClassScript.characterClassZuliumDefense = 2;
        baseCharacterClassScript.characterClassZuliumHeal = 0;
        baseCharacterClassScript.characterClassResist = 1;
        baseCharacterClassScript.characterClassEnergy = 0;
        baseCharacterClassScript.characterClassLuck = 0;
        baseCharacterClassScript.characterClassIntelligence = 0;

        Debug.Log(baseCharacterClassScript.characterClassHP);
    }

}
