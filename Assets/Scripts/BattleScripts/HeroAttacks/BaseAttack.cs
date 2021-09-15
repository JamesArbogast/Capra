using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class BaseAttack : MonoBehaviour
{
    public string attackName; //name of attack
    public string attackDescription; //description of attack
    public float attackDamage; //base damage before player modifiers  //base damage 15, melee level 10 stamina 35 = base damage + stamina + level = 60
    public float healAmount; //base heal before player modifiers
    public float attackCost; //if zulium, depletes zulium, if physical depletes energy
    public string attackType; //can either be type Zulium, Melee, Special, or Heal
    public bool attackEffect; //whether or not an attack has some type of an effect
    public string attackEffectType; //the type of attack effect
    public float defenseIncrease; //does the attack increase defense
    public int skillEffectTurns; //the amount of turns that the effect enacts for
    public int critHitChance; //the number that effects the chance of landing a crit hit with this attack
    public float critHitDmg; //the amount added when a crit hit succeeds
    public SkillType skillType;

    public enum SkillType
    {
        SelfPassive,
        HeroFullTeamPassive,
        HeroTeamIndividualPassive,
        HeroIndividualChoicePassiveNotPlayer,
        EnemyFullTeamPassive,
        EnemyTeamChoosePassive,
        EnemyTeamInvidualPassive,
        SelfActive,
        HeroFullTeamActive,
        HeroTeamIndividualActive,
        EnemyFullTeamActive,
        EnemyTeamChooseActive,
        EnemyTeamInvidualActive,
    }

}
