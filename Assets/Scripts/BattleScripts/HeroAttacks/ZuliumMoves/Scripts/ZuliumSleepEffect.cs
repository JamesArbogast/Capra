[System.Serializable]

public class ZuliumSleepEffect : BaseStatusEffect {

    public ZuliumSleepEffect()
    {
        StatusEffectName = "Zulium Sleep";
        StatusEffectDescription = "Puts an enemy to sleep for multiple turns.";
        StatusEffectID = 1;
        StatusEffectPower = 0;
        StatusEffectApplyPercentage = 25; //this effect has a 25% chance of being applied
        StatusEffectMinTurnApplied = 1;
        StatusEffectMinTurnApplied = 4;
        StatusEffectStayAppliedPercentage = 40; //this effect has a 40 percent change of staying applied

    }
}
