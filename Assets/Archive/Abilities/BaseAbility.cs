using System.Collections.Generic;
[System.Serializable]

public class BaseAbility {

    private string abilityName;
    private string abilityDescription;
    private int abilityID;
    private int abilityAttack;
    private int abilityCost;
    private int abilityCritChance;
    private BaseStatusEffect abilityStatusEffect; //allows each ability to have one status effect
    private List <BaseStatusEffect> abilityStatusEffects = new List<BaseStatusEffect>(); //allows each ability to have multiple status effects
    private float abilityCritModifier;

    public string AbilityName
    {
        get { return abilityName; }
        set { abilityName = value; }
    }

    public string AbilityDescription
    {
        get { return abilityDescription; }
        set { abilityDescription = value; }
    }

    public int AbilityID
    {
        get { return abilityID; }
        set { abilityID = value; }
    }

    public int AbilityCritChance
    {
        get { return abilityCritChance; }
        set { abilityCritChance = value; }
    }

    public int AbilityAttack
    {
        get { return abilityAttack; }
        set { abilityAttack = value; }
    }

    public int AbilityCost
    {
        get { return abilityCost; }
        set { abilityCost = value; }
    }

    public float AbilityCritModifier
    {
        get { return abilityCritModifier; }
        set { abilityCritModifier = value; }
    }

    public List<BaseStatusEffect> AbilityStatusEffects
    {
        get { return abilityStatusEffects; }
        set { abilityStatusEffects = value; }
    }
    public BaseStatusEffect AbilityStatusEffect
    {
        get { return abilityStatusEffect; }
        set { abilityStatusEffect = value; }
    }
}
