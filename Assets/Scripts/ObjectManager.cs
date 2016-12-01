using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour {
	
	private string objectType;
	private int magnitudeOfAction;
	private float magnitudeOfActionF;
	//Probably won't need this
	//private Rigidbody rb;
	private bool destroyOnExit;
	private Vector3 gameFieldRadius;

	//Initialization
	void Start(){
		objectType = this.tag;
		//rb = this.GetComponent<Rigidbody>();
		destroyOnExit = true;
		if(objectType == "Asteroid") {
			Vector3 scaleBy = Vector3.one * (this.magnitudeOfActionF / 5.0f);
			this.transform.localScale.Scale(scaleBy);
		}
		gameFieldRadius = GameObject.Find("GameField").GetComponent<GameFieldHelper>().getGameFieldRadius();
	}

	//For the destroyOnExit flag
	void Update(){
		if(destroyOnExit) {
			float x, z;
			x = this.transform.position.x;
			z = this.transform.position.z;
			//If the position of this object is outside the radius of the game field
			if(gameFieldRadius.x - Mathf.Abs(x) < 0 || gameFieldRadius.z - Mathf.Abs(z) < 0) {
				Destroy(this.gameObject);
				if(this.objectType.Equals("Asteroid")) {
					GameObject.Find("Asteroids").GetComponent<AsteroidManager>().AddAsteroid();
				}
			}
		}
	}

	void OnTriggerEnter(Collider other){
		performObjectTask(other.gameObject);
	}

	//Set the magnitude of what the object attached is supposed to do
	public void setMagnitudeOfAction(int magnitude){
		magnitudeOfAction = magnitude;
	}

	//Set the magnitude of what the object attached is supposed to do
	public void setMagnitudeOfActionF(float magnitude){
		magnitudeOfActionF = magnitude;
	}

	public void setDestroyOnExit(bool destroy){
		destroyOnExit = destroy;
	}

	//Do what the object attached is supposed to do
	public void performObjectTask(GameObject target){
		if(target.tag == "Player") {
			PlayerManager pm = target.GetComponent<PlayerManager>();
			switch(objectType) {
				case "HPCol":
					pm.updateHealth(magnitudeOfAction);
					Destroy(this.gameObject);
					break;
				case "EnergyCol":
					pm.updateEnergy(magnitudeOfAction);
					Destroy(this.gameObject);
					break;
				case "Asteroid":
					pm.asteroidCollision(magnitudeOfAction);
					break;
				case "Bullet":
					pm.bulletCollision(magnitudeOfAction);
					break;
			}
		} else if(target.tag == "Bullet") {
			switch(objectType) {
				case "HPCol":
					//Make an explosion and destroy target and self
					break;
				case "EnergyCol":
					//Make an explosion and destroy target and self
					break;
				case "Asteroid":
					//Make an explosion and spawn a few boxes depending on size of asteroid
					GameObject.Find("Collectables").GetComponent<CollectableManager>().spawnBoxes((int)magnitudeOfActionF / 4, transform.position);
					GameObject.Find("Asteroids").GetComponent<AsteroidManager>().AddAsteroid();
					Destroy(this.gameObject);
					break;
				case "Bullet":
					//Make an explosion and destroy target and self
					break;
			}
		}
	}
}
