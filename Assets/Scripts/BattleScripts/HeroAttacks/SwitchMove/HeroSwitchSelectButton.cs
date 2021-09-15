using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSwitchSelectButton : MonoBehaviour {

    public GameObject heroSwitchPrefab;

    public void SelectSwitchHero()
    {
        GameObject.Find("BattleManager").GetComponent<BattleStateMachine>().SwitchInputTwo(heroSwitchPrefab);
    }

    public void HideSelector()
    {
        heroSwitchPrefab.transform.Find("Selector").gameObject.SetActive(false);
    }

    public void ShowSelector()
    {
        heroSwitchPrefab.transform.Find("Selector").gameObject.SetActive(true);
    }
}
