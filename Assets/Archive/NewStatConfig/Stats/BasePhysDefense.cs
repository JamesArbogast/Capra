[System.Serializable]

public class BasePhysDefense: BaseStat
{

    public BasePhysDefense()
    {
        StatName = "Physical Defense";
        StatDescription = "Determines the amount of damage nullified from a physical attack before move and armor modifications.";
        StatType = StatTypes.PHYSDEFENSE;
        StatBaseValue = 0;
        StatModifiedValue = 0;
    }
}
