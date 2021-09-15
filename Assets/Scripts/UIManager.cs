using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    //health bar
    public Slider healthBar;
    public Text hpText;

    //player stats
    private BaseHero hero;
    public Text levelText;

    //speed bar
    public Slider speedBar;
    public PlayerAbilities thePA;

    public PauseManager pauseManager;

    public bool isOverWorldScene;


    // Use this for initialization
    void Start()
    {
        healthBar.maxValue = hero.baseHP;
        healthBar.value = hero.currentHP;
        hpText.text = "HP: " + hero.currentHP + "/" + hero.baseHP;
        levelText.text = "LVL: " + hero.currentLevel;
        speedBar.maxValue = thePA.goatSpeedTime;
        speedBar.value = thePA.goatSpeedTimeCounter;
    }
	
	// Update is called once per frame
	void Update () 
    {
        /*healthBar.maxValue = playerHealth.playerMaxHealth;
        healthBar.value = playerHealth.playerCurrentHealth;
        hpText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;
        levelText.text = "LVL: " + thePS.currentLevel;
        speedBar.maxValue = thePA.goatSpeedTime;
        speedBar.value = thePA.goatSpeedTimeCounter;*/

	}

    public void BackToPauseMenu()
    {
        SceneManager.LoadScene("openworld");
    }

}
