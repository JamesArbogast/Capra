[System.Serializable]

public class BaseZuliumHeal : BaseStat
{

    public BaseZuliumHeal()
    {
        StatName = "Zulium Heal";
        StatDescription = "The base amount of hit points a character can heal before weapon/armour modifications.";
        StatType = StatTypes.ZULIUMHEAL;
        StatBaseValue = 0;
        StatModifiedValue = 0;
    }
}
