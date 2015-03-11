using UnityEngine;
using System.Collections;

public class DelScript : MonoBehaviour {

	public delegate void PowerUpHandler(bool isPoweredUp);
	
	public static event PowerUpHandler myPowerHandler;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		if(GUI.Button(new Rect(50,50,50,50), "power up"))
		{
			if(myPowerHandler != null)
			{
				myPowerHandler(true);
			}
		}
		if(GUI.Button(new Rect(50,100,50,50), "power off"))
		{
			if(myPowerHandler != null)
			{
				myPowerHandler(false);
			}
		}
	}
	
	
}
