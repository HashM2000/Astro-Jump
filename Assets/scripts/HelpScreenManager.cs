using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpScreenManager : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void BackButton()
	{
        // Back button will load "main main - Final scene"
		SceneManager.LoadScene ("main menu - Final");
	}
}
