using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackFloatingName : MonoBehaviour
{
    public float moveSpeed;
    public string attackName;
    public Text displayAttackName;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 1.1f;
    }

    // Update is called once per frame
    void Update()
    {
        displayAttackName.text = "" + attackName;
        transform.position = new Vector3(transform.position.x, transform.position.y + (moveSpeed * Time.deltaTime), transform.position.z);
    }
}
