using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillScreen : MonoBehaviour
{
    public GameObject skillScreen;
    public bool skillScreenActive;
    public bool skillGameStarted;
    public bool skillGameCompleted;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(skillScreenActive == true)
        {
            ActivateSkillScreen();
        }
        else if(!skillScreenActive)
        {
            DeactivateSkillScreen();
        }
    }

    public void ActivateSkillScreen()
    {
        skillScreen.SetActive(true);
    }

    public void DeactivateSkillScreen()
    {
        skillScreen.SetActive(false);
    }

}
