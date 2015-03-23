using UnityEngine;
using System.Collections;

public class VanillaPump : MonoBehaviour {

	//variabel for the max amount of vanilla
	public int MaxVanilla = 20;
	//variable for the current amount of vanilla a player can use
	public static int CurrentVanilla;
	
	//variable for allowing the vanilla to regen
	private bool waitRegen;
	
	
	// Use this for initialization
	void Start () {
		//subscribe to the breakall
		WaveManager.myBreakAll += BreakMachine;
		WaveManager.myFixAll += FixMachine;
		
		ResetVanilla(); //call the function to set the current vanilla
	}
	
	//function to break the machine
	void BreakMachine()
	{
		CurrentVanilla = 0;
	}
	
	void FixMachine()
	{
		CurrentVanilla = MaxVanilla;
	}
	
	//function to set the amount of current vanilla based off max
	void ResetVanilla()
	{
		//set the current vanilla to the max, "filling it"
		CurrentVanilla = MaxVanilla;
	}
	
	// Update is called once per frame
	void Update () {
		
		//if you dont need to wait,
		if(!waitRegen && EncounterEnemy2.done)
		{
			//spoil the vanilla
			StartCoroutine("RegenVanilla");
		}
		
	}

	//function to run the queueing of vanilla into the current drink
	void TryQueueVanilla()
	{
		//if you have more than no vanilla
		if(CurrentVanilla > 0)
		{
			//if you dont have infinite
			if(!WaveManager.InfiniteResources)
			{
				//lessen the vanilla by one
				CurrentVanilla -= 1;
			}
			//add one to the queue
			PlayerScript.PVanilla++;
		}
		//otherwise
		else
		{
			print ("Wait for vanilla to regen");
		}
		
	}
	
	//function for vanilla regenning. Bring back the vanilla. Yo.
	IEnumerator RegenVanilla()
	{
		//flip that shiz.
		waitRegen = true;
		
		//Stop. In the name of love.
		yield return new WaitForSeconds(1f);
		
		//if you have less than the max
		if(CurrentVanilla < MaxVanilla)
		{
			//give vanilla like Michael Jackson
			CurrentVanilla++;
		}
		
		//flip the bool back off
		waitRegen = false;
		
	}
}
