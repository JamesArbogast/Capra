using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {

    public bool isPaused;
    public GameObject pausePanel;
    public string mainMenu;
    public string displayStats;
    public string openworld;

	// Use this for initialization
	void Start () 
    {
        pausePanel.SetActive(false); 
	}
	
	// Update is called once per frame
	void Update () 
    {
		if(Input.GetButtonDown("pause"))
        {
            ChangePause();
        }
	}

    public void ChangePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void QuitToMain()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }

    public void GoToDisplayStats()
    {
        SceneManager.LoadScene(displayStats);
        Time.timeScale = 1f;     
    }
    
}
