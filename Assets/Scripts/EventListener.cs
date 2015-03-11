using UnityEngine;
using System.Collections;

public class EventListener : MonoBehaviour {



	void OnPoweredUp(bool isPoweredUp)
	{
		print (isPoweredUp);
	}
	
	void OnEnable()
	{
		DelScript.myPowerHandler += OnPoweredUp;
	}
	
	void OnDisable()
	{
		DelScript.myPowerHandler -= OnPoweredUp;
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
