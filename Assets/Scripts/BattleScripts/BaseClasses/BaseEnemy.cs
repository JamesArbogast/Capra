using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class BaseEnemy : BaseClass
{
    //enemy type
    public enum Type
    {
        HUMAN,
        CAPRAN,
        FERAL,
        IBEXIAN
    }
    //enemy rarity
    public enum Rarity
    {
        COMMON,
        UNCOMMON,
        RARE,
        SUPERRARE
    }

    public Type enemyType;
    public Rarity rarity;

    public List<BaseAttack> zuliumAttacks = new List<BaseAttack>();
    public List<BaseAttack> meleeAttacks = new List<BaseAttack>();
    public List<BaseAttack> skillAttacks = new List<BaseAttack>();
    public List<BaseAttack> allAttacks = new List<BaseAttack>();
}
