using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChaeliAttacks : MonoBehaviour {


    private EnemyBaseStats enemyStats;
    public int headbashLvlOneAttack = 10;
    public GameObject attackAnimation;


    // Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HeadBash()
    {
        enemyStats.enemyHealthPoints = -headbashLvlOneAttack;
        Instantiate(attackAnimation,transform.position, transform.rotation);
    }
}
