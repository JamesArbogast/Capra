using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearThrowEffect : MonoBehaviour {

    private BattleStateMachine battleStateMachine;
    public bool spearThrown;
    public bool retrieveInitiated;
    public float spearThrowDamageBoost;
    public float spearThrowPercentage;
    public HeroStateMachine heroLon;
    public float luck;
    public int withSpearAttack;
    public int withoutSpearAttack;

    // Use this for initialization
    void Start () {

        battleStateMachine = GameObject.Find("BattleManager").GetComponent<BattleStateMachine>();
        heroLon = GameObject.Find("Lon").GetComponent<HeroStateMachine>();
        withSpearAttack = heroLon.hero.physAttack;
        withoutSpearAttack = 1;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(battleStateMachine.heroChoice.chooseAttack.attackName == "Spear Throw")
        {
            spearThrown = true;
        }

        if (spearThrown == true)
        {
            heroLon.hero.physAttack = withoutSpearAttack;
        }
        else if(spearThrown == false)
        {
            heroLon.hero.physAttack = withSpearAttack;
        }

    }
}
