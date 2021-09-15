[System.Serializable]

public class BaseEnergy : BaseStat
{

    public BaseEnergy()
    {
        StatName = "Energy";
        StatDescription = "The base number of moves that a character gets before having to spend a move doing a rest turn before weapon/armour modifications.";
        StatType = StatTypes.ENERGY;
        StatBaseValue = 0;
        StatModifiedValue = 0;
    }
}
