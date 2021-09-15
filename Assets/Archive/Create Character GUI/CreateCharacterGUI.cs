using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCharacterGUI : MonoBehaviour {


    public enum CreateACharacterStates
    {
        CLASSSELECTION, //DISPLAY ALL CLASS TYPES
        STATALLOCATION, //allocate stats where the player wants to
        FINALSETUP //add name and misc items
    }

    public static CreateACharacterStates currentState;
    //private DisplayCreateCharacterFuntions displayFunctions = new DisplayCreateCharacterFuntions();
   

	// Use this for initialization
	void Start () {
        currentState = CreateACharacterStates.CLASSSELECTION;
	}
	
	// Update is called once per frame
	void Update () {
		switch(currentState)
        {
            case(CreateACharacterStates.CLASSSELECTION) :
                break;
            case (CreateACharacterStates.STATALLOCATION):
                break;
            case (CreateACharacterStates.FINALSETUP):
                break;
        }
	}

    /* void OnGUI()
    {
        displayFunctions.DisplayMainItems();
        if(currentState == CreateACharacterStates.CLASSSELECTION)
        {
            //display class selection function
            displayFunctions.DisplayClassSelections();
        }
        if (currentState == CreateACharacterStates.STATALLOCATION)
        {
            //display stat allocation function
            displayFunctions.DisplayStatAllocation();
        }
        if (currentState == CreateACharacterStates.FINALSETUP)
        {
            //display final setup function
            displayFunctions.DisplayFinalSetup();
        }
    }*/
}
