using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumberWizard : MonoBehaviour {
	int max;
	int min;
	int guess;
	public int maxGuesses;

	public Text text;

	// Use this for initialization
	void Start () {
		StartGame();
	}
	
	void StartGame()
	{
		max = 1000;
		min = 1;
		NextGuess();
	}

	public void GuessHigher()
	{
		min = guess;
		NextGuess();
	}

	public void GuessLower()
	{
		max = guess;
		NextGuess();
	}

	void NextGuess()
	{
		// Binary chop search. Start with a range of 1-1000. First response if 500 so that's the new min. Meaning now it's a range of 500-1000 and so on...
		guess = Random.Range(min, max + 1);
		text.text = "My guess is: " + guess.ToString();

		// Give the computer a max number of guesses before it loses
		maxGuesses--;

		if (maxGuesses <= 0)
		{
			SceneManager.LoadScene("Win");
		}
	}
}
