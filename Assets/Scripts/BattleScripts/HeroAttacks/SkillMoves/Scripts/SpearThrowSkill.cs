using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearThrowSkill : BaseAttack {

    public bool spearThrowLive;
    public float spearThrowDamageBoost;
    public float spearThrowPercentage;
    public HeroStateMachine heroLon;
    public float luck;
    public bool spearThrown;
    public float withSpearAttack;

    // Use this for initialization
	void Start () {

        luck = Random.Range(1, heroLon.hero.luck);
        attackName = "Spear Throw";
        attackDescription = "Lon balances the risk of doing large amounts of damage and doing no damage. This skill also makes it so that Lon needs to subsequently retrieve their spear.";
        attackDamage = 0f;
        attackCost = 1;
        attackType = "Skill";
        critHitDmg = 150f;
        critHitChance = 10;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
