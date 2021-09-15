using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkSkill : BaseAttack
{

    public TalkSkill()
    {
        attackName = "Talk";
        attackType = "Skill";
        attackDescription = "Does no damage. Lon tries disarming his enemies by talking to them. This will either result in their disarm numbers going up or their attack increasing.";
        attackDamage = 0f;
        attackCost = 0;
        skillType = SkillType.EnemyFullTeamPassive;
        skillEffectTurns = 0;
    }

}
