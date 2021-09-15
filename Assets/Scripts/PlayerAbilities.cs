using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour {

    private bool goatSpeedActive;
    public float goatSpeedTime;
    public float goatSpeedTimeCounter;
    public float goatMoveSpeed;

    private PlayerController thePC;


	// Use this for initialization
	void Start () 
    {
        thePC = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            goatSpeedTimeCounter = goatSpeedTime;
            goatSpeedActive = true;
            thePC.moveSpeed = goatMoveSpeed;
        }

        if (goatSpeedActive && goatSpeedTimeCounter >= 0)
        {
            goatSpeedTimeCounter -= Time.deltaTime;
        }

        if (goatSpeedTimeCounter <= 0)
        {
            goatSpeedActive = false;
            thePC.moveSpeed = 7;
            goatSpeedTimeCounter = goatSpeedTime;
        }
	}
}
