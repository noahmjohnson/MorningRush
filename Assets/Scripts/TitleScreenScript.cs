﻿using UnityEngine;
using System.Collections;

public class TitleScreenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void StartGame()
	{
		Application.LoadLevel(0);
	}
	
	public void QuitGame()
	{
		Application.Quit ();
	}
}
