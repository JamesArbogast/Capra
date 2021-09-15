[System.Serializable]

public class BaseIntelligence : BaseStat
{

    public BaseIntelligence()
    {
        StatName = "Intelligence";
        StatDescription = "The base percentage chance that a character has of learning a learn-able move from another character before weapon/armour modifications.";
        StatType = StatTypes.INTELLIGENCE;
        StatBaseValue = 0;
        StatModifiedValue = 0;
    }
}
