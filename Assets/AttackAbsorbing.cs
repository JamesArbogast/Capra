using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAbsorbing : MonoBehaviour
{

    public AbsorbSkillScreen absorb;
    public int pulseNum = 0;
    public float pulseTime = 1;
    public string type = "fists";
    public Vector3 attackPos;
    public Vector3 shieldPosRadius;

    // Start is called before the first frame update
    void Start()
    {
        absorb = GameObject.Find("GameManager").GetComponent<AbsorbSkillScreen>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pulseNum <= 1)
        {
            if (absorb.blockable == true)
            {
                if(absorb.bracing == true)
                {

                }
            }
            else
            {
                absorb.blockable = false;
            }
        }


    }

}
