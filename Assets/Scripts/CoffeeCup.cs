using UnityEngine;
using System.Collections;

public class CoffeeCup : MonoBehaviour {

	//variables for what the cup has
	public int Espresso = 0;
	public int Milk = 0;
	public int Sugar = 0;
	public int Vanilla = 0;

	// Use this for initialization
	void Start () {
		//start the number to destroy the cube if it exists for too long
		StartCoroutine("BoomDestroy");
	
	}

	//coroutine for destorying a projectile if it flies off screen
	IEnumerator BoomDestroy()
	{
		//arbitrary number to destroy the projectile after some time
		yield return new WaitForSeconds(4);
		Destroy (this.gameObject);
	}

	//function to set the values of the cup of coffee
	public void SetCoffeeIngredients(int e, int m, int s, int v)
	{
		//Set each of the variables to the inputs
		Espresso = e;
		Milk = m;
		Sugar = s;
		Vanilla = v;
	}

	//Trigger enter statement for recognizing if it hits an enemy
	void OnTriggerEnter2D (Collider2D c)
	{
		//if it hits an enemy
		if (c.tag == "Enemy") 
		{
			//logic to check if it satisfies enemy
			c.GetComponent<EnemyScript>().CheckDrink(Espresso, Milk, Sugar, Vanilla);

			//destroy the projectile because obviously
			Destroy(this.gameObject);
		}

	}
}
