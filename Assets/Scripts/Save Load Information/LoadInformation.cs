using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadInformation {

    public static void LoadAllInformation()
    {
        GameInformation.CharacterName = PlayerPrefs.GetString("CHARACTERNAME");
        GameInformation.CharacterLevel = PlayerPrefs.GetInt("CHARACTERLEVEL");
        GameInformation.PhysAttack = PlayerPrefs.GetInt("CHARACTERATTACK");
        GameInformation.PhysDefense = PlayerPrefs.GetInt("CHARACTERDEFENSE");
        GameInformation.Dodge = PlayerPrefs.GetInt("CHARACTERDODGE");
        GameInformation.Resist = PlayerPrefs.GetInt("CHARACTERRESIST");
        GameInformation.ZuliumAttack = PlayerPrefs.GetInt("CHARACTERZULIUM");
        GameInformation.Speed = PlayerPrefs.GetInt("CHARACTERSPEED");
        GameInformation.Energy = PlayerPrefs.GetInt("CHARACTERENERGY");
        GameInformation.Luck = PlayerPrefs.GetInt("CHARACTERAGILITY");
        GameInformation.Quol = PlayerPrefs.GetInt("CHARACTERQUOL");

       /*if (PlayerPrefs.GetString("EQUIPMENTITEM1") != null)
        {
            GameInformation.Equipment1 = (BaseEquipment)PPSerialization.Load("EQUIPMENTITEM1");
        }*/

    }
	
}
