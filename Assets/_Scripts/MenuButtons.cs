using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        SceneManager.LoadScene("HighNoon");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void LoadLose()
    {
        SceneManager.LoadScene("LoseScreen");
    }

    public void LoadWin()
    {
        SceneManager.LoadScene("WinScreen");
    }
}
