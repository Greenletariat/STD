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
	void Start () {
		asteroids = new ArrayList();
	}
	void Update()
	{
		while(asteroids.Count < maxteroids)
		{
			GameObject ast = (GameObject)Instantiate(asteroid, new Vector3(Random.Range(-2000,2000),Random.Range(-2000,2000),Random.Range(-2000,2000)), Quaternion.identity);
			asteroids.Add(ast);
			ast.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(Random.Range(0,360),Random.Range(0,360),Random.Range(0,360)) * asteroidLaunchForce);
		}
	}
}
