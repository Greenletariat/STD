using UnityEngine;
using System.Collections;


public class AsteroidManager : MonoBehaviour {
	//This script should go on an empty gameObject located at the middle of the game field, and is used to manage asteroids (spawning them)
	//There should only be one instance of this script per client/server

	public int asteroidsOnField; 			//# of asteroids on the game field at all times
	public GameObject[] asteroidPrefabs;
	public float asteroidLaunchForce; 	//Magnitude of the launch velocity (will be vectorized in code)

	private Vector3 fieldRadius; 				//Used to define where the asteroids will spawn from
	private Vector3 fieldOffset;
	private Vector3 fieldMargins;

	//Initialization
	void Start () {
		fieldRadius = GameObject.Find("GameField").GetComponent<GameFieldHelper>().getGameFieldRadius();
		fieldOffset = GameObject.Find("GameField").GetComponent<GameFieldHelper>().getGameFieldOffset();
		fieldMargins = GameObject.Find("GameField").GetComponent<GameFieldHelper>().getGameFieldMargins();
		for(int i = 0; i < asteroidsOnField; i++) {
			AddAsteroid();
		}
	}

	//Loop to check where the asteroids are and destroy them if they are out of the field.
	void Update(){
		
	}

	//[Command]
	//void CmdAddAsteroid(){
	//Once we need to add MP ^^
	public GameObject AddAsteroid(){
		// Random point in the gamefield that we will point the asteroid at
		Vector3 pointInField = new Vector3(Random.Range(-fieldRadius.x, fieldRadius.x), 0.0f, Random.Range(-fieldRadius.z, fieldRadius.z));
		Vector3 asteroidPosition = new Vector3(Random.Range(-fieldRadius.x - fieldMargins.x, fieldRadius.x + fieldMargins.x), 0.0f, Random.Range(-fieldRadius.z - fieldMargins.z, fieldRadius.z + fieldMargins.z));
		asteroidPosition += fieldOffset;
		//Direction to point the asteroid
		Vector3 direction = pointInField - asteroidPosition;
		//Create the asteroid gameobject
		GameObject genAsteroid = (GameObject)Instantiate(asteroidPrefabs[Random.Range(0,3)], asteroidPosition, Quaternion.FromToRotation(Vector3.forward, direction), this.transform);
		//Set the size of the asteroid
		float asteroidSize = Random.Range(1.0f, 20.0f);
		genAsteroid.GetComponent<ObjectManager>().setMagnitudeOfActionF(asteroidSize);
		genAsteroid.transform.localScale *= asteroidSize / 4.0f;
		//Add a force to the asteroid to make it go through the field
		genAsteroid.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * asteroidLaunchForce);
		return genAsteroid;
	}
	bool RandBool(){ 	//Returns true or false
		return Random.Range(0, 2) == 0 ? true : false;
	}
}
