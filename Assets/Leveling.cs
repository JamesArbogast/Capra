using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Leveling : MonoBehaviour
{

    public int currentLvl;
    public int currentXP;
    public int requiredXP;

    public BaseHero heroState;

    public enum Levels
    {
        ONE,
        TWO,
        THREE,
        FOUR,
        FIVE
    }

    public Levels leveling = Levels.ONE;


    // Start is called before the first frame update
    void Start()
    {
        heroState = GameObject.Find("TeamManager").GetComponent<TeamManagement>().HeroTeam[0].GetComponent<HeroStateMachine>().hero;
    }

    // Update is called once per frame
    void Update()
    {
        switch(leveling)
        {
            case (Levels.ONE):

                if(heroState.currentLevel == 1)
                {
                    heroState.currentLevel = 1;
                    //heroState.requiredXP = 105;
                }

                if(heroState.currentXP >= heroState.requiredXP)
                {
                    leveling = Levels.TWO;
                    heroState.currentXP = 0;
                }

                break;

            case (Levels.TWO):
                heroState.currentLevel = 2;
                if (heroState.currentXP >= heroState.requiredXP)
                {
                    leveling = Levels.TWO;
                    heroState.currentXP = 0;
                }
                break;
                
            case (Levels.THREE):
                heroState.currentLevel = 3;
                if (heroState.currentXP >= heroState.requiredXP)
                {
                    leveling = Levels.THREE;
                    heroState.currentXP = 0;
                }
                break;
            case (Levels.FOUR):
                heroState.currentLevel = 4;
                if (heroState.currentXP >= heroState.requiredXP)
                {
                    leveling = Levels.FOUR;
                    heroState.currentXP = 0;
                }
                break;
            case (Levels.FIVE):
                heroState.currentLevel = 5;
                if (heroState.currentXP >= heroState.requiredXP)
                {
                    leveling = Levels.FIVE;
                    heroState.currentXP = 0;
                }
                break;
        }

        if(heroState.currentXP >= heroState.requiredXP)
        {
            heroState.currentLevel++;
        }
    }
}
