using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearStab : BaseAttack {

    public SpearStab()
    {
        attackName = "Spear Stab";
        attackDescription = "Damage: 10. May cause bleed";
        attackDamage = 10f;
        attackCost = 1;
        attackType = "Melee";
        critHitChance = 5;
        critHitDmg = 20f;
    }
}
