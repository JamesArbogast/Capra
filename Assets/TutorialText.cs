using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TutorialText : MonoBehaviour
{

    public List<string> tutorialLines = new List<string>();
    public int currentLine;
    public GameObject tutorialUI;
    public Text tText;

    public bool tutorialActive;

    public PlayerController thePlayer;

    private Scene theCurrentScene;



    // Start is called before the first frame update
    void Start()
    {
        tText.text = tutorialLines[currentLine];
        theCurrentScene = SceneManager.GetActiveScene();

        thePlayer = FindObjectOfType<PlayerController>();
        thePlayer.canMove = true;
        tutorialActive = false;
        tutorialUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        tText.text = tutorialLines[currentLine];

        if(tutorialActive == true)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                currentLine++;
            }

            ShowTutorialBox(tutorialLines[currentLine]);
            Debug.Log("Setting tutorial active");
            this.gameObject.SetActive(true);
            thePlayer.canMove = false;
        }
        else if(tutorialActive == false)
        {
            this.gameObject.SetActive(false);
            thePlayer.canMove = true;
        }
        
    }

    public void ShowTutorialBox(string dialogue)
    {
        tutorialActive = true;
        this.gameObject.SetActive(true);
        tText.text = dialogue;
    }

    public void ShowTutorialText()
    {
        tutorialUI.SetActive(true);
        tutorialActive = true;
        thePlayer.canMove = false;
    }
}
