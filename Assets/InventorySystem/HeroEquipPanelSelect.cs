using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroEquipPanelSelect : MonoBehaviour {

    public GameObject heroPrefab;

    public void SelectEnemy()
    {
        GameObject.Find("BattleManager").GetComponent<BattleStateMachine>().InputTwo(heroPrefab); //save input of enemy prefab
    }

}
