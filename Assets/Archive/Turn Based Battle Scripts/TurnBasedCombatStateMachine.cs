using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedCombatStateMachine : MonoBehaviour {


    private bool hasAddedXP = false;
    private BattleStateStart battleStateStart = new BattleStateStart();
    private BattleCalculations battleCalcScript = new BattleCalculations();
    public static BaseAbility playerUsedAbility;
    public static BaseAbility enemyUsedAbility;
    public static int statusEffectDamage;
    private BattleStateAddStatusEffects battleStateAddStatusEffectsScript = new BattleStateAddStatusEffects();
    private BattleStateEnemyChoice battleStateEnemyChoiceScript = new BattleStateEnemyChoice();
    public static int totalTurnCount;
    public static bool playerDidCompleteTurn;
    public static bool enemyDidCompleteTurn;
    public static BattleStates currentUser;

    public enum BattleStates{
        START,
        PLAYERCHOICE,
        CALCDAMAGE,
        ADDSTATUSEFFECTS,
        ENEMYCHOICE,
        ENDTURN,
        LOSE,
        WIN
    }

    public static BattleStates currentState;

    // Use this for initialization
	void Start () {

        hasAddedXP = false;
        totalTurnCount = 1;
        currentState = BattleStates.START;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(currentState);
        switch (currentState) {
            case (BattleStates.START):
                //Setup battle funcation;
                //create enemy
                battleStateStart.PrepareBattle();
                //choose who goes first depending on luck
                break;
            case (BattleStates.PLAYERCHOICE): //player chooses the ability they want to use
                currentUser = BattleStates.PLAYERCHOICE;
                break;
            case (BattleStates.ENEMYCHOICE): //enemy ai chooses an ability
                //coded AI goes here
                currentUser = BattleStates.ENEMYCHOICE;
                battleStateEnemyChoiceScript.EnemyCompleteTurn();
                //enemyDidCompleteTurn = true;
                //CheckWhoGoesNext();
                break;
            case (BattleStates.CALCDAMAGE): //we calculate the damage done by the player, look for existing effects and add that damage
                if (currentUser == BattleStates.PLAYERCHOICE)
                {
                    battleCalcScript.CalculateTotalPlayerDamage(playerUsedAbility);
                }
                if (currentUser == BattleStates.ENEMYCHOICE)
                {
                    battleCalcScript.CalculateTotalPlayerDamage(enemyUsedAbility);
                }

                //Debug.Log("Calculating Damage");
                CheckWhoGoesNext();
                break;
            case (BattleStates.ADDSTATUSEFFECTS): //we add status effect if it exists
                battleStateAddStatusEffectsScript.CheckAbilityForStatusEffects(playerUsedAbility);
                break;
            case (BattleStates.ENDTURN):
                totalTurnCount += 1;
                playerDidCompleteTurn = false;
                enemyDidCompleteTurn = false;
                Debug.Log(totalTurnCount);
                break;
            case (BattleStates.LOSE):
                break;
            case (BattleStates.WIN):
                if (!hasAddedXP)
                {
                    IncreaseExperience.AddExperience();
                    hasAddedXP = true;
                }
                break;
        }
	}


    //button for testing the different battle states
    private void OnGUI()
    {
        if (GUILayout.Button("NEXT STATE"))
        {
            if (currentState == BattleStates.START)
            {
                currentState = BattleStates.PLAYERCHOICE;
            }
            else if (currentState == BattleStates.PLAYERCHOICE)
            {
                currentState = BattleStates.CALCDAMAGE;
            }
            else if (currentState == BattleStates.CALCDAMAGE)
            {
                currentState = BattleStates.ENEMYCHOICE;
            }
            else if (currentState == BattleStates.ENEMYCHOICE)
            {
                currentState = BattleStates.LOSE;
            }
            else if (currentState == BattleStates.LOSE)
            {
                currentState = BattleStates.WIN;
            }
            else if (currentState == BattleStates.WIN)
            {
                currentState = BattleStates.START;
            }
        
        }
    }

    private void CheckWhoGoesNext()
    {
        if (playerDidCompleteTurn && !enemyDidCompleteTurn)
        {
            //enemy turn
            currentState = BattleStates.ENEMYCHOICE;
        }
        if (!playerDidCompleteTurn && enemyDidCompleteTurn)
        {
            //player turn
            currentState = BattleStates.PLAYERCHOICE;
        }
        if (playerDidCompleteTurn && enemyDidCompleteTurn)
        {
            //end turn state
            currentState = BattleStates.ENDTURN;
        }
    }
}
