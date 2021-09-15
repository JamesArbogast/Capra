using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateStart {

    public BaseCharacter newEnemy = new BaseCharacter();
    private StatCalculations statCalculations = new StatCalculations();
    private BaseCharacterClass[] classTypes = new BaseCharacterClass[] { new BaseZulgymistClass(), new BaseWarriorClass() };

    private int playerStamina;
    private int playerEndurance;
    private int playerHealth;
    private int playerEnergy;

    public void PrepareBattle()
    {
        //create enemy
        CreateNewEnemy();
        DeterminePlayerVitals();
        ChooseWhoGoesFirst();
        //does the scene have a status effect? If it does go ahead and aplly that effect
        //choose who goes first based on speed

    }


    //creating an enemy stats
    private void CreateNewEnemy()
    {
        newEnemy.CharacterName = "Feral";
        newEnemy.CharacterLevel = Random.Range(GameInformation.CharacterLevel - 2, GameInformation.CharacterLevel + 2);
        newEnemy.CharacterClass = classTypes [Random.Range(0, classTypes.Length)];
        newEnemy.Energy = statCalculations.CalculateStat(newEnemy.Energy, StatCalculations.StatType.ENERGY, newEnemy.CharacterLevel, true);
        newEnemy.Energy = statCalculations.CalculateStat(newEnemy.Energy, StatCalculations.StatType.RESIST, newEnemy.CharacterLevel, true);
        newEnemy.Energy = statCalculations.CalculateStat(newEnemy.Energy, StatCalculations.StatType.PHYSATTACK, newEnemy.CharacterLevel, true);
        newEnemy.Energy = statCalculations.CalculateStat(newEnemy.Energy, StatCalculations.StatType.LUCK, newEnemy.CharacterLevel, true);
        newEnemy.Energy = statCalculations.CalculateStat(newEnemy.Energy, StatCalculations.StatType.DODGE, newEnemy.CharacterLevel, true);
        newEnemy.Energy = statCalculations.CalculateStat(newEnemy.Energy, StatCalculations.StatType.INTELLIGENCE, newEnemy.CharacterLevel, true);
        newEnemy.Energy = statCalculations.CalculateStat(newEnemy.Energy, StatCalculations.StatType.LUCK, newEnemy.CharacterLevel, true);


    }

    //choosing who goes first in a battle
    private void ChooseWhoGoesFirst()
    {
        if (GameInformation.Speed > newEnemy.Speed)
        {
            //player goes first
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.PLAYERCHOICE;
        }
        if (GameInformation.Speed < newEnemy.Speed)
        {
            //enemy is going to go first
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ENEMYCHOICE;
        }
        if (GameInformation.Speed == newEnemy.Speed)
        {
            //player goes first
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.PLAYERCHOICE;
        }


            
    }


    //calculating the player health and energy for the on screen battle gui
    public void DeterminePlayerVitals()
    {
        GameInformation.CharacterName = "Capra";
        GameInformation.CharacterClass = new BaseZulgymistClass();
        GameInformation.PhysAttack = GameInformation.CharacterClass.CharacterClassPhysAttack;
        GameInformation.HealthPoints = GameInformation.CharacterClass.CharacterClassHP;
        playerStamina = statCalculations.CalculateStat(GameInformation.Energy, StatCalculations.StatType.ENERGY, GameInformation.CharacterLevel, false);
        playerEndurance = statCalculations.CalculateStat(GameInformation.Resist, StatCalculations.StatType.RESIST, GameInformation.CharacterLevel, false);
        playerHealth = statCalculations.CalculateHealth(playerStamina);
        playerEnergy = statCalculations.CalculateHealth(playerEndurance);
        GameInformation.PlayerHealth = playerHealth;
        GameInformation.PlayerEnergy = playerEnergy;
        GameInformation.CharacterLevel = 1;

    }
}
