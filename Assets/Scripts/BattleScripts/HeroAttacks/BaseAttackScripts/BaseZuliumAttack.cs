[System.Serializable]

public class BaseZuliumAttack : BaseStat
{

    public BaseZuliumAttack()
    {
        StatName = "Zulium Attack";
        StatDescription = "Determines the base damage of a Zulium attack before move and weaopn modifiers.";
        StatType = StatTypes.ZULIUMATTACK;
        StatBaseValue = 0;
        StatModifiedValue = 0;
    }
}
