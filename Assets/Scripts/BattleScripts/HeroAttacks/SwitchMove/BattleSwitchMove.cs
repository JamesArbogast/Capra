using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSwitchMove : MonoBehaviour {

    public List<GameObject> HeroesInBattleMenu = new List<GameObject>();
    public List<GameObject> HeroButtonsInBattle = new List<GameObject>();
    public List<GameObject> HeroesInWaitingMenu = new List<GameObject>();
    public List<GameObject> HeroButtonsInWaiting = new List<GameObject>();
    public GameObject heroInBattleButton;
    public GameObject heroInWaitingButton;
    public GameObject heroManagerPanel;
    public Transform activeHeroSpacer;
    public Transform waitingHeroSpacer;
    public string activeHeroSelected;
    public GameObject waitingHeroSelected;
    public bool turnQueueHasObject;



    private BattleStateMachine battleStateMachine;

    // Use this for initialization
    void Start ()
    {
        battleStateMachine = GameObject.Find("BattleManager").GetComponent<BattleStateMachine>();
        HeroesInBattleMenu = battleStateMachine.HeroesInBattle;
        HeroesInWaitingMenu = battleStateMachine.HeroesWaiting;
 
        heroManagerPanel.SetActive(false);

        ActiveHeroButtons();
        InactiveHeroButtons();
    }
	
	// Update is called once per frame
	void Update () 
    {


    }

    //populating active hero menu with buttons of heroes that are active
    public void ActiveHeroButtons()
    {
        foreach(GameObject hero in HeroesInBattleMenu)
        {
            GameObject newHeroActiveButton = Instantiate(heroInBattleButton) as GameObject;
            HeroSelectButton button = newHeroActiveButton.GetComponent<HeroSelectButton>();
            HeroStateMachine currentHero = hero.GetComponent<HeroStateMachine>();
            Text buttonText = newHeroActiveButton.transform.Find("HeroActiveButtonText").gameObject.GetComponent<Text>();
            buttonText.text = currentHero.hero.theName;
            button.heroPrefab = hero;

            newHeroActiveButton.transform.SetParent(activeHeroSpacer, false);
            HeroButtonsInBattle.Add(newHeroActiveButton);
            Debug.Log("Creating active hero buttons.");
            if(turnQueueHasObject == true)
            {
                if (activeHeroSelected == buttonText.text.ToString())
                {
                    newHeroActiveButton.GetComponent<Button>().interactable = true;
                }
                else
                {
                    newHeroActiveButton.GetComponent<Button>().interactable = false;
                }
            }
          
        }
    }


    //populating inactive hero menu with buttons of heroes that are inactive
    public void InactiveHeroButtons()
    {
        foreach (GameObject hero in HeroesInWaitingMenu)
        {
            GameObject newWaitButton = Instantiate(heroInWaitingButton) as GameObject;
            HeroSwitchSelectButton button = newWaitButton.GetComponent<HeroSwitchSelectButton>();
            HeroStateMachine currentHero = hero.GetComponent<HeroStateMachine>();
            Text buttonText = newWaitButton.transform.Find("HeroInactiveButtonText").gameObject.GetComponent<Text>();
            buttonText.text = currentHero.hero.theName;
            button.heroSwitchPrefab = hero;
            

            newWaitButton.transform.SetParent(waitingHeroSpacer, false);
            HeroButtonsInWaiting.Add(newWaitButton);
            Debug.Log("Creating inactive hero buttons.");
        }
    }

    public void PrepActiveHeroSelected()
    {

    }
}
