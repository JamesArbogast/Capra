using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatCalculations {

    private float enemyEnergyModifier = 0.25f; //25%
    private float enemyResistModifier = 0.25f; //25%
    private float enemyIntelligenceModifier = 0.20f; //20%
    private float playerIntelligenceModifier = 0.20f; //20%
    private float enemyAttackModifier = 0.20f; //20%
    private float enemyLuckModifier = 0.20f; //20%
    private float playerLuckModifier = 0.20f; //20%
    private float enemyDodgeModifier = 0.20f; //20%
    private float playerDodgeModifier = 0.20f; //20%
    private float playerEnergyModifier = 0.3f; //30%
    private float playerResistModifier = 0.3f; //30%
    private float playerPhysAttackModifier = 0.3f; //30%
    private float statModifier;
    public bool isEnemy;

    

    public enum StatType
    {
        HP,
        ZP,
        SPEED,
        PHYSATTACK,
        PHYSDEFENSE,
        DODGE,
        ZULIUMATTACK,
        ZULIUMDEFENSE,
        ZULIUMHEAL,
        RESIST,
        ENERGY,
        LUCK,
        INTELLIGENCE,
    }

    public int CalculateStat(int statVal, StatType statType, int level, bool v)
    {
        if (isEnemy)
        {
            SetEnemyModifier(statType);
            return (statVal + (int)((statVal * statModifier) + level));
        } else if (!isEnemy)
        {
            SetEnemyModifier(statType);
            return (statVal + (int)((statVal * statModifier) + level));
        }

        return 0;
    }

    private void SetEnemyModifier(StatType statType)
    {

        if (statType == StatType.ENERGY)
        {
            statModifier = enemyEnergyModifier;
        }
        if (statType == StatType.ENERGY)
        {
            statModifier = playerEnergyModifier;
        }
        if (statType == StatType.RESIST)
        {
            statModifier = enemyResistModifier;
        }
        if (statType == StatType.RESIST)
        {
            statModifier = playerResistModifier;
        }
        if (statType == StatType.INTELLIGENCE)
        {
            statModifier = enemyIntelligenceModifier;
        }
        if (statType == StatType.INTELLIGENCE)
        {
            statModifier = playerIntelligenceModifier;
        }
        if (statType == StatType.PHYSATTACK)
        {
            statModifier = playerPhysAttackModifier;
        }
        if (statType == StatType.PHYSATTACK)
        {
            statModifier = enemyAttackModifier;
        }
        if (statType == StatType.LUCK)
        {
            statModifier = playerLuckModifier;
        }
        if (statType == StatType.LUCK)
        {
            statModifier = enemyLuckModifier;
        }
        if (statType == StatType.DODGE)
        {
            statModifier = playerDodgeModifier;
        }
        if (statType == StatType.DODGE)
        {
            statModifier = enemyDodgeModifier;
        }
    }

    public int CalculateHealth(int statValue)
    {
        return statValue * 100; //so we are calculating helath based on total stamina stat times 100 
    }

    public int CalculateEnergy(int statValue)
    {
        return statValue * 50;
    }


   /* public float FindPlayerMainStatAndCalculateMainStatModifier()
    {
        if (GameInformation.CharacterClass == BaseCharacterClass)
        {
            //10 int at level 1
            return GameInformation.Attack * mainStatModifier;
        }

        return 1.0f;
    }*/
}
