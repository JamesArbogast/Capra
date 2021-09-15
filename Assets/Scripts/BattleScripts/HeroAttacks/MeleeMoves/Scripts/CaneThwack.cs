using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaneThwack : BaseAttack {

    public CaneThwack()
    {
        attackName = "Cane Thwack";
        attackDescription = "Damage: 20. Takes two turns to use. has a 30% chance of suprising the enemy and causing shock.";
        attackDamage = 20f;
        attackCost = 2;
        attackType = "Melee";
        critHitChance = 10;
        critHitDmg = 30f;
    }
}
