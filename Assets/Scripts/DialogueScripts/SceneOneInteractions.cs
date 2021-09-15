using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneOneInteractions : MonoBehaviour {



    public DialogueManager theDM;
    public TutorialText tutorialText;

    private Scene theCurrentScene;

    public bool checkPoint1;
    public bool checkPoint2;
    public bool checkPoint3;
    public bool checkPoint4;
    public bool checkPoint5;
    public bool checkPoint6;

    public Animation wardrobeColorChange;

    public WardrobeTrigger wardrobe;

    public GameObject chestUI;
    public GameObject inventoryUI;
    public GameObject tutorialUI;
    public GameObject fadeTransitions;

    public ChestManager chestManager;



    // Use this for initialization
    void Start ()
    {

        //theDM = FindObjectOfType<DialogueManager>();
        //tutorialText = FindObjectOfType<TutorialText>();
        wardrobeColorChange = GameObject.Find("Wardrobe").GetComponent<Animation>();
        wardrobe = GameObject.Find("WardrobeTrigger").GetComponent<WardrobeTrigger>();
        theCurrentScene = SceneManager.GetActiveScene();
        chestUI.SetActive(false);
        inventoryUI.SetActive(false);
        tutorialUI.SetActive(false);

        if (theCurrentScene.name == "OpeningScene")
        {
            theDM.thePlayer.canMove = false;
            theDM.dialogueActive = true;
            theDM.ShowBox(theDM.dialogueLines[theDM.currentLine]);
            //tutorialText.ShowTutorialBox(tutorialText.tutorialLines[tutorialText.currentLine]);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {


       /* if (theDM.dialogueActive && Input.GetKeyUp(KeyCode.H))
        {
            theDM.currentLine++;
            theDM.thePlayer.canMove = false;
        }*/

        if (theDM.currentLine >= theDM.dialogueLines.Count)
        {
            theDM.dBox.SetActive(false);
            theDM.dialogueActive = false;
            theDM.thePlayer.canMove = true;

            theDM.currentLine = 0;
        }

        if(tutorialText.currentLine >= tutorialText.tutorialLines.Count)
        {
            tutorialText.tutorialUI.SetActive(false);
            tutorialText.tutorialActive = false;
            tutorialText.thePlayer.canMove = true;

            tutorialText.currentLine = 0;
        }


        //scene logic
        if (theDM.currentLine < 2 && theCurrentScene.name == "OpeningScene")
        {
            theDM.thePlayer.canMove = false;
        }

        if (theDM.currentLine >= 2 && theCurrentScene.name == "OpeningScene")
        {
            checkPoint1 = true;

            if (checkPoint1 == true)
            {
                tutorialUI.SetActive(true);
                tutorialText.tutorialActive = true;
                theDM.dBox.SetActive(false);
                theDM.dialogueActive = false;
                //Debug.Log("CheckPointCleared");

                if (tutorialText.currentLine == 1)
                {
                    checkPoint2 = true;
                    tutorialText.tutorialActive = false;
                    tutorialUI.SetActive(false);
                    tutorialText.thePlayer.canMove = true;
                }


            }

            if (checkPoint2 == true)
            {
                wardrobeColorChange.Play("Wardrobe UI");
                theDM.dBox.SetActive(false);
                theDM.dialogueActive = false;
                theDM.thePlayer.canMove = true;


                if(wardrobe.wardrobeTriggerEntered == true && Input.GetKeyUp(KeyCode.H))
                {
                    checkPoint3 = true;
                }

            }

            if(checkPoint3 == true && checkPoint4 == false)
            {
                theDM.dBox.SetActive(true);
                theDM.dialogueActive = true;
                theDM.thePlayer.canMove = false;

                if (theDM.currentLine > 2)
                {
                    checkPoint4 = true;
                }
            }

            if (checkPoint4 == true && checkPoint5 == false)
            {

                wardrobeColorChange.Stop("Wardrobe UI");
                tutorialUI.SetActive(true);
                tutorialText.tutorialActive = true;
                if (Input.GetKeyDown(KeyCode.H))
                {
                    tutorialText.currentLine++;
                }
                tutorialText.ShowTutorialBox(tutorialText.tutorialLines[tutorialText.currentLine]);
                tutorialText.thePlayer.canMove = false;
                theDM.dialogueActive = false;
                theDM.dBox.SetActive(false);
                theDM.thePlayer.canMove = false;
                chestUI.SetActive(true);
                chestManager = GameObject.Find("ChestInventoryHolder").GetComponent<ChestManager>();
                inventoryUI.SetActive(true);

                if(tutorialText.currentLine > 2)
                {
                    checkPoint5 = true;
                }
            }

            if(checkPoint5 == true)
            {
                tutorialUI.SetActive(false);
                tutorialText.tutorialActive = false;

                if(chestManager.chestEmpty == true)
                {
                    checkPoint6 = true;
                }
            }


        }






        /*if (currentLine == 2 && checkPoint1 == true) 
        {
            //Debug.Log("CheckPointCleared");
            dialogueActive = false;
            //wardrobeColorChange.Play("Wardrobe UI");
        }*/
    }
}
