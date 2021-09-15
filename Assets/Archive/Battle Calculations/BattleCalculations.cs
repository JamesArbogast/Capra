using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCalculations {

    private StatCalculations statCalcScript = new StatCalculations();

    private BaseAbility playerUsedAbility;
    private BaseAbility enemyUsedAbility;

    private int abilityPower;
    private float totalAbilityPowerDamage;
    private int totalUsedAbilityDamage;
    private int statusEffectDamage;
    private float totalPlayerDamage;
    private int totalCritStrikeDamage;

    private float damageVarianceMododifier = .025f; //5%

    public void CalculateTotalPlayerDamage(BaseAbility usedAbility)
    {
        playerUsedAbility = usedAbility;
        totalUsedAbilityDamage = (int)(CalculateAbilityDamage(usedAbility));
        totalCritStrikeDamage = CalculateCriticalStrikeDamage();
        statusEffectDamage = CalculateStatusEffectDamage();
        totalPlayerDamage = totalUsedAbilityDamage + totalCritStrikeDamage + statusEffectDamage;
        Debug.Log("Total critical strike damange: " + totalCritStrikeDamage);
        totalPlayerDamage += (int)(Random.Range(-(totalPlayerDamage * damageVarianceMododifier), totalPlayerDamage * damageVarianceMododifier));
        Debug.Log("Total player damage: " + totalPlayerDamage);
        TurnBasedCombatStateMachine.playerDidCompleteTurn = true;
        //TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ENEMYCHOICE;
    }

    public void CalculateTotalEnemyDamage(BaseAbility usedAbility)
    {
        enemyUsedAbility = usedAbility;
        totalUsedAbilityDamage = (int)(CalculateAbilityDamage(usedAbility));
        totalCritStrikeDamage = CalculateCriticalStrikeDamage();
        statusEffectDamage = CalculateStatusEffectDamage();
        totalPlayerDamage = totalUsedAbilityDamage + totalCritStrikeDamage + statusEffectDamage;
        Debug.Log("Total critical strike damange: " + totalCritStrikeDamage);
        totalPlayerDamage += (int)(Random.Range(-(totalPlayerDamage * damageVarianceMododifier), totalPlayerDamage * damageVarianceMododifier));
        Debug.Log("Total player damage: " + totalPlayerDamage);
        TurnBasedCombatStateMachine.enemyDidCompleteTurn = true;
        //TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ENEMYCHOICE;
    }

    private float CalculateAbilityDamage(BaseAbility UsedAbility)
    {
        abilityPower = UsedAbility.AbilityAttack; //retrieve power of move
        totalAbilityPowerDamage = abilityPower; //find main stat and use as modifier for damage
        return totalAbilityPowerDamage;
    }

    private int CalculateStatusEffectDamage()
    {
        Debug.Log("SDmg: " + statusEffectDamage);
        return statusEffectDamage = TurnBasedCombatStateMachine.statusEffectDamage * GameInformation.CharacterLevel;
    }

    private int CalculateCriticalStrikeDamage()
    {
        if (DecideIfAbilityCriticallyHits())
        {
            totalCritStrikeDamage = 0;
            return totalCritStrikeDamage = (int)(playerUsedAbility.AbilityCritModifier * totalAbilityPowerDamage);
        }
        
        return totalCritStrikeDamage = 0;
        
    
    }

    private bool DecideIfAbilityCriticallyHits()
    {
        int randomTemp = Random.Range(1, 101);
        if (randomTemp <= playerUsedAbility.AbilityCritChance)
        {
            Debug.Log("Critically Hit");
            return true; //we did critically hit
        }
        return false; //we did not critically hit
    }
}
