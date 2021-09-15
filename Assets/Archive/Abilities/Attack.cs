[System.Serializable]

public class Attack : BaseAbility {

	public Attack()
    {
        AbilityName = "Normal Attack";
        AbilityDescription = "Physically attacking an enemy without a weapon.";
        AbilityID = 1;
        AbilityAttack = 10;
        AbilityCost = 5;
        AbilityCritChance = 5;
    }
}
