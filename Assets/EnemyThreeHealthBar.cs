using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyThreeHealthBar : MonoBehaviour
{

    public EnemyStateMachine enemyThreeStats;

    public Slider enemyThreeHealthSlider;
    public Slider enemyThreeDisarmSlider;

    // Start is called before the first frame update
    void Start()
    {
        enemyThreeStats = GameObject.Find("Enemy3").GetComponent<EnemyStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyThreeHealthSlider.maxValue = enemyThreeStats.enemy.baseHP;
        enemyThreeHealthSlider.value = enemyThreeStats.enemy.currentHP;

        enemyThreeDisarmSlider.maxValue = enemyThreeStats.enemy.baseHP;
        enemyThreeDisarmSlider.value = enemyThreeStats.disarmEndPoint;
    }
}
