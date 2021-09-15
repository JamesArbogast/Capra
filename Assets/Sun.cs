using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour {

    private float degreesInSeconds;

    void OnEnable()
    {
        GameTimeManager timeManager = GameObject.Find("GameTimeManager").GetComponent<GameTimeManager>();
        degreesInSeconds = (360f / timeManager.gameDayLengthMins * 60f);

        //EventManager.SunRotationMethods += RotateSun;
        StartCoroutine(RotateSun());
    }

    void OnDisable()
    {
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //this.transform.Rotate(new Vector3(1,0,0)); //x,y,z
	}

    /*private void RotateSun()
    {
        this.transform.Rotate(new Vector3(0, degreesInSeconds, 0));
    }*/

    private IEnumerator RotateSun()
    {
        while (true)
        {
            this.transform.Rotate(new Vector3(degreesInSeconds * Time.deltaTime, 0, 0));
            yield return null;
        }
    }
}
