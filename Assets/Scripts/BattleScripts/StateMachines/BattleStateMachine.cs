using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class BattleStateMachine : MonoBehaviour {


    public bool actionButtonsCreated;

    public enum PerformAction
    {
        WAITING,
        TAKEACTION,
        PERFORMACTION,
        CHECKALIVE,
        WIN,
        LOSE,
        EXPSCREEN
    }

    public enum UIState
    {
        START,
        MELEEATKSELECT,
        MELEEENEMYSELECT,
        ZULIUMATKSELECT,
        ZULIUMENEMYSELECT,
        SKILLSATKSELECT,
        SKILLSTARGETSELECT,
        HEALSELECT,
        HEALTARGETSELECT,
        SKILLSCREEN,
        EXPSCREEN
    }

    public enum EnemyAnger
    {
        ANGRYLVL2,
        ANGRYLVL1,
        NEUTRAL,
        CALMLVL1,
        CALMLVL2
    }

    public EnemyAnger enemyAnger;
    public PerformAction performStates;
    public UIState uiState;

    public List<GameObject> TurnQueue = new List<GameObject>(); //the queue waiting to do your turn
    public List<HandleTurns> PerformList = new List<HandleTurns>(); //list of turn and action order
    public List<GameObject> HeroesInBattle = new List<GameObject>(); //list of heroes in battle
    public List<GameObject> AttackableHeroes = new List<GameObject>(); //list of heroes that are attackable even if not being managed
    public List<GameObject> HeroesStudying = new List<GameObject>();  //list of heroes doing the studying move
    public List<GameObject> HeroesAbsorbing = new List<GameObject>(); //list of heroes doing the absorb skill and guarding an ally
    public List<GameObject> EnemyBeingStudied = new List<GameObject>(); //enemy being studied
    public List<GameObject> HeroBeingGuarded = new List<GameObject>(); //hero being guarded by another hero 
    public List<GameObject> HeroesWaiting = new List<GameObject>();
    public List<GameObject> EnemiesInBattle = new List<GameObject>(); //list of enemies in battle
    public List<GameObject> EnemyButtonsInBattle = new List<GameObject>(); //list of enemy buttons available
    public List<GameObject> HeroButtonsInBattle = new List<GameObject>();
    public List<GameObject> EveryoneInBattle = new List<GameObject>(); //list of all battle contestants
    public List<Sprite> weaknessImages = new List<Sprite>(); //list of weakness images


    public enum HeroGUI
    {
        IDLE,
        ACTIVATE,
        WAITING,
        INPUT1,
        INPUT2,
        DONE
    }

    public HeroGUI heroInput;

    public List<GameObject> HeroesToManage = new List<GameObject>();
    public HandleTurns heroChoice;
    private HandleSwitch heroSwitch; 
    public GameObject enemyButton;
    public GameObject heroButton;
    public GameObject backButton;
    public Transform enemySelectSpacer;
    public Transform heroSelectSpacer;
    public Text turnTextDisplay;

    //battle scene gui
    public GameObject fullBattleCanvas;
    public GameObject actionPanel;
    public GameObject enemySelectPanel;
    public GameObject heroSelectPanel;
    public GameObject zuliumPanel;
    public GameObject meleePanel;
    public GameObject skillPanel;
    public GameObject healPanel;
    public GameObject battlePausePanel;
    public GameObject switchHeroPanel;
    public GameObject quickTimeCanvas;
    public GameObject winLoseScreen;

    //attack spacers for buttons + buttons
    public Transform actionSpacer;
    public Transform zuliumSpacer;
    public Transform meleeSpacer;
    public Transform skillSpacer;
    public Transform healSpacer;
    //public Transform switchSpacer;
    public GameObject actionButton;
    public GameObject meleeActionButton;
    public GameObject zuliumActionButton;
    public GameObject healActionButton;
    public GameObject skillActionButton;
    public GameObject zuliumButton;
    public GameObject meleeButton;
    public GameObject skillButton;
    public GameObject healButton;
    public GameObject heroInactiveButton;
    public GameObject heroActiveButton;
    private List<GameObject> atkBtns = new List <GameObject>();

    public bool heroGUIOn;
    public bool gamePaused;

    //turn counting
    public int turnQueueCount;
    public int roundCount;
    public int turnsInRound;
    public int totalTurnsThisRound;
    public int currentRoundCount;
    public bool turnQueueFull;
    public bool turnQueueEmpty;
    public bool turnQueueFilling;
    public GameObject turnNameText;


    //critical hit
    public bool criticalHitSuccess;

    //battle switch
    private BattleSwitchMove battleSwitch;

    //inventory
    private InventoryManager inventoryManager;

    //victory/lose screen animations
    public Animator winLoseScreenAnim;
    float victoryScreenTimer = 0;
    bool victoryTimerReached = false;

    //enemy skill effects
    public bool enemiesAngeredLevel1;
    public bool enemiesCalmedLevel1;


    // Use this for initialization
    void Start ()
    {
        roundCount = 0;
        totalTurnsThisRound = 0;
        DontDestroyOnLoad(this.gameObject);
        //DontDestroyOnLoad(EnemiesInBattle[0]);
        //inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        gamePaused = false;
        battlePausePanel.SetActive(false);
        heroGUIOn = false;
        performStates = PerformAction.WAITING;
        uiState = UIState.START;
        EnemiesInBattle.AddRange(GameObject.FindGameObjectsWithTag("BattleEnemy")); //determining which enemies are in battle
        HeroesInBattle.AddRange(GameObject.FindGameObjectsWithTag("Hero")); //determining which players are in battle
        AttackableHeroes.AddRange(GameObject.FindGameObjectsWithTag("Hero")); //heroes that the enemy can attack
        HeroesWaiting.AddRange(GameObject.FindGameObjectsWithTag("HeroInWait")); //determing which heroes are waiting to battle
        EveryoneInBattle.AddRange(GameObject.FindGameObjectsWithTag("Hero"));
        EveryoneInBattle.AddRange(GameObject.FindGameObjectsWithTag("BattleEnemy"));
        //public List<GameObject> sortedBattleList = EveryoneInBattle.OrderBy(x => x.GetComponent<HeroStateMachine>().hero.speed);
        
        heroInput = HeroGUI.ACTIVATE;

        //starting scene with no active panels (for now)
        actionPanel.SetActive(false);
        enemySelectPanel.SetActive(false);
        heroSelectPanel.SetActive(false);
        zuliumPanel.SetActive(false);
        meleePanel.SetActive(false);
        skillPanel.SetActive(false);
        healPanel.SetActive(false);
        switchHeroPanel.SetActive(false);
        backButton.SetActive(false);
        quickTimeCanvas.SetActive(false);

        //creating the buttons for each of the enemies and heroes
        EnemyButtons();
        HeroButtons();

        //access to the battleswitch move 
        battleSwitch = GameObject.Find("TeamManager").GetComponent<BattleSwitchMove>();

        battleSwitch.ActiveHeroButtons();
        battleSwitch.InactiveHeroButtons();
        //inventoryManager.HeroInventoryPanels();

        //make sure win or lose screen is not active until win or lose occurs
        winLoseScreen.SetActive(false);

        //enemy anger
        enemyAnger = EnemyAnger.NEUTRAL;

        //exp screen start
        if(SceneManager.GetActiveScene().name == "ExpGainScreen")
        {
            performStates = PerformAction.EXPSCREEN;
            uiState = UIState.EXPSCREEN;
        }

    }
	
	// Update is called once per frame
	void Update ()
    {
        //giving the status of the turn queue counter 
        TurnConfiguration();


        //text display of names based on turn
        if (TurnQueue.Count == 0)
        {
            turnTextDisplay.text = "Waiting";
        }
        else
        {
            turnTextDisplay.text = TurnQueue[0].name;
        }

        totalTurnsThisRound = EveryoneInBattle.Count;

        //name of player or enemy whose turn it is
        /*if(turnQueueFull || turnQueueFilling)
        {
            turnNameText = TurnQueue[0];

            if (turnNameText.GetComponent<HeroStateMachine>() != null)
            {
                turnTextDisplay.text = TurnQueue[0].GetComponent<HeroStateMachine>().hero.theName;
            }
            else if (turnNameText.GetComponent<EnemyStateMachine>() != null)
            {
                turnTextDisplay.text = TurnQueue[0].GetComponent<EnemyStateMachine>().enemy.theName;
            }
            else
            {
                turnTextDisplay.text = "Selecting";
            }
        }
        else if (turnQueueEmpty)
        {
            turnTextDisplay.text = "Waiting";
        }
        else
        {
            turnTextDisplay.text = "Selecting";
        }*/



        //Debug.Log("PerformState: " + performStates);
        //Debug.Log("Hero GUI State: " + heroInput);

        //pause game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!battlePausePanel.activeInHierarchy)
            {
                PauseGame();
                gamePaused = true; 
            }
            else if (battlePausePanel.activeInHierarchy)
            {
                ContinueGame();
                gamePaused = false;
            }
        }

        switch (performStates)
        {
            case (PerformAction.WAITING):

                if (PerformList.Count > 0)
                {
                    performStates = PerformAction.TAKEACTION;
                }

                break;

            case (PerformAction.TAKEACTION):

                
                GameObject performer = GameObject.Find(PerformList[0].attacker);
   

                if (PerformList[0].type == "Enemy") //PerformList[0].type is ACTUAL CODE
                {

                    EnemyStateMachine enemyStatMachine = performer.GetComponent<EnemyStateMachine>();
                    for(int i = 0; i < AttackableHeroes.Count; i++)
                    {
                        if (PerformList[0].attackersTarget == AttackableHeroes[i])
                        {
                            enemyStatMachine.heroToAttack = PerformList[0].attackersTarget;
                            enemyStatMachine.currentState = EnemyStateMachine.TurnState.ACTION;
                            break;
                        }
                        else
                        {
                            PerformList[0].attackersTarget = AttackableHeroes[Random.Range(0, AttackableHeroes.Count)];
                            enemyStatMachine.heroToAttack = PerformList[0].attackersTarget;
                            enemyStatMachine.currentState = EnemyStateMachine.TurnState.ACTION;
                        }
                    }
                    
                }

                if(PerformList[0].type == "Hero")
                {
                    HeroStateMachine heroStateMachine = performer.GetComponent<HeroStateMachine>();
                    heroStateMachine.heroToHeal = PerformList[0].attackersTarget;
                    heroStateMachine.currentState = HeroStateMachine.TurnState.ACTION;
                }

                if (PerformList[0].type == "Hero")
                {
                 
                    HeroStateMachine heroStateMachine = performer.GetComponent<HeroStateMachine>();
                    heroStateMachine.enemyToAttack = PerformList[0].attackersTarget;
                    heroStateMachine.currentState = HeroStateMachine.TurnState.ACTION;
                    
                }

                performStates = PerformAction.PERFORMACTION;
                break;

            case (PerformAction.PERFORMACTION):

            break;

            case (PerformAction.CHECKALIVE):
                if (AttackableHeroes.Count < 1)
                {
                    performStates = PerformAction.LOSE;
                    //lose the battle
                }
                else if(EnemiesInBattle.Count < 1)
                {
                    performStates = PerformAction.WIN;
                    //win the battle
                    
                }
                else
                {
                    ClearAttackPanel();
                    heroInput = HeroGUI.ACTIVATE;
                    performStates = PerformAction.WAITING;
                }

                break;

            case (PerformAction.WIN):
            {
                    Debug.Log("You Win!");
                    if (!victoryTimerReached)
                        victoryScreenTimer += Time.deltaTime;

                    if (!victoryTimerReached && victoryScreenTimer > 10)
                    {
                        PlayVictoryScreenAnimation();
                        for (int i = 0; i < HeroesInBattle.Count; i++)
                        {
                            HeroesInBattle[i].GetComponent<HeroStateMachine>().currentState = HeroStateMachine.TurnState.PROCESSING;
                        }

                        SceneManager.LoadScene(4);
                        //Set to false so that We don't run this again
                        victoryTimerReached = true;
                    }

                    
            }
                break;

            //lose game, play lose animation, wait ten seconds, freeze, transition scenes
            case (PerformAction.LOSE):
            {
                    Debug.Log("You lose.");
                    PlayLoseScreenAnimation();
                    //Thread.Sleep(10000);
                    //Time.timeScale = 0;

            }
                break;

            case (PerformAction.EXPSCREEN):
            {

            }
            
                break;
        }

        switch (heroInput)
        {
            case (HeroGUI.IDLE):

                heroInput = HeroGUI.ACTIVATE;

                break;

            case (HeroGUI.ACTIVATE):
                if(HeroesToManage.Count > 0 ) //HeroesToManage.Count > 0 ACTUAL CODE!!!
                {
                    HeroesToManage[0].transform.Find("Selector").gameObject.SetActive(true); //actual beginning of line is HeroesToManage[0]
                    //create new handleturn instance
                    heroChoice = new HandleTurns();
                    //heroSwitch = new HandleSwitch();
                    StartingUI();
                    //populate action buttons
                    CreateActionButtons();
                    heroGUIOn = true;

                    heroInput = HeroGUI.WAITING;
                    
                }
                else
                {
                    heroInput = HeroGUI.IDLE;
                }

                break;

            case (HeroGUI.WAITING):
                //idle
                break;

            case (HeroGUI.DONE):
                HeroInputDone();
                break;

        }



    }

    public void CollectActions(HandleTurns input)
    {
        PerformList.Add(input);
    }

    public void EnemyButtons()
    {
        foreach(GameObject enemy in EnemiesInBattle)
        {
            GameObject newButton = Instantiate(enemyButton) as GameObject;
            EnemySelectButton button = newButton.GetComponent<EnemySelectButton>();

            EnemyStateMachine currentEnemy = enemy.GetComponent<EnemyStateMachine>();

            Text buttonText = newButton.transform.Find("Text").gameObject.GetComponent<Text>();
            buttonText.text = currentEnemy.enemy.theName;
            button.enemyPrefab = enemy;

            newButton.transform.SetParent(enemySelectSpacer, false);
            EnemyButtonsInBattle.Add(newButton);

        }
    }

    public void HeroButtons()
    {
        foreach(GameObject hero in HeroesInBattle)
        {
            GameObject newHeroButton = Instantiate(heroButton) as GameObject;
            HeroSelectButton button = newHeroButton.GetComponent<HeroSelectButton>();
            HeroStateMachine currentHero = hero.GetComponent<HeroStateMachine>();
            Text buttonText = newHeroButton.transform.Find("Text").gameObject.GetComponent<Text>();
            buttonText.text = currentHero.hero.theName;
            button.heroPrefab = hero;

            newHeroButton.transform.SetParent(heroSelectSpacer, false);
            HeroButtonsInBattle.Add(newHeroButton);

        }
    }

    public void InputOne() //attack button
    {
        heroChoice.attacker = HeroesToManage[0].name;
        heroChoice.attackersGameObject = HeroesToManage[0];
        heroChoice.type = "Hero";
        heroChoice.chooseAttack = HeroesToManage[0].GetComponent<HeroStateMachine>().hero.meleeAttacks[0];
        actionPanel.SetActive(false);
        meleePanel.SetActive(true);
        
    }

    public void SwitchInputOne()
    {
        heroSwitch.selectedActiveHero = HeroesToManage[0];   
    }

    public void SwitchInputTwo(GameObject chosenSwitchHero)
    {
        heroSwitch.selectedActiveHero = chosenSwitchHero;
    }

   /* public void InputTen()
    {
        heroChoice.attacker = HeroesToManage[0].name;
        heroChoice.attackersGameObject = HeroesToManage[0];
        heroChoice.type = "Hero";
        heroChoice.chooseAttack = HeroesToManage[0].GetComponent<HeroStateMachine>().hero.healMoves[0];
        actionPanel.SetActive(false);
        healPanel.SetActive(true);
    }*/


    public void InputTwo(GameObject chosenEnemy) //enemy selection
    {
        heroChoice.attackersTarget = chosenEnemy;
        heroInput = HeroGUI.DONE;
    }

    public void InputThirteen(GameObject chosenHero)
    {
        heroChoice.attackersTarget = chosenHero;
        heroInput = HeroGUI.DONE;
    }


    void HeroInputDone()
    {
        PerformList.Add(heroChoice);
        ClearAttackPanel();
        HeroesToManage[0].transform.Find("Selector").gameObject.SetActive(false);
        HeroesToManage.RemoveAt(0);
        TurnQueue.RemoveAt(0);
        turnsInRound++;
        turnQueueCount--;
        heroInput = HeroGUI.ACTIVATE;
    }

    void ClearAttackPanel()
    {
        enemySelectPanel.SetActive(false);
        heroSelectPanel.SetActive(false);
        actionPanel.SetActive(false);
        zuliumPanel.SetActive(false);
        meleePanel.SetActive(false);
        healPanel.SetActive(false);
        foreach (GameObject atkBtn in atkBtns)
        {
            Destroy(atkBtn);
        }
        atkBtns.Clear();

        actionButtonsCreated = false;

    }

    //create action buttons
    void CreateActionButtons()
    {
        //creating the attack button 
        GameObject meleeAttackButton = Instantiate(meleeActionButton) as GameObject;
        Text meleeAttackButtonText = meleeAttackButton.transform.Find("MeleeActionButtonText").gameObject.GetComponent<Text>();
        meleeAttackButtonText.text = "MELEE";
        meleeAttackButton.GetComponent<Button>().onClick.AddListener(() => InputSix());
        meleeAttackButton.transform.SetParent(actionSpacer, false);
        atkBtns.Add(meleeAttackButton);
        //creating the zulium button
        GameObject zuliumAttackButton = Instantiate(zuliumActionButton) as GameObject;
        Text zuliumAttackButtonText = zuliumAttackButton.transform.Find("ZuliumActionButtonText").gameObject.GetComponent<Text>();
        zuliumAttackButtonText.text = "ZULIUM";
        zuliumAttackButton.GetComponent<Button>().onClick.AddListener(() => InputThree());
        zuliumAttackButton.transform.SetParent(actionSpacer, false);
        atkBtns.Add(zuliumAttackButton);
        //creating the skills button
        GameObject skillAttackButton = Instantiate(skillActionButton) as GameObject;
        Text skillAttackButtonText = skillAttackButton.transform.Find("SkillActionButtonText").gameObject.GetComponent<Text>();
        skillAttackButtonText.text = "SKILLS";
        skillAttackButton.GetComponent<Button>().onClick.AddListener(() => InputSeven());
        skillAttackButton.transform.SetParent(actionSpacer, false);
        atkBtns.Add(skillAttackButton);
        //creating the heal move button
        GameObject healMoveButton = Instantiate(healActionButton) as GameObject;
        Text healMoveButtonText = healMoveButton.transform.Find("HealActionButtonText").gameObject.GetComponent<Text>();
        healMoveButtonText.text = "HEAL";
        healMoveButton.GetComponent<Button>().onClick.AddListener(() => InputTwelve());
        healMoveButton.transform.SetParent(actionSpacer, false);
        atkBtns.Add(healMoveButton);

        /*GameObject switchMoveButton = Instantiate(heroInactiveButton) as GameObject;
        Text switchMoveButtonText = switchMoveButton.transform.Find("SwitchButtonText").gameObject.GetComponent<Text>();
        switchMoveButtonText.text = "SWITCH";
        switchMoveButton.GetComponent<Button>().onClick.AddListener(() => InputFourteen());
        switchMoveButton.transform.SetParent(actionSpacer, false);
        atkBtns.Add(switchMoveButton);*/
        

        if (HeroesToManage[0].GetComponent<HeroStateMachine>().hero.zuliumAttacks.Count > 0)
        {
            foreach(BaseAttack zuliumAtk in HeroesToManage[0].GetComponent<HeroStateMachine>().hero.zuliumAttacks)
            {
                GameObject zuliumMoveButton = Instantiate(zuliumButton) as GameObject;
                Text zuliumMoveButtonText = zuliumMoveButton.transform.Find("ZuliumButtonText").gameObject.GetComponent<Text>();
                zuliumMoveButtonText.text = zuliumAtk.attackName;

                zuliumMoveButton.GetComponent<AttackButton>().zuliumAttackToPerform = HeroesToManage[0].GetComponent<HeroStateMachine>().hero.zuliumAttacks[0];
                zuliumMoveButton.transform.SetParent(zuliumSpacer, false);
                atkBtns.Add(zuliumMoveButton);
                atkBtns.Add(zuliumMoveButton);
            }
        }
        else
        {
            zuliumAttackButton.GetComponent<Button>().interactable = false;
        }

        if (HeroesToManage[0].GetComponent<HeroStateMachine>().hero.meleeAttacks.Count > 0)
        {
            foreach (BaseAttack meleeAtk in HeroesToManage[0].GetComponent<HeroStateMachine>().hero.meleeAttacks)
            {
                
                GameObject meleeMoveButton = Instantiate(meleeButton) as GameObject;
                Text meleeMoveButtonText = meleeMoveButton.transform.Find("MeleeButtonText").gameObject.GetComponent<Text>();
                meleeMoveButtonText.text = meleeAtk.attackName;

                //AttackButton ATB = meleeButton.GetComponent<AttackButton>();
                meleeMoveButton.GetComponent<AttackButton>().meleeAttackToPerform = HeroesToManage[0].GetComponent<HeroStateMachine>().hero.meleeAttacks[0];
                //ATB.meleeAttackToPerform = meleeAtk;
                meleeMoveButton.transform.SetParent(meleeSpacer, false);
                atkBtns.Add(meleeMoveButton);
                
            }
        }
        else
        {
            meleeAttackButton.GetComponent<Button>().interactable = false;
        }

        if (HeroesToManage[0].GetComponent<HeroStateMachine>().hero.skillAttacks.Count > 0)
        {
            foreach (BaseAttack skillAtk in HeroesToManage[0].GetComponent<HeroStateMachine>().hero.skillAttacks)
            {
                GameObject skillMoveButton = Instantiate(skillButton) as GameObject;
                Text skillsMoveButtonText = skillMoveButton.transform.Find("SkillButtonText").gameObject.GetComponent<Text>();
                skillsMoveButtonText.text = skillAtk.attackName;

                skillMoveButton.GetComponent<AttackButton>().skillAttackToPerform = HeroesToManage[0].GetComponent<HeroStateMachine>().hero.skillAttacks[0];
                skillMoveButton.transform.SetParent(skillSpacer, false);
                atkBtns.Add(skillMoveButton);
            }
        }
        else
        {
            skillAttackButton.GetComponent<Button>().interactable = false;
        }

        if(HeroesToManage[0].GetComponent<HeroStateMachine>().hero.healMoves.Count > 0)
        {
            foreach(BaseAttack healMov in HeroesToManage[0].GetComponent<HeroStateMachine>().hero.healMoves)
            {
                GameObject healingButton = Instantiate(healButton) as GameObject;
                Text healingMoveButtonText = healingButton.transform.Find("HealButtonText").gameObject.GetComponent<Text>();
                healingMoveButtonText.text = healMov.attackName;

                healingButton.GetComponent<AttackButton>().healMoveToPerform = HeroesToManage[0].GetComponent<HeroStateMachine>().hero.healMoves[0];
                healingButton.transform.SetParent(healSpacer, false);
                atkBtns.Add(healingButton);
            }
        }

        /*if (HeroesToManage[0].GetComponent<HeroStateMachine>().hero.switchMove.Count > 0)
        {
            foreach (BaseAttack switchAtk in HeroesToManage[0].GetComponent<HeroStateMachine>().hero.switchMove)
            {
                GameObject switchingButton = Instantiate(heroInactiveButton) as GameObject;
                Text switchingButtonText = switchingButton.transform.Find("SwitchButtonText").gameObject.GetComponent<Text>();
                switchingButtonText.text = switchAtk.attackName;

                AttackButton ATB = heroInactiveButton.GetComponent<AttackButton>();
                ATB.zuliumAttackToPerform = switchAtk;
                switchingButton.transform.SetParent(switchSpacer, false);
                atkBtns.Add(switchingButton);
            }
        }*/

        actionButtonsCreated = true;
    }

    //giving the status of the turn queue counter 
    public void TurnConfiguration()
    {

        CheckRoundCount();

        if(turnQueueCount == EveryoneInBattle.Count)
        {
            turnQueueFull = true;
        }
        else
        {
            turnQueueFull = false;
        }
        if(turnQueueCount == 0)
        {
            turnQueueEmpty = true;
        }
        else
        {
            turnQueueEmpty = false;
        }
        if(turnQueueCount < EveryoneInBattle.Count)
        {
            turnQueueFilling = true;
        }
        else
        {
            turnQueueFilling = false;
        }
    }

    public void InputFour(BaseAttack chosenZulium) //chosen zulium attack
    {
        heroChoice.attacker = HeroesToManage[0].name;
        heroChoice.attackersGameObject = HeroesToManage[0];
        heroChoice.type = "Hero";

        heroChoice.chooseAttack = chosenZulium;
        zuliumPanel.SetActive(false);
        enemySelectPanel.SetActive(true);
        backButton.SetActive(true);
        uiState = UIState.ZULIUMENEMYSELECT;
        Debug.Log(chosenZulium);
    }

    public void InputFive(BaseAttack chosenMelee) //melee attack has been chosen
    {
        heroChoice.attacker = HeroesToManage[0].name;
        heroChoice.attackersGameObject = HeroesToManage[0];
        heroChoice.type = "Hero";

        heroChoice.chooseAttack = chosenMelee;
        meleePanel.SetActive(false);
        enemySelectPanel.SetActive(true);
        backButton.SetActive(true);
        uiState = UIState.MELEEENEMYSELECT;
        Debug.Log(chosenMelee);
    }

    public void InputNine(BaseAttack chosenSkill) //skill move has been chosen
    {
        heroChoice.attacker = HeroesToManage[0].name;
        heroChoice.attackersGameObject = HeroesToManage[0];
        heroChoice.type = "Hero";

        heroChoice.chooseAttack = chosenSkill;

        Debug.Log(chosenSkill.skillType);

        BaseAttack.SkillType heroSkillType = HeroesToManage[0].GetComponent<HeroStateMachine>().hero.skillAttacks[0].skillType;

        if (chosenSkill.skillType == BaseAttack.SkillType.EnemyTeamChoosePassive)
        {
            skillPanel.SetActive(false);
            heroSelectPanel.SetActive(false);
            enemySelectPanel.SetActive(true);
        } 
        else if (chosenSkill.skillType == BaseAttack.SkillType.HeroTeamIndividualPassive)
        {
            skillPanel.SetActive(false);
            heroSelectPanel.SetActive(false);
            heroChoice.attackersTarget = this.gameObject;
        }
        else if (chosenSkill.skillType == BaseAttack.SkillType.HeroIndividualChoicePassiveNotPlayer)
        {
            skillPanel.SetActive(false);
            heroSelectPanel.SetActive(true);
            enemySelectPanel.SetActive(false);
        }
        else if (chosenSkill.skillType == BaseAttack.SkillType.EnemyFullTeamPassive)
        {
            heroChoice.attackersTarget = EnemiesInBattle[0];
            skillPanel.SetActive(false);
        }
        else
        {
            skillPanel.SetActive(false);
            enemySelectPanel.SetActive(false);
            heroSelectPanel.SetActive(true);
        }
    }

    public void InputThirteen(BaseAttack chosenHeal) //heal move has been chosen
    {
        heroChoice.attacker = HeroesToManage[0].name;
        heroChoice.attackersGameObject = HeroesToManage[0];
        heroChoice.type = "Hero";

        heroChoice.chooseAttack = chosenHeal;
        healPanel.SetActive(false);
        heroSelectPanel.SetActive(true);
        backButton.SetActive(true);
        uiState = UIState.HEALTARGETSELECT;
    }

    public void InputFifteen(BaseAttack chosenSwitch) //switch action has been chosen
    {
        GameObject button = GameObject.Find("HeroActiveButtonOne");
        heroChoice.attacker = HeroesToManage[0].name;
        heroChoice.attackersGameObject = HeroesToManage[0];
        heroChoice.type = "Hero";

        heroChoice.chooseAttack = chosenSwitch;
        //switchHeroPanel.SetActive(true);
        if(button.GetComponent<HeroSelectButton>().heroPrefab.name == HeroesToManage[0].name)
        {
            button.GetComponent<Image>().color = new Color(255, 255, 255);
        }
        else
        {
            button.GetComponent<Image>().color = new Color(0, 0, 0);
        }
    }

    public void InputThree() //switching to zulium attacks
    {
        actionPanel.SetActive(false);
        enemySelectPanel.SetActive(false);
        heroSelectPanel.SetActive(false);
        zuliumPanel.SetActive(true);
        backButton.SetActive(true);
        uiState = UIState.ZULIUMATKSELECT;
    }

    public void InputSix() //switching to melee attacks
    {
        actionPanel.SetActive(false);
        enemySelectPanel.SetActive(false);
        heroSelectPanel.SetActive(false);
        meleePanel.SetActive(true);
        backButton.SetActive(true);
        uiState = UIState.MELEEATKSELECT;
    }

    public void InputSeven() //switching to skill attacks
    {
        actionPanel.SetActive(false);
        enemySelectPanel.SetActive(false);
        heroSelectPanel.SetActive(false);
        skillPanel.SetActive(true);
        backButton.SetActive(true);
        uiState = UIState.SKILLSATKSELECT;
    }

    public void InputTwelve() //switching to heal moves
    {
        actionPanel.SetActive(false);
        enemySelectPanel.SetActive(false);
        heroSelectPanel.SetActive(false);
        healPanel.SetActive(true);
        backButton.SetActive(true);
        uiState = UIState.HEALSELECT;
    }

    public void InputFourteen() //using a switch function and chooosing
    {
        actionPanel.SetActive(false);
        enemySelectPanel.SetActive(false);
        heroSelectPanel.SetActive(false);
        healPanel.SetActive(false);
        skillPanel.SetActive(false);
        switchHeroPanel.SetActive(true);
        FreezeGameTime();
        gamePaused = true;
    }

    public void StartingUI()
    {
        actionPanel.SetActive(true);
        enemySelectPanel.SetActive(false);
        heroSelectPanel.SetActive(false);
        healPanel.SetActive(false);
        backButton.SetActive(false);
        zuliumPanel.SetActive(false);
        meleePanel.SetActive(false);
        skillPanel.SetActive(false);
        healPanel.SetActive(false);
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        battlePausePanel.SetActive(true);
        //Disable scripts that still work while timescale is set to 0
    }
    private void ContinueGame()
    {
        Time.timeScale = 1;
        battlePausePanel.SetActive(false);
        //enable the scripts again
    }

    public void FreezeGameTime()
    {
        Time.timeScale = 0;
    }

    private void ContinueGameTime()
    {
        Time.timeScale = 1;
    }

    public void PlayVictoryScreenAnimation()
    {
        winLoseScreen.SetActive(true);
        winLoseScreenAnim.SetBool("Victory", true);
    }

    public void PlayLoseScreenAnimation()
    {
        winLoseScreen.SetActive(true);
        winLoseScreenAnim.SetBool("Lose", true);
    }

    public void CheckRoundCount()
    {
        if(turnsInRound >= totalTurnsThisRound)
        {
            roundCount++;
            turnsInRound = 0;
        }
    }



}
