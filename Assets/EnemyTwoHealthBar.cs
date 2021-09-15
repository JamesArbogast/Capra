using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTwoHealthBar : MonoBehaviour
{
    public EnemyStateMachine enemyTwoStats;

    public Slider enemyTwoHealthSlider;
    public Slider enemyTwoDisarmSlider;

    // Start is called before the first frame update
    void Start()
    {
        enemyTwoStats = GameObject.Find("Enemy2").GetComponent<EnemyStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyTwoHealthSlider.maxValue = enemyTwoStats.enemy.baseHP;
        enemyTwoHealthSlider.value = enemyTwoStats.enemy.currentHP;

        enemyTwoDisarmSlider.maxValue = enemyTwoStats.enemy.baseHP;
        enemyTwoDisarmSlider.value = enemyTwoStats.disarmEndPoint;
    }
}
