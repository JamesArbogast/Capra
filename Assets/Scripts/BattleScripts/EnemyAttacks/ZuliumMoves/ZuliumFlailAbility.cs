using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZuliumFlailAbility : BaseAttack {

    public ZuliumFlailAbility()
    {
        attackName = "Zulium Flail";
        attackDescription = "Damage: 30. Only has a 70% chance of hitting it's mark.";
        attackDamage = 30f;
        attackCost = 2;
    }
}
