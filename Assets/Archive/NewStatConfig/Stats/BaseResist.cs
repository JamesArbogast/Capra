[System.Serializable]

public class BaseResist : BaseStat
{

    public BaseResist()
    {
        StatName = "Resist";
        StatDescription = "The percentage chance that the character avoids a deathblow attack before weapon/armour modifications.";
        StatType = StatTypes.RESIST;
        StatBaseValue = 0;
        StatModifiedValue = 0;
    }
}
