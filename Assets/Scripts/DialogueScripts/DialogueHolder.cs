using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {

    public string dialogue;
    private DialogueManager dMan;

    public List<string> dialogueLines;

    // Use this for initialization
    void Start () 
    {
        dMan = FindObjectOfType<DialogueManager>();
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    private void OnTriggerStay2D(Collider2D other)
    {
       if (other.gameObject.name == "Player") 
        {
            if (Input.GetKeyUp(KeyCode.H))
            {
                //dMan.ShowBox(dialogue);

                if (!dMan.dialogueActive)
                {
                    dMan.dialogueLines = dialogueLines;
                    dMan.currentLine = 0;
                    dMan.ShowDialogue();
                }

                if(transform.parent.GetComponent<VillagerMovement>() !=null)
                {
                    transform.parent.GetComponent<VillagerMovement>().canMove = false;
                }
            }
        }
    }
}
