using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseStats : MonoBehaviour {

    public string enemyName = "Red Slime";
    public int enemyLevel = 1;
    public int enemyHealthPoints = 50;
    public int enemyZuliumPoints = 25;
    public int enemySpeed = 25; //order of battle
    public int enemyPhysAttack = 25; //physical damage base
    public int enemyPhysDefense = 25; //damage reduction
    public int enemyDodge = 25; //ability to avoid attacks
    public int enemyZuliumAttack = 25; //capacity for using Zulium (magic) bar
    public int enemyZuliumDefense = 25; // defense against Zulium related attacks
    public int enemyZuliumHeal = 25; //ability to heal using Zulium moves
    public int enemyResist = 25; //percentage chance of surviving lethal hit
    public int enemyEnergy = 25; //health modifier
    public int enemyIntelligence = 25;
    public int enemyLuck = 25; // hit percentage modifier
    public Sprite characterSprite;

    // Use this for initialization
    void Start () {
		
	}
	

}
