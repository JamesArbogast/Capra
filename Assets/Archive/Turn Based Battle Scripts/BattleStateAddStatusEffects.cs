using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateAddStatusEffects {

	public void CheckAbilityForStatusEffects(BaseAbility usedAbility)
    {
        if (usedAbility.AbilityStatusEffect != null)
        {
            switch (usedAbility.AbilityStatusEffect.StatusEffectName)
            {
                case ("Zulium Burn"):
                    if(TryToApplyStatusEffect(usedAbility))
                    {
                        Debug.Log("Status effect applied effect.");
                        TurnBasedCombatStateMachine.statusEffectDamage = usedAbility.AbilityStatusEffect.StatusEffectPower;
                        Debug.Log(TurnBasedCombatStateMachine.statusEffectDamage);
                    } else
                    {
                        TurnBasedCombatStateMachine.statusEffectDamage = 0;
                    }
                    Debug.Log("Try to apply effect. Ability has " + usedAbility.AbilityStatusEffect.StatusEffectApplyPercentage + "% Chance");
                    TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.CALCDAMAGE;
                    break;
                default:
                    Debug.LogError("Error in status effect.");
                    break;
            }
        }   
    }
    private bool TryToApplyStatusEffect(BaseAbility usedAbility)
    {
        //look at percent chance of status effect paplying
        //using percent chance apply effect
        int randomTemp = Random.Range(1, 101); //random number between 1-100
        Debug.Log(randomTemp);
        if( randomTemp <= usedAbility.AbilityStatusEffect.StatusEffectApplyPercentage) //apply status effect
        {
            return true;
        }
        return false;
        
        
    }
}
