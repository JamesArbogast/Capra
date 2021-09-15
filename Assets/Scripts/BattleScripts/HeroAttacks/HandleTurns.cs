using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HandleTurns
{

    public string attacker; //name of attacker
    public string type;
    public GameObject attackersGameObject; //gameobject of the attacker
    public GameObject attackersTarget; //gameobject of who is being attacked

    //which attack is performed
    public BaseAttack chooseAttack;
}
