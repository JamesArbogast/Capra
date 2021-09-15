using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSelectPanel : MonoBehaviour
{

    public GameObject heroPrefab;

    public void SelectHero()
    {
        GameObject.Find("BattleManager").GetComponent<BattleStateMachine>().InputTwo(heroPrefab); //save input of enemy prefab
    }

    public void HideSelector()
    {
        heroPrefab.transform.Find("HeroSelector").gameObject.SetActive(false);
    }

    public void ShowSelector()
    {
        heroPrefab.transform.Find("HeroSelector").gameObject.SetActive(true);
    }
}
