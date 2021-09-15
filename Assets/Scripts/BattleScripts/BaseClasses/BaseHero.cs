using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseHero : BaseClass
{

    [Header("EXPERIENCE")]
    public float currentXP;
    public float requiredXP;

    [Header("ATTACKS")]
    public List<BaseAttack> zuliumAttacks = new List<BaseAttack>();
    public List<BaseAttack> meleeAttacks = new List<BaseAttack>();
    public List<BaseAttack> skillAttacks = new List<BaseAttack>();
    public List<BaseAttack> healMoves = new List<BaseAttack>();
    public List<BaseAttack> allAttacks = new List<BaseAttack>();
    public List<BaseAttack> switchMove = new List<BaseAttack>();
    public List<GameObject> skillEffects = new List<GameObject>();

}
