using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTransition : MonoBehaviour
{

    public SceneOneInteractions sceneManager;


    // Start is called before the first frame update
    void Start()
    {
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneOneInteractions>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            if (sceneManager.checkPoint6 == true)
            {
                SceneManager.LoadScene(2);
            }
        }


    }

}
