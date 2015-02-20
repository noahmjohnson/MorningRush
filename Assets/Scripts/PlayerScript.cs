using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	//variables for what the player has queued up
	public int PEspresso = 0;
	public int PMilk = 0;
	public int PSugar = 0;
	public int PVanilla = 0;
	
	//machines
	public GameObject EspressoMachineObject;
	public GameObject MilkStockObject;

	//variable for tracking how many complaints have been made to the manager
	int Complaints = 0;
	
	//variable for affecting movement, making player slower/faster
	public float speed = 5;
	//variable for the projectile to be shot
	public GameObject Projectile;

	// Update is called once per frame
	void Update () {

		//handles key inputs
		KeyInputs ();

		//make the player face the mouse
		FaceMouse ();

		CheckComplaints ();
	}

	//function for checking if the amount of complaints causes the character to lose
	void CheckComplaints()
	{
		//if three complaints are made
		if (Complaints >= 3) 
		{
			//tell player they've failed
			print ("Youve failed");

		}
	}

	//handles what keys are pressed and what actions to perform
	void KeyInputs()
	{
		//if you press mouse1, it will shoot projecitle
		if (Input.GetKeyDown (KeyCode.Mouse0))
		{
			//run shoot projecitle
			shootProjectile ();
		}

		//if you press the keys to add ingredients, add them
		if (Input.GetKeyDown (KeyCode.Q))
		{
			//add espresso
			EspressoMachineObject.SendMessage("TryQueueEspresso");
		}
		if (Input.GetKeyDown (KeyCode.W))
		{
			//add milk
			MilkStockObject.SendMessage("TryQueueMilk");
		}
		if (Input.GetKeyDown (KeyCode.E))
		{
			//add sugar
			PSugar++;
		}
		if (Input.GetKeyDown (KeyCode.R))
		{
			//add Vanilla
			PVanilla++;
		}
		if (Input.GetKeyDown (KeyCode.A))
		{
			//maintain espresso
			EspressoMachineObject.GetComponent<EspressoMachine>().StartCoroutine("MaintainEspresso");
		}
		if (Input.GetKeyDown (KeyCode.S))
		{
			//stock milk
			MilkStockObject.GetComponent<MilkStock>().StartCoroutine("StockMilk");
		}
	}

	//function for handling the shooting of the projectile
	void shootProjectile()
	{
		//instantiate projectile and set as a temp
		GameObject thing = Instantiate(Projectile,transform.TransformPoint(Vector3.up),Quaternion.identity) as GameObject;
		//add force to the projectile to makes it moves
		thing.rigidbody2D.AddRelativeForce(transform.TransformDirection(Vector2.up) * speed * 100);
		//send the ingredients queued up into the shot out coffee cup
		thing.GetComponent<CoffeeCup> ().SetCoffeeIngredients (PEspresso, PMilk, PSugar, PVanilla);
		//clear the ingredients of the player so we can add more again
		ClearIngredients ();


	}

	//function for clearing ingredients of the player
	void ClearIngredients()
	{
		//setting the player ingredients to 0
		PEspresso = 0;
		PMilk = 0;
		PSugar = 0;
		PVanilla = 0;
	}

	//function to run every frame to face the player towards the mouse
	void FaceMouse()
	{
		//Get the mouse position so we can input it as a vector 3
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//Rotate this object towards that mouse position
		transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
	}
	
	//function to lock the player shooting for x seconds
	void LockShooting(float time)
	{
		StartCoroutine("LockedFor", time);
	}
	
	//coroutine for tracking how long youre locked for
	IEnumerator LockedFor (float time)
	{
		yield return new WaitForSeconds(time);
	}

	//function for when an enemy complains to the manager
	public void FaceConsequences()
	{

	}
}
