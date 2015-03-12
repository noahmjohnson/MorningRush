using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIScript : MonoBehaviour {

	//references to the text components and gui
	public Text ComplaintsText;
	public Text EspressoQueued;
	public Text MilkQueued;
	public Text SugarQueued;
	public Text VanillaQueued;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//update gui
		UpdateComplaints();
		UpdateQueue();
	
	}
	
	void UpdateQueue()
	{
		//set the texts of the resource queues
		EspressoQueued.text = PlayerScript.PEspresso.ToString ();
		MilkQueued.text = PlayerScript.PMilk.ToString ();
		SugarQueued.text = PlayerScript.PSugar.ToString ();
		VanillaQueued.text = PlayerScript.PVanilla.ToString ();
	}
	
	//function for updating the player health component of GUI
	void UpdateComplaints()
	{
		//set the text to a fraction
		ComplaintsText.text = WaveManager.PlayerHealth + "/3";
	}
}
