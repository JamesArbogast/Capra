using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateNewCharacter : MonoBehaviour {

    private BaseCharacter newCharacter;
    private bool isWarriorClass;
    private bool isZulgymistClass;
    private string characterName = "Enter Name";

    // Use this for initialization
    void Start () 
    {
        newCharacter = new BaseCharacter();
    }
    
    // Update is called once per frame
    void Update () {
        
    }

     void OnGUI()
    {
        characterName = GUILayout.TextArea(characterName);
        isWarriorClass = GUILayout.Toggle(isWarriorClass, "Capran Class");
        isZulgymistClass = GUILayout.Toggle(isZulgymistClass, "Zulgymist Class");
        if (GUILayout.Button("Create"))
        {
            if (isWarriorClass)
            {
                newCharacter.CharacterClass = new BaseWarriorClass();
            }
            else if (isZulgymistClass)
            {
                newCharacter.CharacterClass = new BaseZulgymistClass();
            }
            CreateNewPlayer();
            StoreCharacterInfo();
            SaveInformation.SaveAllInformation();
        }

        if(GUILayout.Button("Load"))
        {
            SceneManager.LoadScene("TestingTurnBased");
        }
       
    }

    

    public void StoreCharacterInfo() 
    {
        GameInformation.CharacterName = newCharacter.CharacterName;
        GameInformation.CharacterLevel = newCharacter.CharacterLevel;
        GameInformation.PhysAttack = newCharacter.PhysAttack;
        GameInformation.PhysDefense = newCharacter.PhysDefense;
        GameInformation.Dodge = newCharacter.Dodge;
        GameInformation.Energy = newCharacter.Energy;
        GameInformation.Resist = newCharacter.Resist;
        GameInformation.Speed = newCharacter.Speed;
        GameInformation.ZuliumAttack = newCharacter.ZuliumAttack;
        GameInformation.Luck = newCharacter.Speed;
        GameInformation.Quol = newCharacter.Quol;
    }

    private void CreateNewPlayer()
    {
        newCharacter.CharacterLevel = 1;
        newCharacter.PhysAttack = newCharacter.CharacterClass.CharacterClassPhysAttack;
        newCharacter.PhysDefense = newCharacter.CharacterClass.CharacterClassPhysDefense;
        newCharacter.Dodge = newCharacter.CharacterClass.CharacterClassDodge;
        newCharacter.Energy = newCharacter.CharacterClass.CharacterClassEnergy;
        newCharacter.Resist = newCharacter.CharacterClass.CharacterClassResist;
        newCharacter.Speed = newCharacter.CharacterClass.CharacterClassSpeed;
        newCharacter.ZuliumAttack = newCharacter.CharacterClass.CharacterClassZuliumAttack;
        newCharacter.CharacterName = newCharacter.characterName;
        newCharacter.Quol = 1000;
        Debug.Log("Character Class: " + newCharacter.CharacterClass.CharacterClassName);
        Debug.Log("Character Level: " + newCharacter.CharacterLevel);
        Debug.Log("Character Name: " + newCharacter.CharacterName);
        Debug.Log("Character Attack: " + newCharacter.PhysAttack);
        Debug.Log("Character Defense: " + newCharacter.PhysDefense);
        Debug.Log("Character Dodge: " + newCharacter.Dodge);
        Debug.Log("Character Energy: " + newCharacter.Energy);
        Debug.Log("Character Speed: " + newCharacter.Speed);
        Debug.Log("Character Resist: " + newCharacter.Resist);
        Debug.Log("Character Zulium: " + newCharacter.ZuliumAttack);
    }
}
