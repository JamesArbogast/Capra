using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp {

    public int maxPlayerLevel = 50;

    public void LevelUpCharacter()
    {
        //check to see if current XP > required XP
        if (GameInformation.CurrentXP > GameInformation.RequiredXP)
        {
            GameInformation.CurrentXP -= GameInformation.RequiredXP;
        } else {
            GameInformation.CurrentXP = 0;
        }
        if (GameInformation.CharacterLevel < maxPlayerLevel)
        {
            GameInformation.CharacterLevel += 1;
        } else {
            GameInformation.CharacterLevel = maxPlayerLevel;
        }

        //give player stat points
        //give player items
        //learn new move
        //give money
        //determine the next amount of required XP
        DetermineRequiredXP();
    }

    private void DetermineRequiredXP()
    {
        int temp = (GameInformation.CharacterLevel * 1000) + 250;
        GameInformation.RequiredXP = temp;
    }

   /* private void DetermineMoneyToGive()
    {
        if (GameInformation.CharacterLevel < 10)
            
    }*/
}
