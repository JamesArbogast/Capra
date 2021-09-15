using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaeliBaseCharacter : MonoBehaviour {

    public string characterName = "Chaeli";
    public int characterLevel = 1;
    public int healthPoints = 50;
    public int zuliumPoints = 25;
    public int speed = 25; //order of battle
    public int physAttack = 25; //physical damage base
    public int physDefense = 25; //damage reduction
    public int dodge = 25; //ability to avoid attacks
    public int zuliumAttack = 25; //capacity for using Zulium (magic) bar
    public int zuliumDefense = 25; // defense against Zulium related attacks
    public int zuliumHeal = 25; //ability to heal using Zulium moves
    public int resist = 25; //percentage chance of surviving lethal hit
    public int energy = 25; //health modifier
    public int intelligence = 25;
    public int luck = 25; // hit percentage modifier
    public Sprite characterSprite;

    public int quol = 100; //in game currency

    public int currentXP;
    public int requiredXP;


    void Start()
    {
       
    }
    
}
