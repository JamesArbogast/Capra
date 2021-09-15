[System.Serializable]

public class BaseDodge : BaseStat
{

    public BaseDodge()
    {
        StatName = "Dodge";
        StatDescription = "The percentage chance that the character avoids an attack before move and armor/weapon modfications.";
        StatType = StatTypes.DODGE;
        StatBaseValue = 0;
        StatModifiedValue = 0;
    }
}
