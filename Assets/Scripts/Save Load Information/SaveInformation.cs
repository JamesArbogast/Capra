using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveInformation {

    public static void SaveAllInformation()
    {
        PlayerPrefs.SetInt("CHARACTERLEVEL", GameInformation.CharacterLevel);
        PlayerPrefs.SetString("CHARACTERNAME", GameInformation.CharacterName);
        PlayerPrefs.SetInt("CHARACTERATTACK", GameInformation.PhysAttack);
        PlayerPrefs.SetInt("CHARACTERDEFENSE", GameInformation.PhysDefense);
        PlayerPrefs.SetInt("CHARACTERDODGE", GameInformation.Dodge);
        PlayerPrefs.SetInt("CHARACTERRESIST", GameInformation.Resist);
        PlayerPrefs.SetInt("CHARACTERZULIUM", GameInformation.ZuliumAttack);
        PlayerPrefs.SetInt("CHARACTERSPEED", GameInformation.Speed);
        PlayerPrefs.SetInt("CHARACTERENERGY", GameInformation.Energy);
        PlayerPrefs.SetInt("CHARACTERAGILITY", GameInformation.Luck);
        PlayerPrefs.SetInt("CHARACTERQUOL", GameInformation.Quol);

        /*if (GameInformation.Equipment1 != null)
        {
            PPSerialization.Save("EQUIPMENTITEM1", GameInformation.Equipment1);
        }*/

    }



}
