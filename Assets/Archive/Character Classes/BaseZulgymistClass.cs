using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseZulgymistClass : BaseCharacterClass {

    public BaseZulgymistClass()
    {
        CharacterClassName = "Zulium Expert";
        CharacterClassDescription = "Intelligent scientists that are battle capable. They use their knowledge of the Zulium element to battle and manipulate battle. They can only be equipped zulium and armor items.";
        playersAbilities.Add(new Attack());
        playersAbilities.Add(new SwordSlash());
    }
}
