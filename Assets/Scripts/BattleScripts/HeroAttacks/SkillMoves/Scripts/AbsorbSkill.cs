using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbSkill : BaseAttack {

    public AbsorbSkill()
    {
        attackName = "Absorb";
        attackDescription = "Puts Chaeli in a defense position. Defense is raised substantially, speed is lowered substatially zulium is absorbed through taking attacks.";
        attackDamage = 0f;
        attackCost = 3;
        attackType = "Skill";
        skillType = SkillType.HeroIndividualChoicePassiveNotPlayer;
        skillEffectTurns = 2;
    }

   
}
