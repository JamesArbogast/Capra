using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PartyManager : MonoBehaviour {

    public List<GameObject> PartyMembers = new List<GameObject>();

    

    // Use this for initialization
    void Start ()
    {
        DontDestroyOnLoad(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
