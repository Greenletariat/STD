//DEPRICATED, USE ASTEROIDMANAGER

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidSpawner : MonoBehaviour {

	// Use this for initialization
	private ArrayList asteroids;
	public int maxteroids;
	public GameObject asteroid;
	public float asteroidLaunchForce;
	public float time;
	void Start () {
		asteroids = new ArrayList();
	}
	void Update()
	{
		while(asteroids.Count < maxteroids)
		{
			GameObject ast = (GameObject)Instantiate(asteroid, new Vector3(Random.Range(-150,150),0.0f,Random.Range(-150,150)), Quaternion.identity);
			asteroids.Add(ast);
			ast.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(Random.Range(0,360),0.0f,Random.Range(0,360)) * asteroidLaunchForce);
		}

		//assuming asteroids aren't destroyed and the arraylist stays constant throughout
		GameObject winAsteroid = (GameObject)asteroids[Random.Range(0,asteroids.Count)];
		winAsteroid.tag = "FinishLine";
	}
}
