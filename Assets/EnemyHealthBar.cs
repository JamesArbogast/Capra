using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public EnemyStateMachine enemyOneStats;

    public Slider enemyOneHealthSlider;
    public Slider enemyOneDisarmSlider;

    // Start is called before the first frame update
    void Start()
    {
        enemyOneStats = GameObject.Find("Enemy1").GetComponent<EnemyStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyOneHealthSlider.maxValue = enemyOneStats.enemy.baseHP;
        enemyOneHealthSlider.value = enemyOneStats.enemy.currentHP;

        enemyOneDisarmSlider.maxValue = enemyOneStats.enemy.baseHP;
        enemyOneDisarmSlider.value = enemyOneStats.disarmEndPoint;
    }
}
