using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeSkill : BaseAttack
{
    public DodgeSkill()
    {
        attackName = "Dodge";
        attackType = "Skill";
        attackDescription = "Does no damage. Chaowe enters a dodge mode, where when attacked they are given a quicktime event. For every successful dodge the opponent gains frustration.";
        attackDamage = 0f;
        attackCost = 0;
        skillType = SkillType.SelfActive;
        skillEffectTurns = 3;
    }


}
