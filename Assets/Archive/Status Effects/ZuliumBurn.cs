[System.Serializable]

public class ZuliumBurnEffect : BaseStatusEffect
{

    public ZuliumBurnEffect()
    {
        StatusEffectName = "Zulium Burn";
        StatusEffectDescription = "A zulium attack burns an enemy for a random number of turns.";
        StatusEffectID = 2;
        StatusEffectPower = 12;
        StatusEffectApplyPercentage = 20; //this effect has a 20% chance of being applied
        StatusEffectMinTurnApplied = 1;
        StatusEffectMinTurnApplied = 6;
        StatusEffectStayAppliedPercentage = 68; //this effect has a 68 percent change of staying applied

    }
}
