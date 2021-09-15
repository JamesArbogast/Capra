using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPanelStats : MonoBehaviour
{
    public Text enemyOneText;
    public Text enemyTwoText;
    public Text enemyThreeText;

    public BattleStateMachine battleStateMachine;


    // Start is called before the first frame update
    void Start()
    {
        battleStateMachine = GameObject.Find("BattleManager").GetComponent<BattleStateMachine>();

        enemyOneText.text = battleStateMachine.EnemiesInBattle[0].GetComponent<EnemyStateMachine>().enemy.theName;
        enemyTwoText.text = battleStateMachine.EnemiesInBattle[1].GetComponent<EnemyStateMachine>().enemy.theName;
        enemyThreeText.text = battleStateMachine.EnemiesInBattle[2].GetComponent<EnemyStateMachine>().enemy.theName;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(battleStateMachine.EnemiesInBattle[0].GetComponent<EnemyStateMachine>().currentState == EnemyStateMachine.TurnState.DEAD)
        {
            enemyOneText.text = " ";
        }

        if (battleStateMachine.EnemiesInBattle[1].GetComponent<EnemyStateMachine>().currentState == EnemyStateMachine.TurnState.DEAD)
        {
            enemyTwoText.text = " ";
        }

        if (battleStateMachine.EnemiesInBattle[2].GetComponent<EnemyStateMachine>().currentState == EnemyStateMachine.TurnState.DEAD)
        {
            enemyThreeText.text = " ";
        }*/

    }

    public void UpdateEnemyStats()
    {
        enemyOneText.text = battleStateMachine.EnemiesInBattle[0].GetComponent<EnemyStateMachine>().enemy.theName;
        enemyTwoText.text = battleStateMachine.EnemiesInBattle[1].GetComponent<EnemyStateMachine>().enemy.theName;
        enemyThreeText.text = battleStateMachine.EnemiesInBattle[2].GetComponent<EnemyStateMachine>().enemy.theName;
    }
}
