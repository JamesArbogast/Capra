using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManagement : MonoBehaviour {


    public List<GameObject> HeroTeam = new List<GameObject>();

    public enum teamState
    {
        OVERWORLD,
        MENUS,
        BATTLE,
        CUTSCENE
    }



	// Use this for initialization
	void Start ()
    {
        HeroTeam.AddRange(GameObject.FindGameObjectsWithTag("Hero"));

        //initializing hero order
        HeroTeam.Sort(delegate (GameObject x, GameObject y)
        {
            return x.GetComponent<HeroStateMachine>().hero.teamOrderNumber.CompareTo(y.GetComponent<HeroStateMachine>().hero.teamOrderNumber);
        });

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SwitchTeamOrder()
    {

    }
      
}
