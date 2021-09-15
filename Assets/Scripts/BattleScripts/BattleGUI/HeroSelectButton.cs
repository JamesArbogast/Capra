using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSelectButton : MonoBehaviour {

    public GameObject heroPrefab;

    public void SelectHero()
    {
        GameObject.Find("BattleManager").GetComponent<BattleStateMachine>().InputThirteen(heroPrefab); //save input of enemy prefab
    }

    public void HideSelector()
    {
        heroPrefab.transform.Find("Selector").gameObject.SetActive(false);
    }

    public void ShowSelector()
    {
        heroPrefab.transform.Find("Selector").gameObject.SetActive(true);
    }
}
