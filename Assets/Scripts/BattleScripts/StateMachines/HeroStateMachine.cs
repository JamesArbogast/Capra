using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeroStateMachine : MonoBehaviour {

    public BattleStateMachine battleStateMachine;

    public BaseHero hero;


    public enum TurnState
    {
        OVERWORLD,
        PROCESSING,
        ADDTOLIST,
        SELECTING,
        EMPTYING,
        ACTION,
        SKILLSCREEN,
        SKILLWAITING,
        DEAD,
        WIN
    }

    public TurnState currentState;

    //for intermediate use of the progress bar
    private float currentProgress = 0f;
    private float maxProgress = 5f;
    public Image progressBar;
    public bool gamePaused;

    public GameObject selector;
    //IEnumerator
    public GameObject enemyToAttack;
    public GameObject heroToHeal;
    private bool actionStarted = false;
    private Vector3 startPosition;
    private float animSpeed = 10f;

    //dead
    private bool alive = true;

    //heroPanel
    private HeroPanelStats stats;
    public GameObject heroPanel;
    private Transform heroPanelSpacer;
    public Transform energyBarSpacer;
    public GameObject gameEnergySlot;

    //hero animations
    private Animator anim;
    public GameObject floatingAttackName;

    //camera animations
    public Animator camAnim;

    //battle FX
    [Header("BATTLE FX")]
    public GameObject basicHealingFX;
    public GameObject basicMeleeFX;

    //battle trigger
    public bool battleTriggered;

    [Header("SKILLS")]
    //skill variables
    public bool skillIsUsable;
    public int skillEffectDuration;
    public SkillScreen skillScreen;

    //study effect
    [Header("STUDY EFFECT")]
    public bool studyIsActive;

    //absorb effect
    [Header("ABSORB EFFECT")]
    public bool isAbsorbing;
    public bool isBeingGuarded;
    public int roundWhenUsed;
    public Transform guardPosition;
    public Transform guardSpot;
    public float meleeDamageAbsorbed;
    public float zuliumDamageAbsorbed;
    public int originalPhysDefense;
    public float originalSpeed;
    public AbsorbSkillScreen absorbSkillScreen;

    //luck effect
    [Header("LUCK EFFECT")]


    //dodge effect
    [Header("DODGE EFFECT")]
    public bool dodgeIsActivated;
    public int dodgeTurns;
    public bool dodgeSuccessful;

    //turn counts
    public int turnsTaken;
    public int startingSkillRoundCount;

    //critical hit
    [Header("CRITICAL HIT")]
    public bool lastAttackCritHit;

    //battle locations
    [Header("BATTLE LOCATIONS")]
    public GameObject heroBattleSlotOne;
    public GameObject heroBattleSlotTwo;
    public GameObject heroBattleSlotThree;
    public GameObject heroBattleSlotFour;
    public GameObject heroBattleSlotFive;

    //inventory
    [Header("INVENTORY")]
    public List<GameObject> HeroFullInventory = new List<GameObject>();


    [Header("EQUIPPED")]
    public GameObject equippedPrimaryWeapon;
    public GameObject equippedArmor;
    public GameObject equippedAccessory;

    //hiding behind objects
    public bool hiding;

    public TeamInventoryManagement teamInventoryManagement;

    //count the number of moves completed during a battle
    public int movesCompleted;

    //collect XP
    public int experienceCollected;

    // Use this for initialization
    void Start()
    {
        battleStateMachine = GameObject.Find("BattleManager").GetComponent<BattleStateMachine>();
        teamInventoryManagement = GameObject.Find("TeamInventoryManagement").GetComponent<TeamInventoryManagement>();
        absorbSkillScreen = GameObject.Find("SkillScreen").GetComponent<AbsorbSkillScreen>();

        turnsTaken = 0;
        camAnim = FindObjectOfType<Camera>().GetComponent<Animator>();

        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "openworld" || currentScene.name == "OpeningScene" || currentScene.name == "HallWayScene2")
        {
            currentState = TurnState.OVERWORLD;
        } else
        {
            currentState = TurnState.PROCESSING;

            //find spacer     
            heroPanelSpacer = GameObject.Find("BattleCanvas").transform.Find("HeroPanel").transform.Find("HeroPanelSpacer");

            //create panel, fill in info
            if (this.gameObject.tag == "Hero")
            {
                CreateHeroPanel();
            }
            //animation config
            anim = GetComponent<Animator>();

            startPosition = transform.position;
            currentProgress = Random.Range(0, hero.speed);
            selector.SetActive(false);
            battleStateMachine = GameObject.Find("BattleManager").GetComponent<BattleStateMachine>();
            //starting turn state
            currentState = TurnState.PROCESSING;

            //health bar config


            //all attacks on one list
            hero.allAttacks.AddRange(hero.meleeAttacks);
            hero.allAttacks.AddRange(hero.zuliumAttacks);
            hero.allAttacks.AddRange(hero.skillAttacks);
            hero.allAttacks.AddRange(hero.healMoves);
        }

        isAbsorbing = false;
        originalPhysDefense = hero.physDefense;
        originalSpeed = hero.speed;

        //connecting game paused bool to battlestate game pause

        //configuring where the hero is located in battle
        if (currentScene.name == "BattleSceneTest2")
        {
            if (hero.teamOrderNumber == 1)
            {
                this.gameObject.transform.position = heroBattleSlotOne.transform.position;
            }
            else if (hero.teamOrderNumber == 2)
            {
                this.gameObject.transform.position = heroBattleSlotTwo.transform.position;
            }
            else if (hero.teamOrderNumber == 3)
            {
                this.gameObject.transform.position = heroBattleSlotThree.transform.position;
            }
            else if (hero.teamOrderNumber == 4)
            {
                this.gameObject.transform.position = heroBattleSlotFour.transform.position;
            }
            else if (hero.teamOrderNumber == 5)
            {
                this.gameObject.transform.position = heroBattleSlotFive.transform.position;
            }

            /* if (hero.teamOrderNumber == 0)
             {
                 energyBarSpacer = GameObject.Find("EnergyBarFill").GetComponent<Transform>();
             }
             else if (hero.teamOrderNumber == 1)
             {
                 energyBarSpacer = GameObject.Find("EnergyBarFill").GetComponent<Transform>();
             }
             else if (hero.teamOrderNumber == 2)
             {
                 energyBarSpacer = GameObject.Find("EnergyBarFill").GetComponent<Transform>();
             }
             else if (hero.teamOrderNumber == 3)
             {
                 energyBarSpacer = GameObject.Find("EnergyBarFill").GetComponent<Transform>();
             }
             else if (hero.teamOrderNumber == 4)
             {
                 energyBarSpacer = GameObject.Find("EnergyBarFill").GetComponent<Transform>();
             }*/
        }

        //paused game

        //heros equipped weapons
        UpdateEquippedItems();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHeroPanel();
        UpdateEquippedItems();

        if (battleStateMachine.EnemiesInBattle.Count == 0)
        {
            currentState = TurnState.WIN;
        }

        if (this.gameObject)

            //switch cases for the different states that the player faces during battle
            //Debug.Log("Hero Current state: " + currentState);
            switch (currentState)
            {
                case (TurnState.OVERWORLD):

                    break;

                case (TurnState.PROCESSING):
                    //need code for determining player speed in order to choose the order of the actions
                    PlayIdleAnimation();

                    if (!gamePaused)
                    {
                        if (this.gameObject.tag == "Hero")
                        {
                            if (battleStateMachine.turnQueueFilling == true)
                            {
                                UpdateProgressBar();
                            }
                        }
                    }

                    if (isAbsorbing)
                    {
                        currentState = TurnState.SKILLWAITING;
                    }

                    if (studyIsActive)
                    {
                        currentState = TurnState.SKILLWAITING;
                    }

                    if(dodgeIsActivated)
                    {
                        currentState = TurnState.SKILLWAITING;
                    }

                    // UpdateHeroPanel();
                    break;

                case (TurnState.ADDTOLIST):
                    if (this.gameObject.tag == "Hero")
                    {
                        battleStateMachine.HeroesToManage.Add(this.gameObject);
                        battleStateMachine.TurnQueue.Add(this.gameObject);
                    }
                    currentState = TurnState.SELECTING;
                    break;

                case (TurnState.SELECTING):

                    break;

                case (TurnState.ACTION):
                    StartCoroutine(TimeForAction());
                    break;

                case (TurnState.EMPTYING):
                    if (battleStateMachine.turnQueueEmpty == false)
                    {
                        currentProgress = 0f;
                        currentState = TurnState.EMPTYING;
                    }
                    else if (battleStateMachine.turnQueueEmpty == true)
                    {

                        currentProgress = 0f;
                        currentState = TurnState.PROCESSING;
                    }

                    break;

                case (TurnState.SKILLSCREEN):

                    skillScreen.skillScreenActive = true;
                    battleStateMachine.heroGUIOn = false;
                    //battleStateMachine.FreezeGameTime();
                    battleStateMachine.fullBattleCanvas.SetActive(false);

                    return;

                case (TurnState.SKILLWAITING):

                    if (studyIsActive)
                    {
                        if (battleStateMachine.EnemyBeingStudied[0].GetComponent<EnemyStateMachine>().studyCount >= skillEffectDuration)
                        {
                            battleStateMachine.HeroesInBattle.Add(this.gameObject);
                            battleStateMachine.HeroesToManage.Add(this.gameObject);
                            battleStateMachine.EveryoneInBattle.Add(this.gameObject);
                            battleStateMachine.HeroesStudying.Remove(this.gameObject);
                            battleStateMachine.EnemyBeingStudied[0].GetComponent<EnemyStateMachine>().isBeingStudied = false;
                            battleStateMachine.EnemyBeingStudied[0].GetComponent<EnemyStateMachine>().wasStudied = true;
                            battleStateMachine.EnemyBeingStudied[0].GetComponent<EnemyStateMachine>().canBeStudied = false;
                            battleStateMachine.EnemyBeingStudied[0].GetComponent<EnemyStateMachine>().studyCount = 0;
                            battleStateMachine.EnemyBeingStudied.Clear();
                            studyIsActive = false;

                            currentState = TurnState.PROCESSING;
                        }


                        return;
                    }

                    if (isAbsorbing)
                    {
                        int currentRound = battleStateMachine.roundCount;
                        this.gameObject.GetComponent<SpriteRenderer>().material.color = new Color32(65, 212, 255, 255);
                        this.gameObject.GetComponent<Transform>().position = new Vector3(guardSpot.position.x, guardSpot.position.y, guardSpot.position.z);

                        if (skillEffectDuration <= currentRound - roundWhenUsed)
                        {
                            hero.physDefense -= 10;
                            this.gameObject.GetComponent<SpriteRenderer>().material.color = new Color32(255, 255, 255, 255);
                            this.gameObject.GetComponent<Transform>().position = new Vector3(startPosition.x, startPosition.y, startPosition.z);
                            battleStateMachine.HeroesInBattle.Add(this.gameObject);
                            battleStateMachine.HeroesToManage.Add(this.gameObject);
                            battleStateMachine.EveryoneInBattle.Add(this.gameObject);
                            battleStateMachine.HeroesAbsorbing.Remove(this.gameObject);
                            battleStateMachine.HeroBeingGuarded[0].GetComponent<HeroStateMachine>().isBeingGuarded = false;
                            isAbsorbing = false;

                            currentState = TurnState.PROCESSING;
                        }

                        return;
                    }

                    if(dodgeIsActivated)
                    {
                        int currentRound = battleStateMachine.roundCount;
                        this.gameObject.GetComponent<SpriteRenderer>().material.color = new Color32(65, 212, 255, 255);
                        
                        if(skillEffectDuration <= currentRound - roundWhenUsed)
                        {
                            this.gameObject.GetComponent<SpriteRenderer>().material.color = new Color32(255, 255, 255, 255);
                            battleStateMachine.HeroesInBattle.Add(this.gameObject);
                            battleStateMachine.HeroesToManage.Add(this.gameObject);
                            battleStateMachine.EveryoneInBattle.Add(this.gameObject);
                            battleStateMachine.HeroesAbsorbing.Remove(this.gameObject);
                        }
                    }

                    break;

     
                case (TurnState.DEAD):
                if (!alive)
                {
                    return;
                }
                else
                {
                    //play death animation

                    PlayDeathAnimation();
                    //change tag
                    this.gameObject.tag = "DeadBattlePlayer";
                    //not attackable by enemy
                    battleStateMachine.HeroesInBattle.Remove(this.gameObject);
                    //not managable hero
                    battleStateMachine.HeroesToManage.Remove(this.gameObject);
                    battleStateMachine.EveryoneInBattle.Remove(this.gameObject);
                    battleStateMachine.AttackableHeroes.Remove(this.gameObject);
                    //deactivate the selector
                    selector.SetActive(false);
                    //reset GUI
                    battleStateMachine.actionPanel.SetActive(false);
                    battleStateMachine.enemySelectPanel.SetActive(false);
                    //remove item from performlist

                    if (battleStateMachine.HeroesInBattle.Count > 0)
                    {
                        for (int i = 0; i < battleStateMachine.PerformList.Count; i++)
                        {
                            if (battleStateMachine.PerformList[i].attackersGameObject == this.gameObject)
                            {
                                battleStateMachine.PerformList.Remove(battleStateMachine.PerformList[i]);
                            }

                            if (battleStateMachine.PerformList[i].attackersTarget == this.gameObject)
                            {
                                battleStateMachine.PerformList[i].attackersTarget = battleStateMachine.HeroesInBattle[Random.Range(0, battleStateMachine.HeroesInBattle.Count)];
                            }
                        }
                    }
                    //change color of game object / play dead animation
                    this.gameObject.GetComponent<SpriteRenderer>().material.color = new Color32(105, 105, 105, 255);
                    //reset heroinput
                    battleStateMachine.performStates = BattleStateMachine.PerformAction.CHECKALIVE;
                    alive = false;
                }

                break;
        }

        //battleStateMachine.gamePaused = gamePaused;
    }

    //intermediate code for determining speed
    void UpdateProgressBar()
    {

        //progress bar config
        currentProgress = (currentProgress + (Time.deltaTime/3)) * (hero.speed);
        float calculateProgress = currentProgress / maxProgress;

        // visual aspect
        //progressBar.transform.localScale = new Vector3(Mathf.Clamp(calculateProgress, 0, 1), progressBar.transform.localScale.y, progressBar.transform.localScale.z);

        // if full add to the perform list
        if (currentProgress >= maxProgress)
        {
           if(battleStateMachine.turnQueueFilling == true)
           {
               currentState = TurnState.ADDTOLIST;
                battleStateMachine.turnQueueCount++;
            }
           else if(battleStateMachine.turnQueueFull == true)
           {
                currentState = TurnState.PROCESSING;
           }
            //currentState = TurnState.ADDTOLIST;
        }
        
    }

    private IEnumerator TimeForAction()
    {
        battleStateMachine.PerformList.Equals(0);
        if (actionStarted)
        { 
            yield break;
        }

        actionStarted = true;

        //animate the hero
        PlayAttackAnimation();
        //wait a bit
        yield return new WaitForSeconds(0.5f);
        //do damage and account for attack cost
        if (battleStateMachine.PerformList[0].chooseAttack.attackType == "Heal")
        {
            DoHeal();
        }
        else if (battleStateMachine.PerformList[0].chooseAttack.attackType == "Melee")
        {
            DoDamage();
        }
        else if (battleStateMachine.PerformList[0].chooseAttack.attackType == "Skill")
        {
            DoSkill();
        }
        else
        {
            DoDamage();
        }

        /*Vector3 enemyPosition = new Vector3(enemyToAttack.transform.position.x + 1.5f, enemyToAttack.transform.position.y, enemyToAttack.transform.position.z);
        while (MoveTowardsEnemy(enemyPosition))
        {
            yield return null;
        }*/

        ResetCriticalHitDmg();
        

        //animate back to start position
        Vector3 firstPosition = startPosition;

        //whiile (MoveTowardsStartPosition(startPosition))
        //{
            //yield return null;
        //}

        //remove this performer from the list in the battlestate machine
        battleStateMachine.PerformList.RemoveAt(0);

        //reset battle state machine -> WAIT
        battleStateMachine.performStates = BattleStateMachine.PerformAction.WAITING;
        //end coroutine
        actionStarted = false;
        //reset this enemy state
        currentProgress = 0f;
        turnsTaken++;
        if(isAbsorbing || studyIsActive)
        {
            currentState = TurnState.SKILLWAITING;
        }
        else
        {
            currentState = TurnState.EMPTYING;
        }

        

    }

    private bool MoveTowardsEnemy(Vector3 target)
    {
        return target != (transform.position = Vector3.MoveTowards(transform.position, target, animSpeed * Time.deltaTime));
    }

    private bool MoveTowardsStartPosition(Vector3 target)
    {
        return target != (transform.position = Vector3.MoveTowards(transform.position, target, animSpeed * Time.deltaTime));
    }

    public void TakeDamage(float getDamageAmount)
    {
        if(isBeingGuarded)
        {
            skillScreen.ActivateSkillScreen();
            absorbSkillScreen.absorbSkilScreenActive = true;
            battleStateMachine.HeroesAbsorbing[0].GetComponent<HeroStateMachine>().TakeDamage(getDamageAmount);
            skillScreen.skillScreenActive = true;
        }
        else
        {
            hero.currentHP -= (getDamageAmount / ((hero.physDefense) / 3));

            if (hero.currentHP <= 0)
            {
                hero.currentHP = 0;
                currentState = TurnState.DEAD;
            }

            PlayHurtAnimation();
            BeginKick();
            Instantiate(basicMeleeFX, startPosition, Quaternion.Euler(Vector3.zero));
        }

        if(isAbsorbing)
        {
            skillScreen.ActivateSkillScreen();
            absorbSkillScreen.absorbSkilScreenActive = true;
            skillScreen.skillScreenActive = true;
        }

    }

    public void GetHeal(float getHealAmount)
    {
        Instantiate(basicHealingFX, startPosition, Quaternion.Euler(Vector3.zero));

        hero.currentHP += getHealAmount;

        if(hero.currentHP >= hero.baseHP)
        {
            hero.currentHP = hero.baseHP;
        }
    }

    //do damage
    void DoDamage()
    {

        //display name of attack
        Vector3 middleScreen = new Vector3(2f, -4.8f, 0f);
        //Debug.Log(battleStateMachine.PerformList[0].chooseAttack.name);
        var attackName = (GameObject)Instantiate(floatingAttackName, middleScreen, Quaternion.Euler(Vector3.zero));
        attackName.GetComponent<AttackFloatingName>().attackName = battleStateMachine.PerformList[0].chooseAttack.attackName;

        //calculate damage
        float calcDamage = hero.currentATK + battleStateMachine.PerformList[0].chooseAttack.attackDamage;
        enemyToAttack.GetComponent<EnemyStateMachine>().TakeDamage(calcDamage);

        //lose Zulium energy
        if (battleStateMachine.PerformList[0].chooseAttack.attackType == "Zulium")
        {
            LoseZulium();
        }

        //calc critical hit
        CalcCriticalHit();

        Debug.Log(battleStateMachine.PerformList[0].chooseAttack.name);


        if(battleStateMachine.PerformList[0].chooseAttack.attackName == "Study")
        {
            enemyToAttack.GetComponent<EnemyStateMachine>().showWeakness = true;
        }

        //Instantiate()

    }

    void DoHeal()
    {
        AddXp(1);
        Debug.Log("Adding EXP");
        float calcHeal = hero.zuliumHeal + battleStateMachine.PerformList[0].chooseAttack.healAmount;
        heroToHeal.GetComponent<HeroStateMachine>().GetHeal(calcHeal);
        if (battleStateMachine.PerformList[0].chooseAttack.attackType == "Heal")
        {
            LoseZulium();
        }
        //heroToHeal.GetComponent<HeroStateMachine>.GetHeal
    }

    void DoSkill()
    {

        //display name of attack
        Vector3 middleScreen = new Vector3(2f, -4.8f, 0f);
        var attackName = (GameObject)Instantiate(floatingAttackName, middleScreen, Quaternion.Euler(Vector3.zero));
        attackName.GetComponent<AttackFloatingName>().attackName = battleStateMachine.PerformList[0].chooseAttack.attackName;

        BaseAttack currentSkillMove = battleStateMachine.PerformList[0].chooseAttack;

        startingSkillRoundCount = battleStateMachine.roundCount;

        if(currentSkillMove.skillType == BaseAttack.SkillType.EnemyTeamChoosePassive)
        {
            skillEffectDuration = currentSkillMove.skillEffectTurns;
            currentSkillMove.attackDamage = 0;
        }
        if(currentSkillMove.skillType == BaseAttack.SkillType.EnemyFullTeamPassive)
        {
            currentSkillMove.attackDamage = 0;
        }
        if(currentSkillMove.skillType == BaseAttack.SkillType.HeroIndividualChoicePassiveNotPlayer)
        {
            skillEffectDuration = currentSkillMove.skillEffectTurns;
            currentSkillMove.attackDamage = 0;
        }
        if(currentSkillMove.skillType == BaseAttack.SkillType.SelfActive)
        {
            skillEffectDuration = currentSkillMove.skillEffectTurns;
            currentSkillMove.attackDamage = 0;
        }

        if(currentSkillMove.attackName == "Study")
        {
            GameObject selectedEnemy = battleStateMachine.PerformList[0].attackersTarget;
            selectedEnemy.GetComponent<EnemyStateMachine>().isBeingStudied = true;
            studyIsActive = true;
            battleStateMachine.EnemyBeingStudied.Add(selectedEnemy);
            StudySkillLists();
        }
        if(currentSkillMove.attackName == "Absorb")
        {
            guardSpot = battleStateMachine.PerformList[0].attackersTarget.GetComponent<HeroStateMachine>().guardPosition; guardPosition = battleStateMachine.PerformList[0].attackersTarget.GetComponent<HeroStateMachine>().guardPosition;
            hero.physDefense += 10;
            roundWhenUsed = battleStateMachine.roundCount;
            GameObject selectedHero = battleStateMachine.PerformList[0].attackersTarget;
            selectedHero.GetComponent<HeroStateMachine>().isBeingGuarded = true;
            isAbsorbing = true;
            battleStateMachine.HeroBeingGuarded.Add(selectedHero);
            AbsorbSkillLists();

        }
        if(currentSkillMove.attackName == "Luck")
        {

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            int luckyNumber = Random.Range(0, 100);
            GameObject selectedEnemy = battleStateMachine.PerformList[0].attackersTarget;
            selectedEnemy =  battleStateMachine.EnemiesInBattle[0];

            if(luckyNumber <= 50)
            {
                battleStateMachine.enemiesCalmedLevel1 = true;
            }
            if(luckyNumber > 50)
            {
                battleStateMachine.enemiesAngeredLevel1 = true;
            }
        }
        if(currentSkillMove.attackName == "Dodge")
        {
            GameObject selectedHero = battleStateMachine.PerformList[0].attackersTarget;
            selectedHero = this.gameObject;
            roundWhenUsed = battleStateMachine.roundCount;
            dodgeIsActivated = true;
        }

        //calculate damage
        //float calcDamage = hero.currentATK + battleStateMachine.PerformList[0].chooseAttack.attackDamage;
        //enemyToAttack.GetComponent<EnemyStateMachine>().TakeDamage(calcDamage);

        //calc critical hit
        CalcCriticalHit();

    }

    public void AddXp(int battleXp)
    {
        experienceCollected += battleXp;
    }

    //create a hero panel
    public void CreateHeroPanel()
    {
        heroPanel = Instantiate(heroPanel) as GameObject;
        stats = heroPanel.GetComponent<HeroPanelStats>();
        stats.heroCurrentHP = hero.currentHP;
        stats.heroBaseHP = hero.baseHP;
        stats.heroCurrentZP = hero.currentZP;
        stats.heroBaseZP = hero.baseZP;
        stats.heroBaseEnergy = hero.baseEnergy;
        stats.heroCurrentEnergy = hero.currentEnergy;
        stats.heroName.text = hero.theName;
        stats.heroHP.text = "HP: " + hero.currentHP + "/" + hero.baseHP;
        stats.heroZP.text = "ZP: " + hero.currentZP + "/" + hero.baseZP;
        stats.heroHealthBar.maxValue = hero.baseHP;
        stats.heroHealthBar.value = hero.currentHP;
        stats.heroZuliumBar.maxValue = hero.baseZP;
        stats.heroZuliumBar.value = hero.currentZP;
        stats.heroSkillBar.value = hero.absorbCurrentAmount;
        stats.heroSkillBar.maxValue = hero.absorbMaxAmount;

        if(hero.absorbCurrentAmount >= hero.absorbMaxAmount)
        {
            //stats.heroSkillBar.colors = new Color32()
        }

        //stat
        

        if(hero.skillGuageIsNeeded == true)
        {
            stats.heroSkillBar.value = hero.absorbCurrentAmount;
            stats.heroSkillBar.maxValue = hero.absorbMaxAmount;
        }
        else
        {
            GameObject.Find("SkillBarFill").SetActive(false);
            GameObject.Find("SkillBarBackground").SetActive(false);
            GameObject.Find("SkillBarBorder").SetActive(false);
        }

        /*for (int i = 0; i < hero.baseEnergy; i++)
        {
            GameObject yellowBlock = Instantiate(gameEnergySlot) as GameObject;
            yellowBlock.transform.SetParent(energyBarSpacer, false);
        }*/

        heroPanel.transform.SetParent(heroPanelSpacer, false);

    }

    public void UpdateHeroPanel()
    {
        stats = heroPanel.GetComponent<HeroPanelStats>();
        stats.heroCurrentHP = hero.currentHP;
        stats.heroHealthBar.value = hero.currentHP;
        stats.heroCurrentZP = hero.currentZP;
        stats.heroZuliumBar.value = hero.currentZP;
        stats.heroCurrentEnergy = hero.currentEnergy;
        stats.heroHP.text = "HP: " + hero.currentHP + "/" + hero.baseHP;
        stats.heroZP.text = "ZP: " + hero.currentZP + "/" + hero.baseZP;
        stats.heroSkillBar.value = hero.absorbCurrentAmount;

        if (hero.skillGuageIsNeeded == true)
        {
            stats.heroSkillBar.value = hero.absorbCurrentAmount;
            stats.heroSkillBar.maxValue = hero.absorbMaxAmount;
        }


        //code for changing the color of the active attacker
        /*if (this.gameObject.name == battleStateMachine.TurnQueue[0].GetComponent<HeroStateMachine>().hero.theName)
        {
            heroPanel.GetComponent<Image>().color = new Color(46, 46, 46);
        }*/

    }

    public void LoseZulium()
    {
        this.gameObject.GetComponent<HeroStateMachine>().hero.currentZP -= battleStateMachine.PerformList[0].chooseAttack.attackCost;
    }     

    public void PlayIdleAnimation()
    {
        anim.SetBool("Grounded", true);
    }

    public void PlayAttackAnimation()
    {
        anim.SetBool("Grounded", false);
        anim.SetBool("Attack", true);
    }

    public void PlayHurtAnimation()
    {
        anim.SetBool("Grounded", false);
        anim.SetBool("Attack", false);
        anim.SetBool("Hurt", true);
    }

    public void PlayDeathAnimation()
    {
        anim.SetBool("Death", true);
        anim.SetBool("Grounded", false);
        anim.SetBool("Attack", false);
        anim.SetBool("Hurt", false);
    }

    public void OverworldFunctions()
    {
        //remove any variables and functions running during battle.
        //Add new functions that would be used for the overworld.
    }

    //collect attack into perform list

    //collecting the amount of melee damage taken while doing the skill move Absorb
    public void AbsorbMeleeDamage(float getAbsorbMeleeAmount)
    {
        hero.absorbCurrentAmount += getAbsorbMeleeAmount;
        Debug.Log( "Hero is taking: " + getAbsorbMeleeAmount + " damage.");
    }

    public void AbsorbZuliumDamage(float getAbsorbZuliumAmount)
    {
        hero.absorbCurrentAmount += (getAbsorbZuliumAmount * 2);
        Debug.Log("Hero is taking: " + getAbsorbZuliumAmount + " damage.");
    }

    public void BeginKick()
    {
        camAnim.SetBool("kickActive", true);
        StartCoroutine(KickCo());
    }

    public IEnumerator KickCo()
    {
        yield return null;
        camAnim.SetBool("kickActive", false);
    }

    public void CalcCriticalHit()
    {
        if(hero.luck * Random.Range((battleStateMachine.PerformList[0].chooseAttack.critHitChance/5), 15) > 50)
        {
            battleStateMachine.PerformList[0].chooseAttack.attackDamage += battleStateMachine.PerformList[0].chooseAttack.critHitDmg;
            Debug.Log("Critical Hit!");
            //critical hit animation
            lastAttackCritHit = true;
        }
    }

    public void ResetCriticalHitDmg()
    {
        if(lastAttackCritHit == true)
        {
            battleStateMachine.PerformList[0].chooseAttack.attackDamage -= battleStateMachine.PerformList[0].chooseAttack.critHitDmg;
            lastAttackCritHit = false;
        }
    }

    public void UpdateEquippedItems()
    {
        if (hero.theName == "Chaeli")
        {
            equippedPrimaryWeapon = teamInventoryManagement.chaeliWeapons[0];
            equippedArmor = teamInventoryManagement.chaeliArmors[0];
            equippedAccessory = teamInventoryManagement.chaeliAccessories[0];
        }
        else if (hero.theName == "Lon")
        {
            equippedPrimaryWeapon = teamInventoryManagement.lonWeapons[0];
            equippedArmor = teamInventoryManagement.lonArmors[0];
            equippedAccessory = teamInventoryManagement.lonAccessories[0];
        }
        else if (hero.theName == "Piyryl")
        {
            equippedPrimaryWeapon = teamInventoryManagement.piyrylWeapons[0];
            equippedArmor = teamInventoryManagement.piyrylArmors[0];
            equippedAccessory = teamInventoryManagement.piyrylAccessories[0];
        }
        else if (hero.theName == "Alx")
        {
            equippedPrimaryWeapon = teamInventoryManagement.alxWeapons[0];
            equippedArmor = teamInventoryManagement.alxArmors[0];
            equippedAccessory = teamInventoryManagement.alxAccessories[0];
        }
    }

    public void StudySkillLists()
    {
        //not attackable by enemy
        battleStateMachine.HeroesInBattle.Remove(this.gameObject);
        //not managable hero
        battleStateMachine.HeroesToManage.Remove(this.gameObject);
        //removed from counts
        battleStateMachine.EveryoneInBattle.Remove(this.gameObject);
        //adds to studying list
        battleStateMachine.HeroesStudying.Add(this.gameObject);

        currentState = TurnState.SKILLWAITING;
    }

    public void AbsorbSkillLists()
    {
        //not attackable by enemy
        battleStateMachine.HeroesInBattle.Remove(this.gameObject);
        //not managable hero
        battleStateMachine.HeroesToManage.Remove(this.gameObject);
        //removed from counts
        battleStateMachine.EveryoneInBattle.Remove(this.gameObject);
        //adds to absorbing list
        battleStateMachine.HeroesAbsorbing.Add(this.gameObject);

        currentState = TurnState.SKILLWAITING;
    }

    public void DodgeSkillLists()
    {
        //not attackable by enemy
        battleStateMachine.HeroesInBattle.Remove(this.gameObject);
        //not managable hero
        battleStateMachine.HeroesToManage.Remove(this.gameObject);
        //removed from counts
        battleStateMachine.EveryoneInBattle.Remove(this.gameObject);
        //adds to absorbing list
        battleStateMachine.HeroesAbsorbing.Add(this.gameObject);

        currentState = TurnState.SKILLWAITING;
    }
}
