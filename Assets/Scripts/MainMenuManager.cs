using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    public string newGameScene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitToDeskTop()
    {
        Application.Quit();
    }
}
