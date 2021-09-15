using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {

    public int damageToGive;
    public GameObject damageBurst;
    private float currentDamage;
    public Transform hitPoint;
    public GameObject damageNumber;
    public HeroStateMachine heroStateMachine;

    //private PlayerStats thePS;

    public FadeTransitions fadeTransitions;

	// Use this for initialization
	void Start () 
    {
        heroStateMachine = FindObjectOfType<HeroStateMachine>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            // Destroy(other.gameObject);

            currentDamage = heroStateMachine.hero.currentHP;
            if (currentDamage < 0)
            {
                currentDamage = 1; 
            }

            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy((int)currentDamage);
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
            var clone = (GameObject) Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = (int)currentDamage;
            fadeTransitions.FadeToLevel(2);
        }
    }

}
