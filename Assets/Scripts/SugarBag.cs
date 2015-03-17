using UnityEngine;
using System.Collections;

public class SugarBag : MonoBehaviour {

	//variable for max sugar
	public int MaxSugar = 2000;
	//variable for the current amount of sugar
	public int CurrentSugar;
	//bool for if the player is pouring sugar currently
	public bool PouringSugar = false;

	
	// Use this for initialization
	void Start () {
		//subscribe to the breakall
		WaveManager.myBreakAll += BreakMachine;
		WaveManager.myFixAll += FixMachine;
	
		SetCurrentSugar(); //call the function to set the current maintenance
	}
	
	//function to set the amount of current sugar
	void SetCurrentSugar()
	{
		//set the current sugar to the max, topping it off
		CurrentSugar = MaxSugar;
	}
		
	//function to break the machine	
	void BreakMachine()
	{
		CurrentSugar = 0;
	}
	
	void FixMachine()
	{
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
		
			//if you dont have infinite
			if(!WaveManager.InfiniteResources)
			{
				//remove 100 sugar
				CurrentSugar -= 100;
			}
			//add one to the queue
			PlayerScript.PSugar++;
		}
		//otherwise
		else
		{
			print ("Not enough sugar in the bag!");
		}
		
	}
}
