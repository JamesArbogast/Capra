using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillShield : MonoBehaviour
{

    public AbsorbSkillScreen absorb;
    public GameObject pulseEffect;
    public int pulseNum = 0;
    public float pulseTime = 1;
    public GameObject liveCircle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        absorb = GameObject.Find("GameManager").GetComponent<AbsorbSkillScreen>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SkillScreenAttack")
        {

            liveCircle = collision.gameObject;
            absorb.blockable = true;
            
            if(absorb.blockable == true)
            {
                if (absorb.bracing == true)
                {
                    absorb.whiteCircleLifetime = 0;
                    Debug.Log("Bracing");
                    DestroyImmediate(collision);
                    GameObject shockwave = Instantiate(pulseEffect, collision.transform.position, Quaternion.Euler(Vector3.zero));
                    pulseNum++;
                    absorb.blockable = false;
                    DestroyPulse(shockwave);
                }
            }
            
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "SkillScreenAttack")
        {
            absorb.blockable = false;
        }
    }
    public void DestroyPulse(GameObject shockwave)
    {
        pulseTime = 1;
        pulseTime -= Time.deltaTime;
        if (pulseTime <= 0)
        {
            Debug.Log("Pulse Destroyed");
            pulseNum--;
            absorb.blockable = false;
        }
    }

    public void DestroyCircle()
    {
        absorb.whiteCircleLifetime = 0;
        Debug.Log("Bracing");
        DestroyImmediate(absorb.liveWhiteCircle);
        GameObject shockwave = Instantiate(pulseEffect, absorb.liveWhiteCircle.transform.position, Quaternion.Euler(Vector3.zero));
        pulseNum++;
        absorb.blockable = false;
        DestroyPulse(shockwave);
    }

}

