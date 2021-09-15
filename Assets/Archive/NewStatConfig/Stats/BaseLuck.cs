[System.Serializable]

public class BaseLuck : BaseStat
{

    public BaseLuck()
    {
        StatName = "Luck";
        StatDescription = "The percentage chance of hitting a critical hit while attacking before weapon/armour modifiers. .";
        StatType = StatTypes.LUCK;
        StatBaseValue = 0;
        StatModifiedValue = 0;
    }
}