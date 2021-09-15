using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//can be used for allocating stats after a player levels up
//can also be used for automatically allocating stats after player levels up

public class StatAllocationModule {

    //names of stats
    private string[] statNames = new string[8] { "Speed", "Attack", "Defense", "Dodge", "Zulium", "Resist", "Energy", "Agility" };
    //explains what stats do
    private string[] statDescriptions = new string[8] { "Turn timing modifier", "Physical Damage Modifier", "Damage Resistance Modifier", "Avoidance Percentage", "Non-physical damage", "Death Avoidance Percentage", "Endurance Modifier", "Haste and Crit Modifier" }; 
    //control our toggle switches with the for loop
    private bool[] statSelections = new bool[8];


    public int[] pointsToAllocate = new int[8]; //starting stat values for the chosen class modifications
    private int[] baseStatPoints = new int[8]; //starting stat values for the chosen class

    private int availablePoints = 5; //amount of stat points available at start
    public bool didRunOnce = false; //

    public void DisplayStatAllocationModule()
    {
        if (!didRunOnce)
        {
            RetrieveBaseStatPoints();
            didRunOnce = true;
        }
            DisplayStatToggleSwitches();
            DisplayStatIncreaseDecreaseButtons();

    }

    private void DisplayStatToggleSwitches()
    {
        //increments another GUI button for each stat
        for (int i = 0; i < statNames.Length; i++) 
        {
            //displays toggle buttons for stat selections and names
            statSelections[i] = GUI.Toggle(new Rect(10, 60 * i + 10, 100, 50), statSelections[i], statNames[i]);
            //displays base stats
            GUI.Label(new Rect(100, 60 * i + 10, 50, 50), pointsToAllocate[i].ToString());
            //displays stat description when stat is selected in toggle
            if(statSelections[i])
            {
                GUI.Label(new Rect(20, 60 * i + 30, 150, 100), statDescriptions[i]);
            }
        }
    }

   
    //creating plus and minus buttons that will appear and disappear depending on available points
    private void DisplayStatIncreaseDecreaseButtons()
    {
        for (int i = 0; i < pointsToAllocate.Length; i++)
        {
            if (pointsToAllocate[i] >= baseStatPoints[i] && availablePoints > 0)
            {
                if (GUI.Button(new Rect(200, 60 * i + 10, 50, 50), "+"))
                {
                    pointsToAllocate[i] += 1;
                    --availablePoints;
                }
            }

            if (pointsToAllocate[i] > baseStatPoints[i])
            {
                if (GUI.Button(new Rect(260, 60 * i + 10, 50, 50), "-"))
                {
                    pointsToAllocate[i] -= 1;
                    ++availablePoints;
                }
            }
        }
    }

    private void RetrieveBaseStatPoints()
    {
        BaseCharacterClass cClass = new BaseZulgymistClass(); //GameInformation.CharacterClass; NEED TO FIGURE OUT WHAT IS WRONG WITH THIS
       /* pointsToAllocate[0] = cClass.Speed;
        baseStatPoints[0] = cClass.Speed;
        pointsToAllocate[1] = cClass.Attack;
        baseStatPoints[1] = cClass.Attack;
        pointsToAllocate[2] = cClass.Defense;
        baseStatPoints[2] = cClass.Defense;
        pointsToAllocate[3] = cClass.Dodge;
        baseStatPoints[3] = cClass.Dodge;
        pointsToAllocate[4] = cClass.Zulium;
        baseStatPoints[4] = cClass.Zulium;
        pointsToAllocate[5] = cClass.Resist;
        baseStatPoints[5] = cClass.Resist;
        pointsToAllocate[6] = cClass.Energy;
        baseStatPoints[6] = cClass.Energy;
        pointsToAllocate[7] = cClass.Agility;
        baseStatPoints[7] = cClass.Agility;*/
    }
}
