using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIScript : MonoBehaviour {

	public Text ComplaintsText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//update gui
		UpdateComplaints();
	
	}
	
	//function for updating the player health component of GUI
	void UpdateComplaints()
	{
		//set the text to a fraction
		ComplaintsText.text = WaveManager.PlayerHealth + "/3";
	}
}
