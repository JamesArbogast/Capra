using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkAngrilySkill : BaseAttack
{
    // Start is called before the first frame update
    public TalkAngrilySkill()
    {
        attackName = "Talk Angrily";
        attackType = "Skill";
        attackDescription = "Lon talks angrily to his enemies to try to make them lower their guard.";
        attackDamage = 0f;
        attackCost = 0;
        skillType = SkillType.EnemyFullTeamPassive;
        skillEffectTurns = 0;
    }
}
