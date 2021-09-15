using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public int currentLevel = 1;

    public int currentExp;

    public int[] toLevelUp;
    public int[] hpLevels;
    public int[] attackLevels;
    public int[] defenseLevels;

    public int currentHP;
    public int currentAttack;
    public int currentDefense;

    private PlayerHealthManager thePlayerHealth;

	// Use this for initialization
	void Start () 
    {
        currentHP = hpLevels[1];
        currentAttack = attackLevels[1];
        currentDefense = defenseLevels[1];
        currentLevel = 1;

        thePlayerHealth = FindObjectOfType<PlayerHealthManager>();
	}
	
	// Update is called once per frame
	void Update () 
    {
		if (currentExp >= toLevelUp[currentLevel])
        {
            //currentLevel++;
            levelUp();
        }
	}

    public void AddExperience (int experienceToAdd)
    {
        currentExp += experienceToAdd;
    }

    public void levelUp()
    {
        currentLevel++;
        currentHP = hpLevels[currentLevel];
        currentAttack = attackLevels[currentLevel];
        currentDefense = defenseLevels[currentLevel];

        thePlayerHealth.playerMaxHealth = currentHP;
        thePlayerHealth.playerCurrentHealth += currentHP - hpLevels[currentLevel - 1];
    }
}
