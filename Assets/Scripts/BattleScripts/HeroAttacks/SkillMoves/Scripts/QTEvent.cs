using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTEvent : MonoBehaviour
{

    public float fillAmount = 1;
    public float timeThresholdMax = 2;
    public float timeCurrent = 2;
    public Text letterDisplay;
    public Text successText;
    public string randomLetter;
    public bool letterClickable;
    public bool dodgeSuccessful;

    public List<string> keys = new List<string>()
    {
        "a",
        "s",
        "d",
        "w",
        "q",
        "e"
    };

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().fillAmount = timeCurrent / timeThresholdMax;
        GenerateRandomLetter();
        successText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        timeCurrent -= Time.deltaTime;
        GetComponent<Image>().fillAmount = timeCurrent / timeThresholdMax;
        letterDisplay.text = randomLetter;

        if(timeCurrent > 0)
        {
            letterClickable = true;
        }
        else if(timeCurrent <= 0)
        {
            letterClickable = false;
            timeCurrent = 0;
        }

        if(letterClickable)
        {
            if (Input.GetKeyDown(randomLetter))
            {
                Debug.Log("DODGED!");
                letterDisplay.color = new Color32(0, 255, 2, 255);
                dodgeSuccessful = true;
                SuccessfulDodge();
            }
        }
        else if(!letterClickable)
        {
            Debug.Log("DODGE FAILED!");
            letterDisplay.color = new Color32(255, 0, 0, 255);
            dodgeSuccessful = false;
        }



    }

    public void GenerateRandomLetter()
    {
        System.Random rnd = new System.Random();
        int index = rnd.Next(keys.Count);
        randomLetter = keys[index];
    }

    public void SuccessfulDodge()
    {
        this.gameObject.SetActive(false);
        GameObject.Find("QuickTimeText").SetActive(false);
        successText.gameObject.SetActive(true);

    }
}
