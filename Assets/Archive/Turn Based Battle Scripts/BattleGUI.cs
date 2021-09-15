using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleGUI : MonoBehaviour {


    private BattleStateStart battleStatStartScript = new BattleStateStart();
    private Text playerName;
    private Text playerHealth;
    private Image playerHealthImage;
    private Text abilityOneName;
    private Image playerHealthBarImage;
    //private string playerName;
    private int playerLevel;
    //private int playerHealth;
    private int playerEnergy;
    public GUI playerAbilityOneButton;
    public GameObject attackAnimation;

    // Use this for initialization
    void Start ()
    {
        
        playerName = transform.Find("PlayerInfoContainer").Find("PlayerNameDisplay").GetComponent<Text>();
        playerName.text = GameInformation.CharacterName;
        playerHealth = transform.Find("PlayerInfoContainer").Find("PlayerHealthBar").Find("PlayerHealthValue").GetComponent<Text>();
        playerLevel = GameInformation.CharacterLevel;

        playerHealthBarImage = transform.Find("PlayerInfoContainer").Find("PlayerHealthBar").GetComponent<Image>();

        abilityOneName = transform.Find("AttackContainer").Find("HeadBashAttackButton").GetComponent<Text>();
        abilityOneName.text = GameInformation.playerMoveTwo.AbilityName;


        Debug.Log(GameInformation.playerMoveTwo.AbilityStatusEffect.StatusEffectName);

	}
	
	// Update is called once per frame
	void Update () {
        playerName.text = GameInformation.CharacterName;
        playerHealth.text = "HP: " + GameInformation.PlayerHealth.ToString() + "/50";
        playerHealthBarImage.fillAmount = (GameInformation.PlayerHealth / 50);
    }

    void OnGUI()
    {
        if (TurnBasedCombatStateMachine.currentState == TurnBasedCombatStateMachine.BattleStates.PLAYERCHOICE)
        {
            //DisplayPlayersChoice();
        }

        //use this for loop to display several abilities
        //this creates an action type bar
        /*for (int i = 0; i < GameInformation.playersAbilities.Count; i++)
        {
            if (GUI.Button(new Rect(0,0,0,0), GameInformation.playersAbilities[i].AbilityName))
            {

            }
    }*/
        //buttons for players move
        //show enemy health and other enemy information
        //we need to show player information

    }

    public void AbilityOne()
    {
        TurnBasedCombatStateMachine.playerUsedAbility = GameInformation.playerMoveTwo;
        TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ADDSTATUSEFFECTS;
        Instantiate(attackAnimation,transform.position, transform.rotation);
    }

    /*private void DisplayPlayersChoice()
    {
        if (GUI.Button(new Rect(Screen.width - 250, Screen.height - 50, 100, 30), GameInformation.playerMoveOne.AbilityName))
        {
            //calculate player damage to enemy
            TurnBasedCombatStateMachine.playerUsedAbility = GameInformation.playerMoveOne;
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ADDSTATUSEFFECTS;

        }

        if (GUI.Button(new Rect(Screen.width - 150, Screen.height - 50, 100, 30), GameInformation.playerMoveTwo.AbilityName))
        {
            //calculate player damage to enemy
            TurnBasedCombatStateMachine.playerUsedAbility = GameInformation.playerMoveTwo;
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ADDSTATUSEFFECTS;
        }
    }*/

    public void FindAbilityOneInfo()
    {
        abilityOneName = transform.Find("AttackContainer").Find("HeadBashAttackButton").Find("Text").GetComponent<Text>();
        abilityOneName.text = GameInformation.playerMoveTwo.AbilityName;
    }

   
}
