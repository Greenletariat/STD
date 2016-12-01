using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerFinishCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	void OnTriggerEnter(Collider other){
		if (other.tag == "FinishLine"){
			
		}
	}

	public void Restart(){
		
	}
}
