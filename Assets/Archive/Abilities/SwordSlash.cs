[System.Serializable]

public class SwordSlash : BaseAbility {

	public SwordSlash()
    {
        AbilityName = "Sword Slash";
        AbilityDescription = "Physical attack with a sword equipped.";
        AbilityID = 2;
        AbilityAttack = 12;
        AbilityCost = 7;
        AbilityStatusEffects.Add(new ZuliumBurnEffect());
        AbilityStatusEffect = new ZuliumBurnEffect();
        AbilityCritChance = 85;
        AbilityCritModifier = 1.2f; //using as percentage
    }
}
