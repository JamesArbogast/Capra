using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class ExpGainScreen : MonoBehaviour {

    //exp bar vars
    public float expBarSpeed = 1;


    public BattleStateMachine battleState;
    public HeroStateMachine chaeliHeroState;
    public HeroStateMachine lonHeroState;
    public HeroStateMachine piyrylHeroState;
    public HeroStateMachine alxHeroState;
    public HeroStateMachine choawHeroState;
    public HeroStateMachine tzeyHeroState;
    public PartyManager partyManager;

    public GameObject chaeli;

    public float chaeliExp;
    public float piyrylExp;
    public float lonExp;
    public float alxExp;
    public float tzeyExp;
    public float choawExp;
    public float newExp;
    public Slider characterOneXpSlider;
    public Slider characterTwoXpSlider;
    public Slider characterThreeXpSlider;
    public Slider characterFourXpSlider;
    public Slider characterFiveXpSlider;
    public Slider characterSixXpSlider;
    public Text characterOneName;
    public Text characterTwoName;
    public Text characterThreeName;
    public Text characterFourName;
    public Text characterFiveName;
    public Text characterSixName;
    public Text characterOneLvlTxt;
    public Text characterTwoLvlTxt;
    public Text characterThreeLvlTxt;
    public Text characterFourLvlTxt;
    public Text characterFiveLvlTxt;
    public Text characterSixLvlTxt;
    public Text characterOneExpTxt;
    public Text characterTwoExpTxt;
    public Text characterThreeExpTxt;
    public Text characterFourExpTxt;
    public Text characterFiveExpTxt;
    public Text characterSixExpTxt;

    public bool postBattle;

    public bool expGainNeeded;
    public bool expGained;

    
      
	// Use this for initialization
	void Start ()
    {



        chaeli = GameObject.Find("Chaeli");

        //heroState = partyManager.PartyMembers[0].GetComponent<HeroStateMachine>();

        postBattle = false;

        partyManager = GameObject.Find("PartyManager").GetComponent<PartyManager>();

        chaeliHeroState = partyManager.PartyMembers[0].GetComponent<HeroStateMachine>();
        lonHeroState = partyManager.PartyMembers[1].GetComponent<HeroStateMachine>();
        piyrylHeroState = partyManager.PartyMembers[2].GetComponent<HeroStateMachine>();
        alxHeroState = partyManager.PartyMembers[3].GetComponent<HeroStateMachine>();
        tzeyHeroState = partyManager.PartyMembers[4].GetComponent<HeroStateMachine>();
        choawHeroState = partyManager.PartyMembers[5].GetComponent<HeroStateMachine>();

        //characterlevels
        characterOneLvlTxt.text = "LVL: " + chaeli.GetComponent<HeroStateMachine>().hero.currentLevel;
        characterTwoLvlTxt.text = "LVL: " + partyManager.PartyMembers[1].GetComponent<HeroStateMachine>().hero.currentLevel;
        characterThreeLvlTxt.text = "LVL: " + partyManager.PartyMembers[2].GetComponent<HeroStateMachine>().hero.currentLevel;
        characterFourLvlTxt.text = "LVL: " + partyManager.PartyMembers[3].GetComponent<HeroStateMachine>().hero.currentLevel;
        characterFiveLvlTxt.text = "LVL: " + partyManager.PartyMembers[4].GetComponent<HeroStateMachine>().hero.currentLevel;
        characterSixLvlTxt.text = "LVL: " + partyManager.PartyMembers[5].GetComponent<HeroStateMachine>().hero.currentLevel;

        //character xp stats
        chaeliExp = partyManager.PartyMembers[0].GetComponent<HeroStateMachine>().hero.currentXP;
        lonExp = partyManager.PartyMembers[1].GetComponent<HeroStateMachine>().hero.currentXP;
        piyrylExp = partyManager.PartyMembers[2].GetComponent<HeroStateMachine>().hero.currentXP;
        alxExp = partyManager.PartyMembers[3].GetComponent<HeroStateMachine>().hero.currentXP;
        tzeyExp = partyManager.PartyMembers[4].GetComponent<HeroStateMachine>().hero.currentXP;
        choawExp = partyManager.PartyMembers[5].GetComponent<HeroStateMachine>().hero.currentXP;

        //exp display
        characterOneExpTxt.text = "EXP: " + partyManager.PartyMembers[0].GetComponent<HeroStateMachine>().hero.currentXP + "/" + partyManager.PartyMembers[0].GetComponent<HeroStateMachine>().hero.requiredXP;
        characterTwoExpTxt.text = "EXP: " + partyManager.PartyMembers[1].GetComponent<HeroStateMachine>().hero.currentXP + "/" + partyManager.PartyMembers[1].GetComponent<HeroStateMachine>().hero.requiredXP;
        characterThreeExpTxt.text = "EXP: " + partyManager.PartyMembers[2].GetComponent<HeroStateMachine>().hero.currentXP + "/" + partyManager.PartyMembers[2].GetComponent<HeroStateMachine>().hero.requiredXP;
        characterFourExpTxt.text = "EXP: " + partyManager.PartyMembers[3].GetComponent<HeroStateMachine>().hero.currentXP + "/" + partyManager.PartyMembers[3].GetComponent<HeroStateMachine>().hero.requiredXP;
        characterFiveExpTxt.text = "EXP: " + partyManager.PartyMembers[4].GetComponent<HeroStateMachine>().hero.currentXP + "/" + partyManager.PartyMembers[4].GetComponent<HeroStateMachine>().hero.requiredXP;
        characterSixExpTxt.text = "EXP: " + partyManager.PartyMembers[5].GetComponent<HeroStateMachine>().hero.currentXP + "/" + partyManager.PartyMembers[5].GetComponent<HeroStateMachine>().hero.requiredXP;

        //character xp sliders
        characterOneXpSlider.minValue = 0;
        characterOneXpSlider.maxValue = partyManager.PartyMembers[0].GetComponent<HeroStateMachine>().hero.requiredXP;
        characterOneXpSlider.value = chaeliExp;
        characterTwoXpSlider.minValue = 0;
        characterTwoXpSlider.maxValue = partyManager.PartyMembers[1].GetComponent<HeroStateMachine>().hero.requiredXP;
        characterTwoXpSlider.value = lonExp;
        characterThreeXpSlider.minValue = 0;
        characterThreeXpSlider.maxValue = partyManager.PartyMembers[2].GetComponent<HeroStateMachine>().hero.requiredXP;
        characterThreeXpSlider.value = piyrylExp;
        characterFourXpSlider.minValue = 0;
        characterFourXpSlider.maxValue = partyManager.PartyMembers[3].GetComponent<HeroStateMachine>().hero.requiredXP;
        characterFourXpSlider.value = alxExp;
        characterFiveXpSlider.minValue = 0;
        characterFiveXpSlider.maxValue = partyManager.PartyMembers[4].GetComponent<HeroStateMachine>().hero.requiredXP;
        characterFiveXpSlider.value = tzeyExp;
        characterSixXpSlider.minValue = 0;
        characterSixXpSlider.maxValue = partyManager.PartyMembers[5].GetComponent<HeroStateMachine>().hero.requiredXP;
        characterSixXpSlider.value = choawExp;

        //character names
        characterOneName.text = partyManager.PartyMembers[0].GetComponent<HeroStateMachine>().hero.theName;
        characterTwoName.text = partyManager.PartyMembers[1].GetComponent<HeroStateMachine>().hero.theName;
        characterThreeName.text = partyManager.PartyMembers[2].GetComponent<HeroStateMachine>().hero.theName;
        characterFourName.text = partyManager.PartyMembers[3].GetComponent<HeroStateMachine>().hero.theName;
        characterFiveName.text = partyManager.PartyMembers[4].GetComponent<HeroStateMachine>().hero.theName;
        characterSixName.text = partyManager.PartyMembers[5].GetComponent<HeroStateMachine>().hero.theName;



        //character exp numbers
    }

    public void GainChaeliXp(float xp)
    {
        partyManager.PartyMembers[0].GetComponent<HeroStateMachine>().hero.currentXP = (int)Mathf.Lerp(chaeliExp, xp, Time.deltaTime * expBarSpeed);
        Debug.Log("GainingXP " + chaeliExp + " To " + xp);
    }

	// Update is called once per frame
	void Update ()
    {

        chaeliHeroState = partyManager.PartyMembers[0].GetComponent<HeroStateMachine>();
        lonHeroState = partyManager.PartyMembers[1].GetComponent<HeroStateMachine>();
        piyrylHeroState = partyManager.PartyMembers[2].GetComponent<HeroStateMachine>();
        alxHeroState = partyManager.PartyMembers[3].GetComponent<HeroStateMachine>();
        tzeyHeroState = partyManager.PartyMembers[4].GetComponent<HeroStateMachine>();
        choawHeroState = partyManager.PartyMembers[5].GetComponent<HeroStateMachine>();


        //character xp stats
        chaeliExp = chaeliHeroState.hero.currentXP;
        lonExp = partyManager.PartyMembers[1].GetComponent<HeroStateMachine>().hero.currentXP;
        piyrylExp = partyManager.PartyMembers[2].GetComponent<HeroStateMachine>().hero.currentXP;
        alxExp = partyManager.PartyMembers[3].GetComponent<HeroStateMachine>().hero.currentXP;
        tzeyExp = partyManager.PartyMembers[4].GetComponent<HeroStateMachine>().hero.currentXP;
        choawExp = partyManager.PartyMembers[5].GetComponent<HeroStateMachine>().hero.currentXP;

        //characterlevels
        characterOneLvlTxt.text = "LVL: " + chaeliHeroState.hero.currentLevel;
        characterTwoLvlTxt.text = "LVL: " + partyManager.PartyMembers[1].GetComponent<HeroStateMachine>().hero.currentLevel;
        characterThreeLvlTxt.text = "LVL: " + partyManager.PartyMembers[2].GetComponent<HeroStateMachine>().hero.currentLevel;
        characterFourLvlTxt.text = "LVL: " + partyManager.PartyMembers[3].GetComponent<HeroStateMachine>().hero.currentLevel;
        characterFiveLvlTxt.text = "LVL: " + partyManager.PartyMembers[4].GetComponent<HeroStateMachine>().hero.currentLevel;
        characterSixLvlTxt.text = "LVL: " + partyManager.PartyMembers[5].GetComponent<HeroStateMachine>().hero.currentLevel;

        //character xp sliders
        characterOneXpSlider.minValue = 0;
        characterOneXpSlider.maxValue = chaeliHeroState.hero.requiredXP;
        characterOneXpSlider.value = chaeliHeroState.hero.currentXP;
        characterTwoXpSlider.minValue = 0;
        characterTwoXpSlider.maxValue = partyManager.PartyMembers[1].GetComponent<HeroStateMachine>().hero.requiredXP;
        characterTwoXpSlider.value = lonExp;
        characterThreeXpSlider.minValue = 0;
        characterThreeXpSlider.maxValue = partyManager.PartyMembers[2].GetComponent<HeroStateMachine>().hero.requiredXP;
        characterThreeXpSlider.value = piyrylExp;
        characterFourXpSlider.minValue = 0;
        characterFourXpSlider.maxValue = partyManager.PartyMembers[3].GetComponent<HeroStateMachine>().hero.requiredXP;
        characterFourXpSlider.value = alxExp;
        characterFiveXpSlider.minValue = 0;
        characterFiveXpSlider.maxValue = partyManager.PartyMembers[4].GetComponent<HeroStateMachine>().hero.requiredXP;
        characterFiveXpSlider.value = tzeyExp;
        characterSixXpSlider.minValue = 0;
        characterSixXpSlider.maxValue = partyManager.PartyMembers[5].GetComponent<HeroStateMachine>().hero.requiredXP;
        characterSixXpSlider.value = choawExp;

        characterOneExpTxt.text = "EXP: " + chaeliHeroState.hero.currentXP + "/" + chaeliHeroState.hero.requiredXP;
        characterTwoExpTxt.text = "EXP: " + partyManager.PartyMembers[1].GetComponent<HeroStateMachine>().hero.currentXP + "/" + partyManager.PartyMembers[1].GetComponent<HeroStateMachine>().hero.requiredXP;
        characterThreeExpTxt.text = "EXP: " + partyManager.PartyMembers[2].GetComponent<HeroStateMachine>().hero.currentXP + "/" + partyManager.PartyMembers[2].GetComponent<HeroStateMachine>().hero.requiredXP;
        characterFourExpTxt.text = "EXP: " + partyManager.PartyMembers[3].GetComponent<HeroStateMachine>().hero.currentXP + "/" + partyManager.PartyMembers[3].GetComponent<HeroStateMachine>().hero.requiredXP;
        characterFiveExpTxt.text = "EXP: " + partyManager.PartyMembers[4].GetComponent<HeroStateMachine>().hero.currentXP + "/" + partyManager.PartyMembers[4].GetComponent<HeroStateMachine>().hero.requiredXP;
        characterSixExpTxt.text = "EXP: " + partyManager.PartyMembers[5].GetComponent<HeroStateMachine>().hero.currentXP + "/" + partyManager.PartyMembers[5].GetComponent<HeroStateMachine>().hero.requiredXP;

         
        if(expGainNeeded == true)
        {
            chaeliHeroState.hero.currentXP = 20f;

            if(chaeliExp >= newExp)
            {
                expGainNeeded = false;
                expGained = true;
                Debug.Log("Experience Gained");
                //newExp = chaeliExp;
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            expGainNeeded = true;

            newExp = partyManager.PartyMembers[0].GetComponent<HeroStateMachine>().hero.currentXP + 20f;

            //GainChaeliXp(newExp);
        }
    }


}
