
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidSpawner : MonoBehaviour {

	// Use this for initialization
	private ArrayList asteroids;
	public int maxteroids;
	public GameObject asteroid;
	private float asteroidLaunchForce;
	public GameObject win;
	public GameObject Player;
	private GameObject winAsteroid;
	private GameObject winner;
	void Start () {
		asteroids = new ArrayList();
		while(asteroids.Count < maxteroids)
		{
			GameObject ast = (GameObject)Instantiate(asteroid, new Vector3(Random.Range(-350000,350000),Random.Range(-350000,350000),Random.Range(-350000,350000)), Quaternion.identity);
			asteroids.Add(ast);
			//ast.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(Random.Range(0,360),0.0f,Random.Range(0,360)) * asteroidLaunchForce);
		}

		//assuming asteroids aren't destroyed and the arraylist stays constant throughout
		winAsteroid = (GameObject)asteroids[Random.Range(0,asteroids.Count+1)];
		winner = (GameObject)Instantiate(win, winAsteroid.transform.position + (new Vector3(0.0f,12500.0f,0.0f)), Quaternion.identity);

	}
	void Update()
	{
				Debug.Log(winner.transform.position - Player.transform.position);
	}
}
