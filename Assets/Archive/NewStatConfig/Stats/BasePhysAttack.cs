[System.Serializable]

public class BasePhysAttack : BaseStat
{

    public BasePhysAttack()
    {
        StatName = "Physical Attack";
        StatDescription = "Determines the base damage for physical attack before move and weapon modifications.";
        StatType = StatTypes.PHYSATTACK;
        StatBaseValue = 0;
        StatModifiedValue = 0;
    }
}