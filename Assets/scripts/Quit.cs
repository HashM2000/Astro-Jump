using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {

	public void doquit()
	{
        // This will produce a log in the Unity console to show that the quit button has been clicked.
		Debug.Log ("has quit game");
        // This function will close/exit the game
		Application.Quit ();
	}

}
