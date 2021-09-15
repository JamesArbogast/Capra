using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGUI : MonoBehaviour {


    private BaseCharacterRaces class1;

	// Use this for initialization
	void Start () 
    {
        class1 = new BaseCharacterRaces();
        Debug.Log(class1.RaceName);
        Debug.Log(class1.RaceDescription);
    }
	
	// Update is called once per frame
	void Update () 
    {
    	
	}

}
