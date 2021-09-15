using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this attack is the most basic Zulium offensive attack
public class ZuliumSpearZap : BaseAttack {

	public ZuliumSpearZap()
    {
        attackName = "Zulium Spear Zap";
        attackDescription = "A light zulium attack administered from the other end of the spear. Increases the chance of disarming the opponent.";
        attackDamage = 5f;
        attackCost = 10f;
        attackType = "Zulium";
        critHitChance = 10;
        critHitDmg = 10;
    }
}
