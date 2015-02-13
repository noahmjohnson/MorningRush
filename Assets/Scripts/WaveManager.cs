using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour {

	//variable for how many complaints the player can take
	public int PlayerHealth = 3;

	int currentWave = 1; //variable for tracking what wave it is NOW
	int enemiesToSpawn; //enemies total of the wave
	int enemiesNeedSpawn; //enemies still needing to spawn
	public int enemiesKilled; //enemies of wave killed
	bool waveComplete = false; //is the wave complete
	bool canStart = true; //can the next wave start
	bool readyToSpawn = true; //is it ready to spawn
	bool endWaveRunning = false; //end the wave running currently
	
	public GameObject enemy; //variable for enemy

	public int[] EnemiesEachWave; //array for setting how many enemies to spawn each wave
	
	public Transform[] spawnLocations; //array of transforms, which are spawn locations inserted publicly
	
	// Use this for initialization
	void Start () {

		StartWave (); //start wave
	}
	
	// Update is called once per frame
	void Update () {

		//if checkdead is false, meaning the player isnt dead, continue playing the game
		if (!CheckDead ()) 
		{
			if (canStart) 
			{
				StartWave (); //if it can start, start it
			}
			if (!waveComplete) 
			{  //if its not complete,
				Spawn (); //continue spawning
			}
			if (CheckComplete ()) 
			{ //checkif its complete,
				if (!endWaveRunning) 
				{ //if it is, and we arent ending the wave running,
					StartCoroutine ("EndWave"); // end the current wave
				}
			}
		}
		else 
		{
			//do whatever needs to be done for if the player is dead
			
			//show the "you died gui"
		}
		
	}
	
	void StartWave() //start wave set
	{
		canStart = false; //doesnt need to start now
		waveComplete = false; //not complete yet
		//reset how many enemies you've killed
		enemiesKilled = 0;

		//set the amount of enemies needed to spawn during each wave, set in inspector in an array
		enemiesToSpawn = EnemiesEachWave [currentWave - 1];

		enemiesNeedSpawn = enemiesToSpawn; // set the enemies we need to spawn to the amount to spawn
	}
	
	void Spawn() //spawn loop
	{
		int waveLength = 10; //length of wave in seconds
		float spawnEvery = waveLength / enemiesToSpawn; //calculation for how often i want to spawn the enemies
		
		if (readyToSpawn && enemiesNeedSpawn != 0)  //if its ready to spawn, and you still need to spawn enemies, continue
		{
			int myRandom = Random.Range (0, 4); //pick a random
			Instantiate (enemy, spawnLocations[myRandom].transform.position, Quaternion.identity);//instantiate the enemy at a random spawnpoint
			enemiesNeedSpawn--; //lessen the enemies needed to spawn
			readyToSpawn = false; //say its not ready to spawn another yet
			StartCoroutine("WaitSpawn", spawnEvery); //start the wait for the next spawn, based on the interval of spawning
		} 
	}
	
	IEnumerator WaitSpawn(float spawnEvery) //timer for waiting between spawns
	{
		yield return new WaitForSeconds(spawnEvery);
		readyToSpawn = true; //tell its ready to spawn
	}
	
	bool CheckComplete() //check if the wave is complete
	{
		//check if enemies youve killed is the same as the amount spawned
		if (enemiesKilled == enemiesToSpawn)  //if enemies youve killed is equal to the max, the wave is done
		{
			waveComplete = true;
			return true;
		} 
		else 
		{
			return false; //otherwise, its not.
		}
	}
	
	IEnumerator EndWave() //end the wave
	{
		endWaveRunning = true; //end wave is running
		if (currentWave == EnemiesEachWave.Length)  //if the wave is 6,
		{
			print ("YOU WON!"); //do final win
		} 
		else 
		{
			print ("Wave " + currentWave.ToString () + " Complete!"); //otherwise say which wave you won
			currentWave++; //add to current wave
			yield return new WaitForSeconds (3); //wait a few seconds
			canStart = true; //ready to start
		}
		endWaveRunning = false; //end wave running no longer
	}

	//function to check every frame if enough people have complained to the manager
	bool CheckDead()
	{
		//if players health 
		if (PlayerHealth <= 0) 
		{
			return true;
		} 
		else 
		{
			return false;
		}
	}
}
