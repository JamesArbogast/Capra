using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSlashMiniGame : MonoBehaviour
{

    public AbsorbSkillScreen absorb;
    public GameObject pulseEffect;
    public string type = "sword";

    // Start is called before the first frame update
    void Start()
    {
        absorb = GameObject.Find("GameManager").GetComponent<AbsorbSkillScreen>();
    }

    // Update is called once per frame
    void Update()
    {
        if (absorb.blockable == true && absorb.bracing == true)
        {
            GameObject shockwave = Instantiate(pulseEffect, this.transform.position, Quaternion.Euler(Vector3.zero));
            absorb.whiteCircleLifetime = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SkillScreenObject")
        {
            Debug.Log("Over!!");
            if (absorb.blockable == true)
            {
                Debug.Log("CAN BLOCK");
                if (absorb.bracing == true)
                {
                    Debug.Log("Collision!");
                    absorb.zuliumGauge += 1;
                    absorb.whiteCircleLifetime = 0;
                    Instantiate(pulseEffect, this.transform.position, Quaternion.Euler(Vector3.zero));
                    absorb.shieldWobbleAnim.SetBool("Bracing", true);
                    absorb.blockable = false;
                }
            }
        }
    }




}
