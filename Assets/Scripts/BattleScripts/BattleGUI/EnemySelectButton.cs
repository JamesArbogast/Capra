using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelectButton : MonoBehaviour {

    public GameObject enemyPrefab;

    public void SelectEnemy()
    {
        GameObject.Find("BattleManager").GetComponent<BattleStateMachine>().InputTwo(enemyPrefab); //save input of enemy prefab
    }

    public void HideSelector()
    {
        enemyPrefab.transform.Find("EnemySelector").gameObject.SetActive(false);
    }

    public void ShowSelector()
    {
        enemyPrefab.transform.Find("EnemySelector").gameObject.SetActive(true);
    }
}
