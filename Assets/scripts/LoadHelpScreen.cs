using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadHelpScreen : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}

	// Update is called once per frame
	void Update ()
	{
		
	}

	public void HelpButton()
	{
        // Help button will load the "Help" scene
		SceneManager.LoadScene ("Help");
	}
}
