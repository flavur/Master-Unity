using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public void StartGame()
    {
        SceneManager.LoadScene("v0");
    }

    public void HighScoreMenu()
    {
        SceneManager.LoadScene("HighScore");
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene("Options");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MusicButton()
    {
        
    }

}
