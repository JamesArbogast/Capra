using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeManager : MonoBehaviour {

    public int gameDayLengthMins;
    private int gameDayLengthSecs;
    private int currentGameTime;
    private bool isRunning = true;
    private bool isDayOver = false;
    private bool isPaused = false;

    private void OnEnable()
    {
        gameDayLengthSecs = gameDayLengthMins * 10;
        EventManager.EndOfDayMethods += ResetGameClock;
        EnableGameClock();
    }

    private void OnDisable()
    {
        KillGameClock();
        EventManager.EndOfDayMethods -= ResetGameClock;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                UnPauseGameClock();
            }
            else
            {
                PauseGameClock();
            }
        }
    }


    //basic setup of a coroutine
    private IEnumerator GameClock()
    {
        while (isRunning)
        {
            if (isPaused)
            {
                yield return null;
            }
            else
            {
                currentGameTime++;
                //EventManager.RotateSun();
                if (currentGameTime >= gameDayLengthSecs)
                {
                    //day is over
                    isDayOver = true;
                    Debug.Log("Day is over!");
                    currentGameTime = 0;
                    isDayOver = false;
                }
            }
            Debug.Log("Current Game Time: " + currentGameTime);
            yield return new WaitForSeconds(1f);
        }

        
    }

    private void PauseGameClock()
    {
        Debug.Log("Game Clock Paused");
        isPaused = true;
    }

    private void UnPauseGameClock()
    {
        Debug.Log("Game Clock Unpaused");
        isPaused = false;
    }

    public void ResetGameClock()
    {
        Debug.Log("Day is over!");
        currentGameTime = 0;
        isDayOver = false;
    }

    private void KillGameClock()
    {
        Debug.Log("Killed Game Clock");
        isRunning = false;
    }

    private void EnableGameClock()
    {
        ResetGameClock();
        isRunning = true;
        isPaused = false;
        StartCoroutine(GameClock());
    }
}
