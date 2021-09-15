using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeapSkillScreen : MonoBehaviour
{

    public float jumpPower;
    public GameObject arrow;
    public GameObject jumper;
    public Vector2 direction;
    public GameTimeManager gameManager;
    public Slider jumpPowerGauge;


    // Start is called before the first frame update
    void Start()
    {
        jumpPowerGauge.maxValue = 10;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
