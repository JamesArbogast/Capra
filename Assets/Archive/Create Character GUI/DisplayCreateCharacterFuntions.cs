using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class DisplayCreateCharacterFuntions : MonoBehaviour
{


    public StatAllocationModule statAllocationModule = new StatAllocationModule();
    private int classSelection;
    private string[] classSelectionNames = new string[] { "Capran Warrior", "Support Zulgymist", "Ibexian Warrior", "Aegan Warrior", "Aegan Zulgymist", "Capran Zulgymist", "Capran Shielder", "Human Gunman" };
    private string characterFirstName = "Enter First Name"; //first name of character
    private string characterLastName = "Enter Last Name"; //last name of character 
    private string characterBio = "Enter Player Bio"; //bio of character
   
    public void DisplayClassSelections()
    {
        //list of toggle buttons, each button will be a different class
        //selection grid
        classSelection = GUI.SelectionGrid(new Rect(50, 50, 250, 300), classSelection, classSelectionNames, 2);
        GUI.Label(new Rect(450, 50, 300, 300), FindClassDescription(classSelection));
        GUI.Label(new Rect(450, 120, 300, 300), FindClassStatValues(classSelection));

    }

    private string FindClassDescription(int classSelection)
    {
        if (classSelection == 0)
        {
            BaseCharacterClass tempClass = new BaseCapranClass();
            return tempClass.CharacterClassDescription;
        }
        else if (classSelection == 1)
        {
            BaseCharacterClass tempClass = new BaseZulgymistClass();
            return tempClass.CharacterClassDescription;
        }
        return "NO CLASS FOUND";
    }

    private string FindClassStatValues(int classSelection)
    {
        if (classSelection == 0)
        {
            BaseCharacterClass tempClass = new BaseCapranClass();
            string tempStats = "Attack " + tempClass.Attack + "\n" + "Defense " + tempClass.Defense + "\n" + "Speed " + tempClass.Speed + "\n" + "Dodge " + tempClass.Dodge;
            return tempStats;
        }
        else if (classSelection == 1)
        {
            BaseCharacterClass tempClass = new BaseZulgymistClass();
            string tempStats = "Attack " + tempClass.Attack + "\n" + "Defense " + tempClass.Defense + "\n" + "Speed " + tempClass.Speed + "\n" + "Dodge " + tempClass.Dodge;
            return tempStats;
        }
        return "NO STATS FOUND";
    }

    public void DisplayStatAllocation()
    {
        //a list of stats with plus and minus buttons
        //logic to make sure the player cannot add more stats than those given
        statAllocationModule.DisplayStatAllocationModule();
        GUI.Label(new Rect(450, 50, 300, 300), FindClassDescription(classSelection));
        GUI.Label(new Rect(450, 100, 300, 300), FindClassStatValues(classSelection));
    }

    public void DisplayFinalSetup()
    {
        //name
        characterFirstName = GUI.TextArea(new Rect (20,10,150,25), characterFirstName, 25);
        characterLastName = GUI.TextArea(new Rect(20, 55, 150, 25), characterLastName, 25);
        //add description
        characterBio = GUI.TextArea(new Rect(20, 100, 250, 200), characterBio, 250);

    } 

    private void ChooseClass(int classSelection)
    {
        if (classSelection == 0)
        {
            GameInformation.CharacterClass = new BaseCapranClass().ToString();
        }
        else if (classSelection == 1)
        {
            GameInformation.CharacterClass = new BaseZulgymistClass().ToString();
        }
    }

    public void DisplayMainItems()
    {
        //next button logic
        GUI.Label(new Rect(Screen.width / 2, 20, 250, 250), "CREATE NEW PLAYER");
        if (CreateCharacterGUI.currentState != CreateCharacterGUI.CreateACharacterStates.FINALSETUP) //if we are not in the final setup then show a next button
        {
            if (GUI.Button(new Rect(525, 370, 50, 50), "Next"))
            {
                if (CreateCharacterGUI.currentState == CreateCharacterGUI.CreateACharacterStates.CLASSSELECTION)
                {
                    ChooseClass(classSelection);
                    CreateCharacterGUI.currentState = CreateCharacterGUI.CreateACharacterStates.STATALLOCATION;
                }
                else if (CreateCharacterGUI.currentState == CreateCharacterGUI.CreateACharacterStates.STATALLOCATION) //if 
                {
                    //saving allocated stats as base stats
                    //private string[] statNames = new string[8] { "Speed", "Attack", "Defense", "Dodge", "Zulium", "Resist", "Energy", "Agility" };
                    GameInformation.Speed = statAllocationModule.pointsToAllocate[0];
                    GameInformation.Attack = statAllocationModule.pointsToAllocate[1];
                    GameInformation.Defense = statAllocationModule.pointsToAllocate[2];
                    GameInformation.Dodge = statAllocationModule.pointsToAllocate[3];
                    GameInformation.Zulium = statAllocationModule.pointsToAllocate[4];
                    GameInformation.Resist = statAllocationModule.pointsToAllocate[5];
                    GameInformation.Energy = statAllocationModule.pointsToAllocate[6];
                    GameInformation.Agility = statAllocationModule.pointsToAllocate[7];

                    CreateCharacterGUI.currentState = CreateCharacterGUI.CreateACharacterStates.FINALSETUP;
                }
            }
        } else if (CreateCharacterGUI.currentState == CreateCharacterGUI.CreateACharacterStates.FINALSETUP)
          {
            if(GUI.Button(new Rect(525, 370, 50, 50), "Finish"))
                {
                //final save
                GameInformation.CharacterName = characterFirstName + " " + characterFirstName;
                GameInformation.CharacterBio = characterBio;
                SaveInformation.SaveAllInformation();
                    Debug.Log("Make final save.");
                }
            }


        //back button logic
        if (CreateCharacterGUI.currentState != CreateCharacterGUI.CreateACharacterStates.CLASSSELECTION)
        {
            if (GUI.Button(new Rect(295, 370, 50, 50), "Back"))
            {
                if (CreateCharacterGUI.currentState == CreateCharacterGUI.CreateACharacterStates.STATALLOCATION)
                {
                    statAllocationModule.didRunOnce = false;
                    Debug.Log(GameInformation.CharacterName);
                    GameInformation.CharacterClass = null;
                    CreateCharacterGUI.currentState = CreateCharacterGUI.CreateACharacterStates.CLASSSELECTION;
                }
                else if (CreateCharacterGUI.currentState == CreateCharacterGUI.CreateACharacterStates.FINALSETUP)
                {
                    CreateCharacterGUI.currentState = CreateCharacterGUI.CreateACharacterStates.STATALLOCATION;
                }
            }
        }
    }
}*/
