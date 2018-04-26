using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text TimerText;
    float GameTimer = 3600f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameTimer += -Time.deltaTime;

        int seconds = (int)(GameTimer % 60);
        int minutes = (int)(GameTimer / 60) % 60;

        string TimeString = string.Format("{0:00}:{1:00}",minutes,seconds);
        TimerText.text = TimeString;
	}
}
