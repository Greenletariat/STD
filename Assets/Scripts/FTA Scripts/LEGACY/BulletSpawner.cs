using UnityEngine;
using System.Collections;

public class BulletSpawner : MonoBehaviour {
	public GameObject Bullet;
	public Transform Spawner;
	public float sped;
	// Use this for initialization
	void Start () {
		//lmayyyyyyyyyo = Bullet.GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			var lmayyo = (GameObject)Instantiate (
				Bullet,
				Spawner.position,
				Spawner.rotation);
			lmayyo.GetComponent<Rigidbody>().velocity = lmayyo.transform.forward * sped;
			Destroy (lmayyo, 2.0f);
		}
	}
}
