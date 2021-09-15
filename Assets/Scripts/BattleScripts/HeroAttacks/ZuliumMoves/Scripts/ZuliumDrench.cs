using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZuliumDrench : BaseAttack
{


    //this attack is essentially a poisoning attack
    public ZuliumDrench()
    {
        attackName = "Zulium Drench";
        attackDescription = "A sudden release of Zulium which can often cause the target to feel long term pain.";
        attackDamage = 5f;
        attackCost = 30f;
        attackType = "Zulium";
        attackEffect = true;
        attackEffectType = "Zulium Poison";
    }
}
