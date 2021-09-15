using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbsorbSkillScreen : MonoBehaviour
{
    public float skillScreenTimer;
    public float braceGauge;
    public float zuliumGauge;
    public bool absorbSkilScreenActive;
    Vector3 mousePos;
    public GameObject shieldObject;
    public enum AttackType
    {
        FISTS,
        SWORD
    }

    public AttackType attackType;

    public GameObject[] attacks;
    public GameObject whiteCircle;
    public GameObject swordSlash;
    public GameObject background;
    public int attacksCreatedNumber;
    public bool attackCreated;
    public float whiteCircleLifetime;
    public float originalWhiteCircleLifetime;
    public GameObject liveWhiteCircle;
    public Slider gameTimer;
    public Slider braceGaugeFill;
    public Slider zuliumGaugeFill;
    public Animator shieldWobbleAnim;
    public bool bracing;
    public bool blockable;
    private int attackMovement;
    private Rigidbody2D circleRigidbody;

    //attack movement
    public float attackMoveSpeed;
    public float moveTime;
    private bool isMoving;
    [SerializeField] public Collider2D moveZone;
    public bool hasMoveZone;
    private Vector2 minMovePoint;
    private Vector2 maxMovePoint;



    // Start is called before the first frame update
    void Start()
    {
        skillScreenTimer = 10;
        braceGauge = 5;
        zuliumGauge = 0;
        attacksCreatedNumber = 0;
        whiteCircleLifetime = Random.Range(1, 2.5f);
        originalWhiteCircleLifetime = whiteCircleLifetime;
        gameTimer.maxValue = skillScreenTimer;
        braceGaugeFill.maxValue = braceGauge;
        zuliumGaugeFill.maxValue = 7;

        if (moveZone != null)
        {
            minMovePoint = moveZone.bounds.min;
            maxMovePoint = moveZone.bounds.max;
            hasMoveZone = true;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if(absorbSkilScreenActive)
        {
            //timer
            gameTimer.value = skillScreenTimer;
            braceGaugeFill.value = braceGauge;
            zuliumGaugeFill.value = zuliumGauge;

            //shield position
            Vector3 offset = new Vector3(0, 0, 9);
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            shieldObject.transform.position = mousePos;
            //mousePos.z = transform.position.z - Camera.main.transform.position.z;
            //shieldObject.transform.position = Camera.main.ScreenToWorldPoint(mousePos);

            //time bar
            if (skillScreenTimer > 0)
            {
                skillScreenTimer -= Time.deltaTime;
                Vector3 randomSpawn = new Vector3(Random.Range(-3.5f, 3.5f), Random.Range(-2.5f, 2.5f),-10);

                //creating attack objects

                if(!attackCreated)
                {
                    switch(attackType)
                    {

                        case (AttackType.FISTS):
                            GameObject newWhiteCircle = Instantiate(whiteCircle, randomSpawn, Quaternion.identity);
                            liveWhiteCircle = newWhiteCircle;

                            break;

                        case (AttackType.SWORD):

                            break;
                    }

                    circleRigidbody = liveWhiteCircle.GetComponent<Rigidbody2D>();
                    attackMovement = Random.Range(0, 7);
                    attacksCreatedNumber++;
                    if(attacksCreatedNumber > 0)
                    {
                        attackCreated = true;
                    }
                }
                else if(attackCreated)
                {
                    attackCreated = true;
                    whiteCircleLifetime -= Time.deltaTime;
                    circleRigidbody = liveWhiteCircle.GetComponent<Rigidbody2D>();
                }

                if(whiteCircleLifetime < (originalWhiteCircleLifetime / 2) && whiteCircleLifetime > (originalWhiteCircleLifetime / 3))
                {
                    Vector3 scaleChange = new Vector3(5.5f, 5.5f, 5.5f);
                    SpriteRenderer circleColor = liveWhiteCircle.GetComponent<SpriteRenderer>();

                    liveWhiteCircle.transform.localScale = scaleChange;
                    circleColor.color = new Color32(209, 112, 27, 255);
                }
                else if (whiteCircleLifetime < (originalWhiteCircleLifetime / 3))
                {
                    Vector3 scaleChange = new Vector3(7.5f, 7.5f, 7.5f);
                    SpriteRenderer circleColor = liveWhiteCircle.GetComponent<SpriteRenderer>();

                    liveWhiteCircle.transform.localScale = scaleChange;
                    circleColor.color = new Color32(255, 20, 20, 255);
                }

                if (whiteCircleLifetime <= 0)
                {
                    Destroy(liveWhiteCircle);
                    attackCreated = false;
                    whiteCircleLifetime = Random.Range(0, 2);
                    blockable = false;
                }

                if(attackType == AttackType.FISTS)
                {
                    switch (attackMovement)
                    {
                        case 0:
                            circleRigidbody.velocity = new Vector2(0, attackMoveSpeed);
                            if (hasMoveZone && transform.position.y > maxMovePoint.y)
                            {
                                isMoving = false;
                                ChooseDirection();
                            }
                            break;

                        case 1:
                            circleRigidbody.velocity = new Vector2(attackMoveSpeed, 0);
                            if (hasMoveZone && transform.position.x > maxMovePoint.x)
                            {
                                isMoving = false;
                                ChooseDirection();
                            }
                            break;

                        case 2:
                            circleRigidbody.velocity = new Vector2(0, -attackMoveSpeed);
                            if (hasMoveZone && transform.position.y < minMovePoint.y)
                            {
                                isMoving = false;
                                ChooseDirection();
                            }
                            break;

                        case 3:
                            circleRigidbody.velocity = new Vector2(-attackMoveSpeed, 0);
                            if (hasMoveZone && transform.position.x < minMovePoint.x)
                            {
                                isMoving = false;
                                ChooseDirection();
                            }
                            break;

                        case 4:
                            circleRigidbody.velocity = new Vector2(attackMoveSpeed, attackMoveSpeed);
                            if (hasMoveZone && transform.position.x > maxMovePoint.x || hasMoveZone && transform.position.y > maxMovePoint.y)
                            {
                                isMoving = false;
                                ChooseDirection();
                            }
                            break;
                        case 5:
                            circleRigidbody.velocity = new Vector2(-attackMoveSpeed, attackMoveSpeed);
                            if (hasMoveZone && transform.position.x < minMovePoint.x || hasMoveZone && transform.position.y > maxMovePoint.y)
                            {
                                isMoving = false;
                                ChooseDirection();
                            }
                            break;
                        case 6:
                            circleRigidbody.velocity = new Vector2(attackMoveSpeed, -attackMoveSpeed);
                            if (hasMoveZone && transform.position.x > maxMovePoint.x || hasMoveZone && transform.position.y < minMovePoint.y)
                            {
                                isMoving = false;
                                ChooseDirection();
                            }
                            break;
                        case 7:
                            circleRigidbody.velocity = new Vector2(-attackMoveSpeed, -attackMoveSpeed);
                            if (hasMoveZone && transform.position.x < minMovePoint.x || hasMoveZone && transform.position.y < minMovePoint.y)
                            {
                                isMoving = false;
                                ChooseDirection();
                            }
                            break;
                    }

                }

            }
            else
            {
                absorbSkilScreenActive = false;
            }

            if(Input.GetKey(KeyCode.Mouse0))
            {
                ReduceBraceGuage();
                bracing = true;
            }
            else
            {
                bracing = false;
            }

            if(bracing == true)
            {
                shieldWobbleAnim.SetBool("Bracing", true);
            }
            if(bracing == false)
            {
                shieldWobbleAnim.SetBool("Bracing", false);
            }


        }

    }

    public void ReduceBraceGuage()
    {
        braceGauge -= Time.deltaTime;
    }


    public void StopBraceGuage()
    {
        
    }

    public void ChooseDirection()
    {
        attackMovement = Random.Range(0, 4);
        isMoving = true;
    }

}
