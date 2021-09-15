using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour {

    public Vector3 cameraChange;
    public Vector3 playerChange;
    private CameraController cam;

	// Use this for initialization
	void Start () 
    {
        cam = Camera.main.GetComponent<CameraController>();
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    private void OnTriggerEnter2D (Collider2D other)
    {
       if (other.CompareTag("Player"))
        {
            cam.minBounds += cameraChange;
            cam.maxBounds += cameraChange;
            other.transform.position += playerChange;

        }
    }
}
