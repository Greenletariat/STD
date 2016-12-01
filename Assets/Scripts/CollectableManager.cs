using UnityEngine;
using System.Collections;

public class CollectableManager : MonoBehaviour {
	//This script should go on an empty gameObject located in the middle of the game field, and is used to manage collectables ([re]spawning them)
	//There should only be one instance of this script per client/server

	//Type of collectable
	//public enum Types {HP, Energy};			//Don't need this since boxes randomly spawned I guess :(

	public GameObject hpBoxPrefab;
	public GameObject energyBoxPrefab;

	//Amt of health/energy to give, picked randomly with bias
	private int[] boxAmounts;
	//Chance per each box amount to be spawned
	private int[] boxAmountsChance;
	//# boxes per each type to be on field		Don't think we will use this anymore :(
	//private int[] boxesOnField;
	//Radius for boxes to spawn around
	private float boxSpawnRadius;
	private float respawnTime;

	// Use this for initialization
	void Start () {
		boxAmounts = new int[] {5, 10, 25, 50};
		boxAmountsChance = new int[] {30, 40, 20, 10};
		//boxAmountsChance = new int[] {10, 20, 40, 30};
		//boxesOnField = new int[] {20, 20};	Don't think we will use this anymore :(
		boxSpawnRadius = 3.0f;
	}

	//Defined functions

	//TODO: The amount is almost always 50... ????
	public void spawnBoxes(int amount, Vector3 around){
		for(int i = 0; i < amount; i++) {
			//Generate amount for the box
			int chance = Random.Range(0, 101);
			int boxAmount = 0;
			for(int j = 0; j < boxAmounts.Length; j++){
				if((chance -= boxAmountsChance[j]) < 0) {
					boxAmount = boxAmounts[j];
					break;
				}
			}
			//Where the box will be located
			Vector3 boxPos = new Vector3(around.x + Random.Range(-boxSpawnRadius, boxSpawnRadius), 0, around.z + Random.Range(-boxSpawnRadius, boxSpawnRadius)); //around.y + Random.Range(-boxSpawnRadius, boxSpawnRadius)
			//Spawns either a random hp or energy box with a random amount using the chance
			GameObject boxGen = (GameObject)Instantiate(Random.Range(0, 2) == 0 ? hpBoxPrefab : energyBoxPrefab, boxPos, Quaternion.Euler(0.0f, Random.Range(-180.0f, 180.0f), 0.0f)/*, this.transform*/);
			//Set the amount of the generated box
			boxGen.GetComponent<ObjectManager>().setMagnitudeOfAction(boxAmount);
		}
	}
}