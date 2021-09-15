using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyStateMachine : MonoBehaviour
{


    private BattleStateMachine battleStateMachine;

    public GameObject heroGUI;

    //melee damage burst over enemy
    public GameObject meleeDamageBurst;
    //zulium damage burst over enemy
    public GameObject zuliumDamageBurst;

    public BaseEnemy enemy;
    public enum TurnState
    {
        OVERWORLD,
        HEROSKILLSCREEN,
        PROCESSING,
        WAITFORTURN,
        CHOOSEACTION,
        WAITING,
        ACTION,
        EMPTYING,
        DEAD
    }
    public TurnState currentState;

    //for intermediate use of the progress bar
    public float currentProgress = 0f;
    public float maxProgress = 10f;

    //for determining speed and turn
    private float currentSpeed;

    //for the health bar
    private float currentHealth;
    private float maxHealth;
    //this gameobject
    private Vector3 startPosition;

    //information for TimeForAction()
    private bool actionStarted = false;
    public GameObject heroToAttack;
    private float animSpeed = 10f;

    //floating number animator
    public Animator animator;
    public int damageToGive;
    public GameObject damageNumber;

    //for hidden enemy info panels
    public GameObject enemyInfoPanel;
    public EnemyHiddenPanelStats enemyStats;

    //disarming info
    public bool healthInDisarmZone;
    public bool enemyDisarmed;
    public int disarmCount;
    public float disarmStartingPoint = 0f;
    public float disarmEndPoint;
    public int turnsInDisarm;
    List<int> turnsLists = new List<int>();

    //turns
    public int turnsTaken;

    //disarm indicator
    public GameObject disarmIndicator;

    //weaknesses
    public enum Weaknesses
    {
        ZULIUM,
        LONGRANGE,
        PHYSICAL,
        EXPLOSIVES,
        SPEED,
        SWORD,
        SPEAR,
        SHIELD
    }

    //effects
    //study effects
    public bool isBeingStudied;
    public bool wasStudied;
    public bool canBeStudied;
    public int studyCount;

    public Weaknesses weaknesses;
    public Image weaknessImage;
    public bool showWeakness;

    //talk effects
    public bool isAngered;
    public bool isCalmed;
    public float originalDisarmEndPoint;
    public int angeredMeleeAttack;
    public int angeredZuliumAttack;
    public int originalMeleeAttack;
    public int originalZuliumAttack;
    public int calmedDisarmNumber;

    public List<string> talkList = new List<string>();

    //dodge
    //public GameObject quickTimeCanv;

    //dead
    private bool alive = true;

    // Use this for initialization
    void Start()
    {
        //disarm information setup
        GenerateDisarmNumber();
        disarmIndicator.SetActive(false);
        originalDisarmEndPoint = disarmEndPoint;

        //turn numbers
        turnsTaken = 0;

        //luck numbers
        angeredMeleeAttack = enemy.physAttack + 10;
        angeredMeleeAttack = enemy.zuliumAttack + 10;
        originalMeleeAttack = enemy.physAttack;
        originalZuliumAttack = enemy.zuliumAttack;

        //dodge related
        //quickTimeCanv = battleStateMachine.quickTimeCanvas;
        //quickTimeCanv.SetActive(false);

        //starting turn state
        currentState = TurnState.PROCESSING;
        battleStateMachine = GameObject.Find("BattleManager").GetComponent<BattleStateMachine>();
        
        startPosition = transform.position;
        currentSpeed = enemy.speed/10;

        enemy.allAttacks.AddRange(enemy.meleeAttacks);
        enemy.allAttacks.AddRange(enemy.zuliumAttacks);
        enemy.allAttacks.AddRange(enemy.skillAttacks);

        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "openworld" || currentScene.name == "OpeningScene")
        {
            currentState = TurnState.OVERWORLD;
        }
        else
        {
            currentState = TurnState.PROCESSING;
        }
    }

    // Update is called once per frame
    void Update()
    {

        turnsInDisarm = turnsLists.Count;

        if (isAngered)
        {
            enemy.physAttack = angeredMeleeAttack;
            enemy.zuliumAttack = angeredZuliumAttack;
        }
        else
        {
            enemy.physAttack = originalMeleeAttack;
            enemy.zuliumAttack = originalZuliumAttack;
        }

        if(isCalmed)
        {
            disarmEndPoint += 20;
        }
        else
        {
            disarmEndPoint = originalDisarmEndPoint;
        }

        if(isCalmed)
        {

        }

        if (enemy.currentHP > 0 && enemy.currentHP < disarmEndPoint)
        {
            healthInDisarmZone = true;
        }

        if (turnsInDisarm >= disarmCount)
        {
            alive = false;
            enemyDisarmed = true;
            disarmIndicator.SetActive(true);
            currentState = TurnState.DEAD;
            this.gameObject.GetComponent<SpriteRenderer>().material.color = new Color32(105, 105, 105, 255);
        }


        if(!wasStudied)
        {
            weaknessImage.sprite = battleStateMachine.weaknessImages[8];
        }

        if(wasStudied)
        {
            if (weaknesses == Weaknesses.ZULIUM)
            {
                weaknessImage.sprite = battleStateMachine.weaknessImages[0];
            }
            else if (weaknesses == Weaknesses.LONGRANGE)
            {
                weaknessImage.sprite = battleStateMachine.weaknessImages[1];
            }
            else if (weaknesses == Weaknesses.PHYSICAL)
            {
                weaknessImage.sprite = battleStateMachine.weaknessImages[2];
            }
            else if (weaknesses == Weaknesses.EXPLOSIVES)
            {
                weaknessImage.sprite = battleStateMachine.weaknessImages[3];
            }
            else if (weaknesses == Weaknesses.SPEED)
            {
                weaknessImage.sprite = battleStateMachine.weaknessImages[4];
            }
            else if (weaknesses == Weaknesses.SWORD)
            {
                weaknessImage.sprite = battleStateMachine.weaknessImages[5];
            }
            else if (weaknesses == Weaknesses.SPEAR)
            {
                weaknessImage.sprite = battleStateMachine.weaknessImages[6];
            }
            else if (weaknesses == Weaknesses.SHIELD)
            {
                weaknessImage.sprite = battleStateMachine.weaknessImages[7];
            }
        }
        

        //Debug.Log("Enemy current state: " + currentState);
        switch (currentState)
            {
            case (TurnState.OVERWORLD):

                break;
            case (TurnState.PROCESSING):
                //need code for determining player speed in order to choose the order of the actions
                if (battleStateMachine.turnQueueFilling == true)
                {
                    UpdateProgressBar();
                }
                break;

            case (TurnState.WAITFORTURN):
                //idle waiting for player to attack
                WaitForTurn();

                break;

            case (TurnState.CHOOSEACTION):
                    ChooseAction();
                currentState = TurnState.EMPTYING;
                break;

            case (TurnState.WAITING):
                //idle state
                /*if(!battleStateMachine.TurnQueue[0])
                {
                    currentState = TurnState.WAITFORTURN;
                } else if (battleStateMachine.TurnQueue[0])
                {
                    currentState = TurnState.ACTION;
                }*/
                break;

            case (TurnState.ACTION):
                StartCoroutine(TimeForAction());

                break;

            case (TurnState.EMPTYING):
                if (battleStateMachine.turnQueueEmpty == false)
                {
                    currentState = TurnState.EMPTYING;
                }
                else if (battleStateMachine.turnQueueEmpty == true)
                {
                    currentState = TurnState.PROCESSING;
                }

                break;


            case (TurnState.DEAD):
                if (!alive)
                {
                    return;
                }
                else
                {
                    //change tag
                    this.gameObject.tag = "DeadBattleEnemy";
                    //not attackable by heroes
                    battleStateMachine.EnemiesInBattle.Remove(this.gameObject);
                    battleStateMachine.TurnQueue.Remove(this.gameObject);
                    battleStateMachine.EveryoneInBattle.Remove(this.gameObject);
                    battleStateMachine.turnQueueCount--;

                    if (battleStateMachine.EnemiesInBattle.Count > 0)
                    {
                        for (int i = 0; i < battleStateMachine.PerformList.Count; i++)
                        {
                            if (battleStateMachine.PerformList[i].attackersGameObject == this.gameObject)
                            {
                            battleStateMachine.PerformList.Remove(battleStateMachine.PerformList[i]);
                            }

                            if (battleStateMachine.PerformList[i].attackersTarget == this.gameObject)
                            {
                            battleStateMachine.PerformList[i].attackersTarget = battleStateMachine.EnemiesInBattle[Random.Range(0, battleStateMachine.EnemiesInBattle.Count)];
                            }
                        }
                    }
                    //change color of game object / play dead animation
                    this.gameObject.GetComponent<SpriteRenderer>().material.color = new Color32(105, 105, 105, 255);
                    //reset buttons
                    foreach (GameObject enmyBtn in battleStateMachine.EnemyButtonsInBattle)
                    {
                        Destroy(enmyBtn);
                    }
                    battleStateMachine.EnemyButtonsInBattle.Clear();
                    battleStateMachine.EnemyButtons();
                    //check alive
                    battleStateMachine.performStates = BattleStateMachine.PerformAction.CHECKALIVE;
                    alive = false;

                }
                break;

            }

    }

    //intermediate code for determining speed
    void UpdateProgressBar()
    {
        currentProgress = (currentProgress + (Time.deltaTime / 3)) * (enemy.speed);
        if (currentProgress >= maxProgress)
        {
            battleStateMachine.TurnQueue.Add(this.gameObject);
            battleStateMachine.turnQueueCount++;
            currentState = TurnState.WAITFORTURN;
        }
    }


    void ChooseAction()
    {
        HandleTurns myAttack = new HandleTurns();
        myAttack.attacker = enemy.theName;
        myAttack.type = "Enemy";
        myAttack.attackersGameObject = this.gameObject;
        myAttack.attackersTarget = battleStateMachine.AttackableHeroes[Random.Range(0, battleStateMachine.HeroesInBattle.Count)];

        int num = Random.Range(0,enemy.allAttacks.Count);
        myAttack.chooseAttack = enemy.allAttacks[num];
        //Debug.Log(this.gameObject.name + " has chosen " + myAttack.chooseAttack.attackName + " and does " + myAttack.chooseAttack.attackDamage + " damage!");

        battleStateMachine.CollectActions(myAttack);
        //battleStateMachine.CollectHealActions(myHeal);
        //battleStateMachine.TurnQueue.Add(this.gameObject);
    }

    private IEnumerator TimeForAction()
    {    
        if (actionStarted)
        {
            yield break;
        }

        actionStarted = true;

        //animate the enemy
        Vector3 heroPosition = new Vector3(heroToAttack.transform.position.x - 1.5f, heroToAttack.transform.position.y, heroToAttack.transform.position.z); 
        while(MoveTowardsEnemy(heroPosition))
        {
            yield return null;
        }


        //wait a bit
        yield return new WaitForSeconds(0.5f);

        //do damage
        DoDamage();
        //animate back to start position
        Vector3 firstPosition = startPosition;
        while (MoveTowardsStartPosition(startPosition))
        {
            yield return null;
        }
        //remove this performer from the list in the battlestate machine
        //remove this performer from the list in the battlestate machine
        battleStateMachine.PerformList.RemoveAt(0);
        battleStateMachine.TurnQueue.RemoveAt(0);
        battleStateMachine.turnQueueCount--;
        battleStateMachine.turnsInRound++;

        turnsTaken++;
        
        //reset battlestatemachine -> wait
        if (battleStateMachine.performStates != BattleStateMachine.PerformAction.WIN && battleStateMachine.performStates != BattleStateMachine.PerformAction.LOSE)
        {

            //reset battle state machine -> WAIT
            battleStateMachine.performStates = BattleStateMachine.PerformAction.WAITING;
            //reset this enemy state
            currentProgress = 0f;

            if (healthInDisarmZone == true)
            {
                turnsTaken++;
                turnsLists.Add(1);
            }
            else
            {
                turnsTaken++;
            }

            currentState = TurnState.EMPTYING;
        }
        else
        {
            currentProgress = 0f;
            currentState = TurnState.EMPTYING;
        }
        //end coroutine
        actionStarted = false;
    }

    private bool MoveTowardsEnemy(Vector3 target)
    {
        return target != (transform.position = Vector3.MoveTowards(transform.position, target, animSpeed * Time.deltaTime)); 
    }

    private bool MoveTowardsStartPosition(Vector3 target)
    {
        return target != (transform.position = Vector3.MoveTowards(transform.position, target, animSpeed * Time.deltaTime));
    }

    void DoDamage()
    {
        Vector3 heroPosition = new Vector3(heroToAttack.transform.position.x, heroToAttack.transform.position.y + 1f, heroToAttack.transform.position.z);

        float calcDamage = enemy.physAttack + battleStateMachine.PerformList[0].chooseAttack.attackDamage;
        heroToAttack.GetComponent<HeroStateMachine>().TakeDamage(calcDamage);
        if(heroToAttack.GetComponent<HeroStateMachine>().isAbsorbing)
        {
            HeroStateMachine heroState = heroToAttack.GetComponent<HeroStateMachine>();

            heroState.AbsorbMeleeDamage(calcDamage);
            heroState.currentState = HeroStateMachine.TurnState.SKILLSCREEN;
        }

        if(heroToAttack.GetComponent<HeroStateMachine>().dodgeIsActivated)
        {
            battleStateMachine.quickTimeCanvas.SetActive(true);
            if(heroToAttack.GetComponent<HeroStateMachine>().dodgeSuccessful)
            {
                heroToAttack.GetComponent<HeroStateMachine>().TakeDamage(0);
            }
        }

        //floating numbers
        var clone = (GameObject)Instantiate(damageNumber, heroPosition, Quaternion.Euler(Vector3.zero));

        clone.GetComponent<FloatingNumbers>().damageNumber = (int) calcDamage;

        heroToAttack.GetComponent<HeroStateMachine>().UpdateHeroPanel();

        if(isBeingStudied)
        {
            studyCount++;
        }

        //update healthbar


        //if hero is using absorb
        /*if (heroToAttack.GetComponent<HeroStateMachine>().absorbActive == true)
        {
            if (battleStateMachine.PerformList[0].chooseAttack.attackType == "Zulium")
            {
                AddZuliumToSkillGuage();
            }
            else if (battleStateMachine.PerformList[0].chooseAttack.attackType == "Melee")
            {
                AddMeleeToSkillGuage();
            }
        }*/
        
    }

    public void TakeDamage(float getDamageAmount)
    {
        
        Instantiate(zuliumDamageBurst, startPosition, Quaternion.Euler(Vector3.zero));

        Vector3 enemyPosition = new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z);
        var clone = (GameObject)Instantiate(damageNumber, enemyPosition, Quaternion.Euler(Vector3.zero));
        clone.GetComponent<FloatingNumbers>().damageNumber = (int)getDamageAmount;

        enemy.currentHP -= getDamageAmount;

        if(enemy.currentHP <= 0)
        {
            enemy.currentHP = 0;
            currentState = TurnState.DEAD;
        }
    }

    private void WaitForTurn()
    {
        if (this.gameObject == battleStateMachine.TurnQueue[0])//battleStateMachine.PerformList[0].type == "Enemy")
        {
            currentState = TurnState.CHOOSEACTION;
        }
        else
        {
            currentState = TurnState.WAITFORTURN;
        }
    }

    public void CreateEnemyInfoPanels()
    {
        enemyInfoPanel = Instantiate(enemyInfoPanel) as GameObject;
        enemyStats = enemyInfoPanel.GetComponent<EnemyHiddenPanelStats>();
        enemyStats.enemyCurrentHP = enemy.currentHP;
        enemyStats.enemyBaseHP = enemy.baseHP;
        enemyStats.enemyCurrentZP = enemy.currentZP;
        enemyStats.enemyBaseZP = enemy.baseZP;
        enemyStats.enemyName = enemy.theName;

    }

    /* private void AddZuliumToSkillGuage()
     {
         float calcZuliumDamage = enemy.currentATK + battleStateMachine.PerformList[0].chooseAttack.attackDamage;
         heroToAttack.GetComponent<HeroStateMachine>().AbsorbZuliumDamage(calcZuliumDamage);
     }

     private void AddMeleeToSkillGuage()
     {
         float calcMeleeDamage = enemy.currentATK + battleStateMachine.PerformList[0].chooseAttack.attackDamage;
         heroToAttack.GetComponent<HeroStateMachine>().AbsorbMeleeDamage(calcMeleeDamage);
     }*/

    public void GenerateDisarmNumber()
    {
        disarmEndPoint = Random.Range(0, (enemy.baseHP / 2));
    }


}