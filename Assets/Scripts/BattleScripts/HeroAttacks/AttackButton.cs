using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour {

    public BaseAttack zuliumAttackToPerform;
    public BaseAttack meleeAttackToPerform;
    public BaseAttack skillAttackToPerform;
    public BaseAttack healMoveToPerform;
    public GameObject heroToSwitch;

    public void CastZuliumAttack()
    {
        GameObject.Find("BattleManager").GetComponent<BattleStateMachine>().InputFour(zuliumAttackToPerform);
    }

    public void CastMeleeAttack()
    {
        GameObject.Find("BattleManager").GetComponent<BattleStateMachine>().InputFive(meleeAttackToPerform);
    }

    public void CastSkillAttack()
    {
        GameObject.Find("BattleManager").GetComponent<BattleStateMachine>().InputNine(skillAttackToPerform);
    }

    public void CastHealMove()
    {
        GameObject.Find("BattleManager").GetComponent<BattleStateMachine>().InputThirteen(healMoveToPerform);
    }

    public void CompleteSwitch()
    {
        GameObject.Find("BattleManager").GetComponent<BattleStateMachine>().SwitchInputTwo(heroToSwitch);
    }
}
