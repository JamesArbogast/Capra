using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class HurtPlayer : MonoBehaviour {

    public Animator animator;
    public int damageToGive;
    private float currentDamage;
    public GameObject damageNumber;
    public float exitTimer = 3;
    private bool starttimer;
    private HeroStateMachine heroStateMachine;
    private BattleStateMachine battleStateMachine;
    public EnemyPartyHolder enemyPartyHolder;

    //private PlayerStats thePS;

    public FadeTransitions fadeTransitions;


	// Use this for initialization
	void Start () 
    {
        heroStateMachine = FindObjectOfType<HeroStateMachine>();
        battleStateMachine = FindObjectOfType<BattleStateMachine>();
        enemyPartyHolder = this.gameObject.GetComponent<EnemyPartyHolder>();

    }
	
	// Update is called once per frame
	void Update () 
    {

	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            battleStateMachine.EnemiesInBattle = enemyPartyHolder.enemyParty;
            Debug.Log("PlayerHurt");
            currentDamage = damageToGive - heroStateMachine.hero.physDefense;

            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer((int)currentDamage);

            var clone = (GameObject)Instantiate(damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = (int)currentDamage;
            //new WaitForSeconds(2);
            Destroy(other.gameObject);
            //create new script for this with different levels with a million if statements
            fadeTransitions.FadeToLevel(3);
            Destroy(gameObject);
        }
        
    }

   
    
}
