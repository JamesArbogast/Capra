using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkCalmlySkill : BaseAttack
{
    // Start is called before the first frame update
    public TalkCalmlySkill()
    {
        attackName = "Talk Calmly";
        attackType = "Skill";
        attackDescription = "Lon talks calmly to his enemies to try to make them lower their guard.";
        attackDamage = 0f;
        attackCost = 0;
        skillType = SkillType.EnemyFullTeamPassive;
        skillEffectTurns = 0;
    }
}
