using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WardrobeTrigger : MonoBehaviour {

    private DialogueManager dMan;
    private SceneOneInteractions sOneInteract;
    private PlayerController playerMove;
    public bool wardrobeTriggerEntered;

    // Use this for initialization
    void Start () {
        dMan = GameObject.Find("Player").GetComponent<DialogueManager>();
        sOneInteract = GameObject.Find("SceneManager").GetComponent<SceneOneInteractions>();
        playerMove = GameObject.Find("Player").GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
		/*if(wardrobeTriggerEntered == true && Input.GetKeyUp(KeyCode.H))
        {
            //dMan.ShowDialogue();
            //dMan.dialogueActive = true;
            //dMan.wardrobeColorChange.Stop();
            playerMove.canMove = false;
            Debug.Log("Wardrobe Triggered");
            //sOneInteract.checkPoint2 = true;
        }*/
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            wardrobeTriggerEntered = true;
            //dMan.dialogueActive = true;
            //dMan.dialogueLines = dialogueLines;
            //dMan.currentLine = 2;
            //dMan.ShowDialogue();
            //dMan.wardrobeColorChange.Stop();
            //playerMove.canMove = false;
            Debug.Log("Wardrobe Triggered");
        }
    }
}
