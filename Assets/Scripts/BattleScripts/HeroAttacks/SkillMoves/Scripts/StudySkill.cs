using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudySkill : BaseAttack
{

    public StudySkill()
    {
        attackName = "Study";
        attackType = "Skill";
        attackDescription = "Piyryl takes two turns";
        attackDamage = 0f;
        attackCost = 0;
        skillType = SkillType.EnemyTeamChoosePassive;
        skillEffectTurns = 3;
    }

}
