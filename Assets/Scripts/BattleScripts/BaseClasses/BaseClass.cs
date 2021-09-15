using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClass
{
    
    [Header("TYPE")]
    public bool isHero;
    public bool isEnemy;
    [Header("CHARACTER INFO")]
    public string theName;
    public int currentLevel;
    [Header("STATS")]
    public float baseHP;
    public float currentHP;
    //zulium points (mana) during battle
    public float baseZP;
    public float currentZP;
    public int baseEnergy;
    public int currentEnergy;
    //battle stats
    public float speed;
    public int physAttack;
    public int physDefense;
    public int dodge;
    public int zuliumAttack;
    public int zuliumDefense;
    public int zuliumHeal;
    public int resist;
    public int energy;
    public int luck;
    public int intelligence;
    //attack and defense during battle
    public float baseATK;
    public float currentATK;
    public float baseDEF;
    public float currentDEF;
    [Header("SKILL SPECIFIC INFO")]
    //for skills that involve a skill gauge
    public bool skillGuageIsNeeded;
    //for absorb skill
    public float absorbCurrentAmount;
    public float absorbMaxAmount;
    //for absorb skill
    public float currentAbsorbTime;
    public float maxAbsorbTime;
    //money
    [Header("MONEY AMOUNT")]
    public int currentQuol;

    //for sorting the characters in their party
    public int teamOrderNumber;
    public bool isFirstInTurnQueue;
}
