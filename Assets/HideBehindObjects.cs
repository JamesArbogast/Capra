using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBehindObjects : MonoBehaviour
{

    public bool hidingPossible;
    public HeroStateMachine thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = GameObject.Find("Player").GetComponent<HeroStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hidingPossible == true)
        {
            if(Input.GetKeyDown(KeyCode.Y))
            {
                thePlayer.hiding = true;
                Debug.Log("Hiding");
            }
        }
        else
        {
            thePlayer.hiding = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            hidingPossible = true;
            Debug.Log("Hiding possible.");
        }
        else
        {
            hidingPossible = false;
        }
    }


}
