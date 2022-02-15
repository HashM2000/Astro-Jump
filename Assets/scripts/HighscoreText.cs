using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreText : MonoBehaviour {
	// This ensures that 'score' will output in 'Text' format
	Text score;

	void OnEnable() {
		score = GetComponent<Text>();
		// This line of code will display the text of the Highest Score
		// It gets the integer value of the player's 'HighScore'
		// It then converts it from an integer to a string variable by using the function 'ToString'
		score.text = "Highest Score: " +PlayerPrefs.GetInt("HighScore").ToString();
	}
}
