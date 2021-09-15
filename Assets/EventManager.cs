using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

	// Use this for initialization
	public delegate void EndOfDay();
    public static event EndOfDay EndOfDayMethods;

    public delegate void Sun();
	public static event Sun SunRotationMethods;


	public static void ResetDay()
	{
		EndOfDayMethods();
	}

	public static void RotateSun()
	{
		SunRotationMethods();
	}
}
