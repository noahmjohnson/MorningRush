using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	//event handler for exodus
	public delegate void MassExodus(bool satisfied);
	public static event MassExodus myMassExodus;

	//variables for what the player has queued up
	public static int PEspresso = 0;
	public static int PMilk = 0;
	public static int PSugar = 0;
	public static int PVanilla = 0;
	
	//machines
	public GameObject EspressoMachineObject;
	public GameObject MilkStockObject;
	public GameObject SugarBagObject;
	
	//variable for checking if the player is currently busy doing something
	public static bool busy = false;
	
	//variable for affecting movement, making player slower/faster
	public float speed = 5;
	//variable for the projectile to be shot
	public GameObject Projectile;

	//event handler

	// Update is called once per frame
	void Update () {

		//handles key inputs
		KeyInputs ();

		//make the player face the mouse
		FaceMouse ();
	}

	//handles what keys are pressed and what actions to perform
	void KeyInputs()
	{
		//if you press mouse1 and youre not busy, it will shoot projecitle
		if (Input.GetKeyDown (KeyCode.Mouse0) && !busy)
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
			SugarBagObject.SendMessage("TryQueueSugar");
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
		if (Input.GetKeyDown(KeyCode.D))
		{
			//make the player busy if they pour sugar
			busy = true;
			//turn on the sugar pouring
			SugarBagObject.GetComponent<SugarBag>().PouringSugar = true;
		}
		if (Input.GetKeyUp(KeyCode.D))
		{
			//make the player not busy when they stop pouring sugar
			busy = false;
			//turn off the sugar pouring
			SugarBagObject.GetComponent<SugarBag>().PouringSugar = false;
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
		//if you arent about to die
		if(WaveManager.PlayerHealth > 1)
		{
			//subtract from the repuatation
			WaveManager.PlayerHealth--;
		}
		else 
		{
			//subtract from the repuatation
			WaveManager.PlayerHealth--;
			
			//otherwise end the game
			//mass exodus time, with them being unhappy
			myMassExodus(false);
		}
	}
}
