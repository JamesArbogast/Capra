using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateEnemyChoice {

    private EnemyAbilityChoice enemyAbilityChoiceScript = new EnemyAbilityChoice();
    

	public void EnemyCompleteTurn()
    {
        //choose an ability
        TurnBasedCombatStateMachine.enemyUsedAbility = enemyAbilityChoiceScript.ChooseEnemyAbility();
        Debug.Log("Enemy Choice " + TurnBasedCombatStateMachine.enemyUsedAbility.AbilityName);
        //calculate damage
        TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.CALCDAMAGE;
        //end turn
    }
}
