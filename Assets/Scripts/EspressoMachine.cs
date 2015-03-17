using UnityEngine;
using System.Collections;

public class EspressoMachine : MonoBehaviour {

	//variabel for the max amount of maintenance
	public int MaxMaintenance = 20;
	//variable for the current amount maintenance
	public int CurrentMaintenance;

	// Use this for initialization
	void Start () {
		//subscribe to the breakall
		WaveManager.myBreakAll += BreakMachine;
		WaveManager.myFixAll += FixMachine;
		
		SetCurrentMaintenance(); //call the function to set the current maintenance
	}
	//function to set the amount of current maintenance
	void SetCurrentMaintenance()
	{
		//set the current maintenance to the max, "fixing it"
		CurrentMaintenance = MaxMaintenance;
	}
	
	void BreakMachine()
	{
		CurrentMaintenance = 0;
	}
	
	void FixMachine()
	{
		CurrentMaintenance = MaxMaintenance;
	}
	
	//ienumerator for stocking fresh milk
	IEnumerator MaintainEspresso()
	{
		//make the player busy
		PlayerScript.busy = true;
		//after a few seconds
		yield return new WaitForSeconds(2f);
		//add half of maintenance to the espresso
		CurrentMaintenance += 10;
		//check that if its more than the max, set it to the max
		if(CurrentMaintenance > MaxMaintenance)
		{
			CurrentMaintenance = MaxMaintenance;
		}
		//make the player not busy
		PlayerScript.busy = false;
	}
	
	//function to try to queue espresso into the current drink
	void TryQueueEspresso()
	{
	
		//if its not broken
		if(CurrentMaintenance > 0)
		{
			//if you dont have infinite
			if(!WaveManager.InfiniteResources)
			{
				//lessen the maintenance by one
				CurrentMaintenance -= 1;
			}
			//add one to the queue
			PlayerScript.PEspresso++;
		}
		//otherwise
		else
		{
			print ("Machine is Broken");
		}
	}
}
