using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownText : MonoBehaviour {

	public delegate void CountdownFinished();
	public static event CountdownFinished OnCountdownFinished;

	// This ensures that 'countdown' will output in 'Text' format
	Text countdown;

	void OnEnable() {
		countdown = GetComponent<Text>();
		// The 'countdown' will display the number 5 first.
		countdown.text = "5";
		StartCoroutine("Countdown");
	}

	IEnumerator Countdown() {
		// This integer variable gives 'countdown' a number to start with
		int count = 5;
		// Here is a for loop which loops from the integer value 'i = 0' to the value 'count' which is 5
		// i++ is responsible for increasing the value  of the integer by 1 each time, until it reaches the value 5
		// Then the it will loop back to the value 0
		for (int i = 0; i < count; i++) {
			// This line of code ensures that the value 5 from the integer variable 'count' is decrease by 'i' or 1 each time, instead of being increase by 1 each time
			// So it ensures that countdown will begin from 5 and then decrease to 0
			// The 'ToString' function converts this from an integer to a string variable.
			countdown.text = (count - i).ToString();
			yield return new WaitForSeconds(1);
		}

		OnCountdownFinished();
	}
}
