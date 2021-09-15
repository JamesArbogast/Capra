using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiteAbility : BaseAttack {

    public BiteAbility()
    {
        attackName = "Bite";
        attackDescription = "Damage: 10. Has a 5% chance of causing bleeding.";
        attackDamage = 10f;
        attackCost = 1;
        attackType = "Melee";
    }
}
