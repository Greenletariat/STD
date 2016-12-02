//DEPRICATED, USE ASTEROIDMANAGER

using UnityEngine;
using System.Collections;

public class AsteroidSplitter : MonoBehaviour {

	[SerializeField] private GameObject asteroid;
	public float splitSpeed;

	void OnTriggerEnter (Collider other) {
		if(other.gameObject.tag =="Bullet")
		{
			GameObject.Destroy (other.gameObject);
			int splits = Random.Range (2, 4);
			for (int x = 0; x < splits; x++) {
				GameObject ast = (GameObject)Instantiate (asteroid, this.transform.position,this.transform.rotation);
				ast.GetComponent<Rigidbody>().AddForce(new Vector3(splitSpeed*Random.Range(-1,2),0.0f,splitSpeed*Random.Range(-1,2)));
			}
			GameObject.Destroy (this.gameObject);
		}
	}
}
