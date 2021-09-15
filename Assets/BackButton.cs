using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{

    public BattleStateMachine battleStateMachine;
    public bool inputThree;
    public bool inputFour;
    public bool inputFive;
    public bool inputSix;
    public bool inputSeven;
    public bool inputNine;
    public bool inputTwelve;
    public bool inputThirteen;

    // Start is called before the first frame update
    void Start()
    {
        battleStateMachine = GameObject.Find("BattleManager").GetComponent<BattleStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        if (battleStateMachine.uiState == BattleStateMachine.UIState.ZULIUMATKSELECT)
        {
            inputThree = true;
        }
        else if (battleStateMachine.uiState == BattleStateMachine.UIState.MELEEATKSELECT)
        {
            inputSix = true;
        }
        else if (battleStateMachine.uiState == BattleStateMachine.UIState.SKILLSATKSELECT)
        {
            inputSeven = true;
        }
        else if (battleStateMachine.uiState == BattleStateMachine.UIState.HEALSELECT)
        {
            inputTwelve = true;
        }
        else if (battleStateMachine.uiState == BattleStateMachine.UIState.ZULIUMENEMYSELECT)
        {
            inputFour = true;
        }
        else if (battleStateMachine.uiState == BattleStateMachine.UIState.MELEEENEMYSELECT)
        {
            inputFive = true;
        }
        else if (battleStateMachine.uiState == BattleStateMachine.UIState.SKILLSTARGETSELECT)
        {
            inputNine = true;
        }
        else if (battleStateMachine.uiState == BattleStateMachine.UIState.HEALTARGETSELECT)
        {
            inputThirteen = true;
        }





    }

    public void BackButtonClick()
    {
        if(inputThree == true)
        {
            battleStateMachine.StartingUI();
            ButtonReset();
        }

        if(inputSix == true)
        {
            battleStateMachine.StartingUI();
            ButtonReset();
        }

        if (inputSeven == true)
        {
            battleStateMachine.StartingUI();
            ButtonReset();
        }

        if (inputTwelve == true)
        {
            battleStateMachine.StartingUI();
            ButtonReset();
        }

        if (inputFour == true)
        {
            battleStateMachine.InputThree();
            ButtonReset();
        }

        if (inputFive == true)
        {
            battleStateMachine.InputSix();
            ButtonReset();
        }

        if (inputNine == true)
        {
            battleStateMachine.InputSeven();
            ButtonReset();
        }

        if (inputThirteen == true)
        {
            battleStateMachine.InputTwelve();
            ButtonReset();
        }
    }

    public void ButtonReset()
    {
    inputThree = false;
    inputFour = false;
    inputFive = false;
    inputSix = false;
    inputSeven = false;
    inputNine = false;
    inputTwelve = false;
    inputThirteen = false;
    }
}
