using UnityEngine;
using System.Collections;

public class SugarBag : MonoBehaviour {

	//variable for max sugar
	public int MaxSugar = 2000;
	//variable for the current amount of sugar
	public int CurrentSugar;
	//bool for if the player is pouring sugar currently
	public bool PouringSugar = false;
	//variabel for the player script
	public PlayerScript myPlayerScript;
	
	// Use this for initialization
	void Start () {
		myPlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>(); //set the player script
		SetCurrentSugar(); //call the function to set the current maintenance
	}
	
	//function to set the amount of current sugar
	void SetCurrentSugar()
	{
		//set the current sugar to the max, topping it off
		CurrentSugar = MaxSugar;
	}
	
	//update to check if youre pouring sugar
	void Update()
	{
		//if youre pouring sugar
		if(PouringSugar)
		{
			//if you have less sugar than the max amount
			if(CurrentSugar < MaxSugar)
			{
				//add to the current sugar every frame that youre pouring
				CurrentSugar++;
			}
		}
	}
	
	//function to run the queueing of sugar into the current drink
	void TryQueueSugar()
	{
		//if you have more than the required amount of sugar
		if(CurrentSugar > 100)
		{
			//add one to the queue
			myPlayerScript.PSugar++;
			//remove 100 sugar
			CurrentSugar -= 100;
		}
		//otherwise
		else
		{
			print ("Not enough sugar in the bag!");
		}
		
	}
}
