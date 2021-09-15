using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IncreaseExperience
{

    private static int xpToGive;
    private static LevelUp levelUpScript = new LevelUp();

    public static void AddExperience()
    {
        xpToGive = GameInformation.CharacterLevel * 100;
        GameInformation.CurrentXP += xpToGive;
        CheckToSeeIfPlayerLeveled();
        Debug.Log(xpToGive);
    }

    private static void CheckToSeeIfPlayerLeveled()
    {
        if(GameInformation.CurrentXP >= GameInformation.RequiredXP)
        {
            //the player has leveled up
            levelUpScript.LevelUpCharacter();
            //create level up script
        }
    }


}
