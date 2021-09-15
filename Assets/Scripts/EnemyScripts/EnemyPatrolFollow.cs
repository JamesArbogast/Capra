using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolFollow : MonoBehaviour
{

    public float speed;
    private Transform target;
    public float stoppingDistance;
    public Transform[] moveSpots;
    private int randomSpot;
    private float waitTime;
    public float startWaitTime;

    //resetting player
    public Transform playerStartPoint;
    public Transform originalEnemyPosition;
    public HeroStateMachine thePlayer;

    //sight line
    public PolygonCollider2D sightLine;

    //animation
    public Animator anim;
    public Vector2 lastMove;
    public Vector2 movementDirection;
    private Rigidbody2D myRigidBody;

    //movement types
    public bool patrolling;
    public bool chasing;
    public bool playerNotCaught;


    // Use this for initialization
    void Start()
    {

        //is the player caught by an enemy?
        playerNotCaught = true;
        //animation
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        sightLine = GetComponentInChildren<PolygonCollider2D>();
        lastMove = new Vector2(0, -1f);
        //patrol
        patrolling = true;
        chasing = false;
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);

        //resetting player
        thePlayer = GameObject.Find("Player").GetComponent<HeroStateMachine>();
        originalEnemyPosition = this.gameObject.transform;

        //chase
       
    }

    // Update is called once per frame
    void Update()
    {

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        //patrolling
        if (patrolling == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
            movementDirection = (moveSpots[randomSpot].transform.position) - transform.position;
        }

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        if (movementDirection != Vector2.zero)
        {
            myRigidBody.velocity = new Vector2(movementDirection.x * speed, movementDirection.y * speed);
            patrolling = true;
            lastMove = movementDirection;

        }
        else
        {
            myRigidBody.velocity = Vector2.zero;
        }


        //chasing
        if (chasing == true)
        {
            patrolling = false;

            if (Vector2.Distance(transform.position, target.position) >= stoppingDistance && chasing == true)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                //this.gameObject.GetComponent<SpriteRenderer>().material.color = new Color32(185, 185, 223, 1);
                if(Vector2.Distance(transform.position, target.position) <= stoppingDistance)
                {
                    thePlayer.transform.position = playerStartPoint.position;
                    this.gameObject.transform.position = originalEnemyPosition.position;
                    playerNotCaught = false;
                    chasing = false;
                    patrolling = true;
                }

            }
        }


        anim.SetFloat("MoveX", movementDirection.x);
        anim.SetFloat("MoveY", movementDirection.y);
        anim.SetBool("PlayerMoving", patrolling);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if(thePlayer.hiding == false)
            {
                if (playerNotCaught == true)
                {
                    patrolling = false;
                    chasing = true;
                }
            }
        }
    }


}