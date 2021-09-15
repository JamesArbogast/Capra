using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZuliumHeal : BaseAttack {

    public ZuliumHeal()
    {
        attackName = "Small Zulium Heal";
        attackDescription = "Healing: 20";
        healAmount = 20f;
        attackCost = 15f;
        attackType = "Heal";
    }
}
