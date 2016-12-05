//DEPRICATED, USE ASTEROIDMANAGER

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidSpawner : MonoBehaviour {

	// Use this for initialization
	private ArrayList asteroids;
	public GameObject Player;
	public int maxteroids;
	public GameObject asteroid;
	public float asteroidLaunchForce;
	public GameObject finish;
	private GameObject assteroid;
	private GameObject p;
	void Start () {
		asteroids = new ArrayList();
		while(asteroids.Count < maxteroids)
		{
			GameObject ast = (GameObject)Instantiate(asteroid, new Vector3(Random.Range(-150000,150000),Random.Range(-150000,150000),Random.Range(-150000,150000)), Quaternion.identity);
			asteroids.Add(ast);
			//ast.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(Random.Range(-5,5),Random.Range(-5,5),Random.Range(-5,5)));
		}
		assteroid = (GameObject) asteroids[Random.Range(0,maxteroids+1)];
		p = (GameObject)Instantiate(finish, assteroid.transform.position + new Vector3(0.0f,401.0f,0.0f),Quaternion.identity);
	}
void Update() {
	Debug.Log(Player.transform.position - p.transform.position);
}
}
