using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuessTheNumber : MonoBehaviour {

    public InputField input;
    public Text infoText;

    private int guessNumber;
    private int userGuess;

	// Use this for initialization
	void Start () {
        guessNumber = Random.Range(0, 100);
	}
	
    public void CheckGuess()
    {
        userGuess = int.Parse(input.text);

        if (userGuess == guessNumber)
        {
            infoText.text = "You guessed the number";
        }
        if (userGuess > guessNumber)
        {
            infoText.text = "Your guess is too high";
        }
        if (userGuess < guessNumber)
        {
            infoText.text = "Your guess is too low";
        }

        input.text = "";
    }

	// Update is called once per frame
	void Update () {
		
	}
}
