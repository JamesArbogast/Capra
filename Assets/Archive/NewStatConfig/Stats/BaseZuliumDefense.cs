[System.Serializable]

public class BaseZuliumDefense : BaseStat
{

    public BaseZuliumDefense()
    {
        StatName = "Zulium Defense";
        StatDescription = "Determines the amount of damage nullified from a Zulium attack before move and armor modifications.";
        StatType = StatTypes.ZULIUMDEFENSE;
        StatBaseValue = 0;
        StatModifiedValue = 0;
    }
}
