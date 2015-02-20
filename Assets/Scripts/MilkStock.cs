using UnityEngine;
using System.Collections;

public class MilkStock : MonoBehaviour {

	//variabel for the max amount of milk a player has in stock
	public int MaxFreshMilk = 10;
	//variable for the current amount of milk a player can use
	public int CurrentFreshMilk;
	
	//variable for the player script
	public PlayerScript myPlayerScript;
	
	//variable for allowing the milk to decay afer x seconds
	private bool waitSpoil;
	
	
	// Use this for initialization
	void Start () {
		myPlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>(); //set the player script
		SetCurrentMilkStock(); //call the function to set the current milk
		StartCoroutine("SpoilMilk");
	}
	
	//function to set the amount of current milk based off the max milk
	void SetCurrentMilkStock()
	{
		//set the current milk to the max, "filling it"
		CurrentFreshMilk = MaxFreshMilk;
	}
	
	// Update is called once per frame
	void Update () {
		
		//if you dont need to wait,
		if(!waitSpoil)
		{
			//spoil the milk
			StartCoroutine("SpoilMilk");
		}
	
	}
	
	//ienumerator for stocking fresh milk
	IEnumerator StockMilk()
	{
		//after a few seconds
		yield return new WaitForSeconds(2f);
		//stock a full fridge of fresh milk
		CurrentFreshMilk = 10;
	}
	
	//function to run the queueing of milk into the current drink
	void TryQueueMilk()
	{
		//if you have more than no milk
		if(CurrentFreshMilk > 0)
		{
			//add one to the queue
			myPlayerScript.PMilk++;
		}
		//otherwise
		else
		{
			print ("No fresh milk in the stock");
		}
		
	}
	
	//function for milk spoiling/decaying
	IEnumerator SpoilMilk()
	{
		//flip the bool on
		waitSpoil = true;
		
		//wait a few seconds to spoil the next milk
		yield return new WaitForSeconds(4f);
		
		//spoil the milk
		CurrentFreshMilk--;
		
		//flip the bool back off
		waitSpoil = false;
		
	}
}
