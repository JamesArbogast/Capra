[System.Serializable]

public class BaseSpeed : BaseStat {

    public BaseSpeed()
    {
        StatName = "Speed";
        StatDescription = "Determines the order in which a player moves amongst all contestants.";
        StatType = StatTypes.SPEED;
        StatBaseValue = 0;
        StatModifiedValue = 0;
    }
}
