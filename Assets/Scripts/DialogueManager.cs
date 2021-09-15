using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour {

    public GameObject dBox;
    public Text dText;

    public bool dialogueActive;

    public List<string> dialogueLines = new List<string>();
    public int currentLine;

    public PlayerController thePlayer;

    private Scene theCurrentScene;


    // Use this for initialization
    void Start()
    {
        //dialogueLines = GameObject.Find("Player").GetComponent<DialogueManager>().dialogueLines;
        //currentLine = GameObject.Find("Player").GetComponent<DialogueManager>().dialogueLines[];
        dText.text = dialogueLines[currentLine];
        theCurrentScene = SceneManager.GetActiveScene();

        thePlayer = FindObjectOfType<PlayerController>();
        thePlayer.canMove = true;

        if (theCurrentScene.name == "OpeningScene")
        {
            thePlayer.canMove = false;
            dialogueActive = true;
            ShowBox(dialogueLines[currentLine]);
        }

	}
	
	// Update is called once per frame
	void Update () 
    {
        dText.text = dialogueLines[currentLine];

        if (dialogueActive && Input.GetKeyUp(KeyCode.H))
        {
            currentLine++;
            thePlayer.canMove = false;
        }

        if (currentLine >= dialogueLines.Count)
        {
            dBox.SetActive(false);
            dialogueActive = false;
            thePlayer.canMove = true;

            currentLine = 0;
        }

    }

    public void ShowBox(string dialogue)
    {
        dialogueActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }

    public void ShowDialogue()
    {
        dialogueActive = true;
        dBox.SetActive(true);
        thePlayer.canMove = false;
    }
}
