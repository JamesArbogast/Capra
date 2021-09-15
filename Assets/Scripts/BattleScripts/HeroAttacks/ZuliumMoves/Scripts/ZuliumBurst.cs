using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this attack is the most basic Zulium offensive attack
public class ZuliumBurst : BaseAttack {

	public ZuliumBurst()
    {
        attackName = "Zulium Burst";
        attackDescription = "A very rudimentary method for using Zulium in battle, which involves closing it in a dissolving skin and turning it into a grenade.";
        attackDamage = 20f;
        attackCost = 40f;
        attackType = "Zulium";
        critHitChance = 10;
        critHitDmg = 20;
    }
}
