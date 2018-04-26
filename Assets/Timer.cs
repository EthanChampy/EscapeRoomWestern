using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    GameObject PlayerCam;

    AudioSource PlayerAudio;

    public AudioClip Gun;

    public Text TimerText;
    float GameTimer = 3600f;

    bool Shoot;

	// Use this for initialization
	void Start ()
    {
        PlayerCam = GameObject.FindGameObjectWithTag("MainCamera");
        PlayerAudio = PlayerCam.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameTimer += -Time.deltaTime;

        int seconds = (int)(GameTimer % 60);
        int minutes = (int)(GameTimer / 60) % 60;

        string TimeString = string.Format("{0:00}:{1:00}",minutes,seconds);
        TimerText.text = TimeString;

        if (GameTimer < 0.75f && Shoot == false)
        {
            PlayerAudio.PlayOneShot(Gun,1);
            Shoot = true;
        }

        if (GameTimer <= 0)
        {
            PlayerAudio.PlayOneShot(Gun,1);
            SceneManager.LoadScene("LoseScreen");
        }
	}
}
