using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class QuestManager : MonoBehaviour {

    public QuestObject[] quests;
    public bool[] questsCompleted;

    public DialogueManager theDM;

    public string itemCollected;

    public string enemyKilled;

	// Use this for initialization
	void Start () 
    {
        questsCompleted = new bool[quests.Length];
	}
	
	// Update is called once per frame
	void Update () 
    {
        
	}

    public void ShowQuestText(string questText)
    {
        theDM.dialogueLines = new List<string>(1);
        theDM.dialogueLines[0] = questText;

        theDM.currentLine = 0;
        theDM.ShowDialogue();
    }
}
